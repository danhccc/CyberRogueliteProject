using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerBehaviour : MonoBehaviour
{
    [Header("Player Status")]
    public bool isWalking;
    public bool isRunning;
    public bool isJumping;
    public bool isFiring;

    public bool useDash;
    public Vector3 startingPosition;

    [Header("Movement Variables")]
    public float walkSpeed = 5.0f;
    public float runSpeed = 8.0f;
    public float jumpForce = 5.0f;

    public bool isSpeedBoosting = false;
    public bool isJumpBoosting = false;


    // Components
    Rigidbody rigidbody;
    Animator playerAnimator;
    public GameObject followTransform;

    //Movement Reference
    public Vector2 inputVector = Vector2.zero;
    public Vector3 moveDirection = Vector3.zero;
    public Vector2 lookInput = Vector2.zero;

    public float aimSensitivity;

    public readonly int movementXHash = Animator.StringToHash("MovementX");
    public readonly int movementYHash = Animator.StringToHash("MovementY");
    public readonly int isJumpingHash = Animator.StringToHash("isJumping");
    public readonly int isRunningHash = Animator.StringToHash("isRunning");
    public readonly int isFiringHash = Animator.StringToHash("IsFiring");
    public readonly int isReloadingHash = Animator.StringToHash("IsReloading");

    public int health = 50;

    void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
        playerAnimator = GetComponent<Animator>();
    }

    private void Start()
    {
        startingPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {


        // Camera:

        // Camera X_Axis rotation
        followTransform.transform.rotation *= Quaternion.AngleAxis(lookInput.x * aimSensitivity, Vector3.up);
        followTransform.transform.rotation *= Quaternion.AngleAxis(lookInput.y * aimSensitivity, Vector3.left);
        // Camera Y_Axis rotation
        var angles = followTransform.transform.localEulerAngles;
        angles.z = 0;

        var angle = followTransform.transform.localEulerAngles.x;

        if (angle > 180 && angle < 300)
        {
            angles.x = 300;
        }
        else if (angle < 180 && angle > 70)
        {
            angles.x = 70;
        }

        followTransform.transform.localEulerAngles = angles;


        transform.rotation = Quaternion.Euler(0, followTransform.transform.rotation.eulerAngles.y, 0);
        followTransform.transform.localEulerAngles = new Vector3(angles.x, 0f, 0f);

        // Movements:

        if (isJumping)
            return;

        if (!(inputVector.magnitude > 0))
            moveDirection = Vector3.zero;

        moveDirection = transform.forward * inputVector.y + transform.right * inputVector.x;
        float currentSpeed = isRunning ? runSpeed : walkSpeed;

        Vector3 movementDirection = moveDirection * (currentSpeed * Time.deltaTime);

        transform.position += movementDirection;

        //print(rigidbody.velocity.y);
    }
    public void OnMovement(InputValue value)
    {
        inputVector = value.Get<Vector2>();
        playerAnimator.SetFloat(movementXHash, inputVector.x);
        playerAnimator.SetFloat(movementYHash, inputVector.y);
    }

    public void OnRun(InputValue value)
    {
        isRunning = value.isPressed;
        playerAnimator.SetBool(isRunningHash, isRunning);
    }

    public void OnJump(InputValue value)
    {
        if (isJumping)
            return;

        isJumping = true;
        rigidbody.AddForce((transform.up + moveDirection) * jumpForce, ForceMode.Impulse);
        playerAnimator.SetBool(isJumpingHash, isJumping);
    }

    public void OnCameraLook(InputValue value)
    {
        lookInput = value.Get<Vector2>();
        // If we aim up, down, adjust animations to havew a mask that will let us properly 
        // animate aim.

    }

    public void OnAbility(InputValue value)
    {
       
        if (!useDash)
            useDash = true;
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.CompareTag("Ground") && !isJumping)
            return;
        isJumping = false;
        rigidbody.velocity = new Vector3(0, 0, 0);
        playerAnimator.SetBool(isJumpingHash, false);
    }
}
