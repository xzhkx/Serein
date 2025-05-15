using UnityEngine;

public class FreezePlayerControl : MonoBehaviour
{
    [SerializeField]
    private CameraMovement cameraMovement;

    [SerializeField]
    private CameraRotation cameraRotation;

    private PlayerMovement playerMovement;

    private Rigidbody playerRigidbody;
    private PlayerAnimatorControl playerAnimatorControl;

    private PlayerAttack playerAttack;
    private bool attackUnlocked = false;

    private void Awake()
    {
        playerMovement = GetComponent<PlayerMovement>();
        playerAttack = GetComponent<PlayerAttack>();
        playerRigidbody = GetComponent<Rigidbody>();
        playerAnimatorControl = GetComponent<PlayerAnimatorControl>();
    }

    public void UnlockAttack()
    {
        attackUnlocked = true;
    }

    private void Start()
    {
        DialogueManager.Instance.FreezePlayerAction += FreezePlayerMovement;
        DialogueManager.Instance.EnablePlayerAction += EnablePlayerMovement;
    }

    private void OnDisable()
    {
        DialogueManager.Instance.FreezePlayerAction -= FreezePlayerMovement;
        DialogueManager.Instance.EnablePlayerAction -= EnablePlayerMovement;
    }

    private void FreezePlayerMovement()
    {
        cameraMovement.enabled = false;
        cameraRotation.enabled = false;

        if (attackUnlocked)
        {
            playerAttack.enabled = false;
        }

        playerMovement.enabled = false;
        playerRigidbody.isKinematic = true;
        playerAnimatorControl.SetIdle(true);
    }

    private void EnablePlayerMovement()
    {
        cameraMovement.enabled = true;
        cameraRotation.enabled = true;
        playerMovement.enabled = true;
        playerRigidbody.isKinematic = false;
        if (attackUnlocked)
        {
            playerAttack.enabled = true;
        }
    }
}
