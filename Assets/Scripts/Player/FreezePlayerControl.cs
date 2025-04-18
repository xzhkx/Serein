using UnityEngine;

public class FreezePlayerControl : MonoBehaviour
{
    [SerializeField] private CameraMovement cameraMovement;
    [SerializeField] private CameraRotation cameraRotation;
    private PlayerMovement playerMovement;
    private PlayerJump playerJump;
    private PlayerAttack playerAttack;
    private Rigidbody playerRigidbody;
    private PlayerAnimatorControl playerAnimatorControl;

    private void Awake()
    {
        playerMovement = GetComponent<PlayerMovement>();
        playerJump = GetComponent<PlayerJump>();
        playerAttack = GetComponent<PlayerAttack>();
        playerRigidbody = GetComponent<Rigidbody>();
        playerAnimatorControl = GetComponent<PlayerAnimatorControl>();
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
        playerAttack.enabled = false;
        playerMovement.enabled = false;
        playerJump.enabled = false;
        playerRigidbody.isKinematic = true;
        playerAnimatorControl.SetIdle(true);
    }

    private void EnablePlayerMovement()
    {
        cameraMovement.enabled = true;
        cameraRotation.enabled = true;
        playerMovement.enabled = true;
        playerJump.enabled = true;
        playerRigidbody.isKinematic = false;
        playerAttack.enabled = true;
    }
}
