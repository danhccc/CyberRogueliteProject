using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using StarterAssets;
using System.Collections;

public class EnemyBehaviours : MonoBehaviour
{
    [SerializeField] private GameObject playerPosition;
    public GameObject followTarget;

    public bool isPatrolling;
    public bool isChasing;
    public bool isAttacking;
    public bool isDead;

    public GameObject damager;

    private NavMeshAgent agent;
    private Animator animator;
    public LayerMask whatIsGround, whatIsPlayer;

    public float timeBetweenAttacks;
    bool alreadyAttacked;

    // Patrol
    public Vector3 walkPoint;
    public float walkPointRange;
    bool walkPointSet;

    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;

    public int health;

    public float destroyTimer = 3;

    public AudioSource deadSound;

    public GameObject self;


    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        
    }

    private void Start()
    {
        Patrolling();
        playerPosition = GameObject.FindGameObjectWithTag("Player");
        agent.SetDestination(playerPosition.transform.position);
    }

    void Update()
    {
        if (isDead)
        {
            
            animator.SetBool("isDead", true);
            agent.Stop(true);
            destroyTimer -= Time.deltaTime;

            if (destroyTimer < 0)
                Destroy(gameObject);
            return;
        }
            

        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

        if (playerInSightRange && !playerInAttackRange)
            SeekingPlayer();
        else if (playerInAttackRange && playerInSightRange)
            AttackPlayer();
    }

    private void Patrolling()
    {
        
        if (!walkPointSet)
            SearchWalkPoint();
        else if (walkPointSet)
            agent.SetDestination(walkPoint);

        Vector3 distanceToWalkPoint = transform.position - walkPoint;
        animator.SetBool("isSeeking", true);
        //Reached WalkPoint
        if (distanceToWalkPoint.magnitude < 1f)
            walkPointSet = false;

        isPatrolling = true;
        isChasing = false;
        isAttacking = false;

    }

    private void SearchWalkPoint()
    {
        // Calculate random point in range
        float randomX = Random.Range(-walkPointRange, walkPointRange);
        float randomZ = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
        {
            walkPointSet = true;
        }
    }

    private void SeekingPlayer()
    {
        animator.SetBool("isSeeking", true);
        animator.SetBool("isAttacking", false);
        agent.SetDestination(playerPosition.transform.position);
        isPatrolling = false;
        isChasing = true;
        isAttacking = false;
    }

    private void AttackPlayer()
    {
        animator.SetBool("isAttacking", true);
        agent.SetDestination(playerPosition.transform.position);
        damager.SetActive(true);
        transform.LookAt(playerPosition.transform);

        if (!alreadyAttacked)
        {
            // Attack behaviour
            // ...Logic...
            //

            alreadyAttacked = true;
            animator.SetBool("isAttacking", false);
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }

        isPatrolling = false;
        isChasing = false;
        isAttacking = true;
    }

    private void ResetAttack()
    {
        alreadyAttacked = false;
    }

    public void TakeDamage(int damage)
    {
        if (isDead)
            return;
        health -= damage;

        if (health <= 0)
        {
            deadSound.Play();
            this.GetComponent<CapsuleCollider>().enabled = false;
            KillCountManager.instance.SetKillCount(1);
            isDead = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            TakeDamage(25);
        }
    }
}
