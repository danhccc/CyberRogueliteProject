using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using StarterAssets;
using UnityEngine.InputSystem;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private CinemachineVirtualCamera aimVirtualCamera;
    [SerializeField]
    private float normalSensitivity;
    [SerializeField]
    private float aimSensitivity;

    private StarterAssetsInputs starterAssetsInputs;
    private ThirdPersonController thirdPersonController;
    private Animator animator;
    public AudioSource fireSound;

    [SerializeField]
    private LayerMask aimColliderLayerMask = new LayerMask();
    [SerializeField]
    private Transform debugTransform;
    [SerializeField]
    private Transform pBulletProjectile;
    [SerializeField]
    private Transform spawnBulletPosition;

    [SerializeField] public GameObject carryRifle;
    [SerializeField] public GameObject holderRifle;

    private bool isAimming;

    private void Awake()
    {
        starterAssetsInputs = GetComponent<StarterAssetsInputs>();
        thirdPersonController = GetComponent<ThirdPersonController>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        // If activate the aiming camera, and set sensitivity
        Vector3 mouseWorldPosition = Vector3.zero;
        Vector2 screenCenterPoint = new Vector2(Screen.width / 2f, Screen.height / 2f);
        Ray ray = Camera.main.ScreenPointToRay(screenCenterPoint);
        if (Physics.Raycast(ray, out RaycastHit raycastHit, 999f, aimColliderLayerMask))
        {
            debugTransform.position = raycastHit.point;
            mouseWorldPosition = raycastHit.point;
        }


        if (starterAssetsInputs.aim)
        {
            aimVirtualCamera.gameObject.SetActive(true);
            thirdPersonController.SetSensitivity(aimSensitivity);
            thirdPersonController.SetRotateOnMove(false);

            carryRifle.gameObject.SetActive(false);
            holderRifle.gameObject.SetActive(true);

            animator.SetLayerWeight(1, Mathf.Lerp(animator.GetLayerWeight(1), 1f, Time.deltaTime * 10f));

            // Turn character while aiming
            Vector3 worldAimTarget = mouseWorldPosition;
            Vector3 aimDirection = (worldAimTarget - transform.position).normalized;

            transform.forward = Vector3.Lerp(transform.forward, aimDirection, Time.deltaTime * 20f);

            isAimming = true;
        }
        else
        {
            aimVirtualCamera.gameObject.SetActive(false);
            thirdPersonController.SetSensitivity(normalSensitivity);
            thirdPersonController.SetRotateOnMove(true);

            carryRifle.gameObject.SetActive(true);
            holderRifle.gameObject.SetActive(false);

            animator.SetLayerWeight(1, Mathf.Lerp(animator.GetLayerWeight(1), 0f, Time.deltaTime * 10f));

            isAimming = false;
        }


        if (starterAssetsInputs.shoot)
        {
            if (!isAimming) return;

            if (thirdPersonController._ammo > 0)
            {
                fireSound.Play();
                thirdPersonController._ammo -= 1;
                thirdPersonController.slider.SetAmmo(thirdPersonController._ammo);

                Vector3 aimDir = (mouseWorldPosition - spawnBulletPosition.position).normalized;
                Instantiate(pBulletProjectile, spawnBulletPosition.position, Quaternion.LookRotation(aimDir, Vector3.up));
                starterAssetsInputs.shoot = false;
            }
        }

    }

}
