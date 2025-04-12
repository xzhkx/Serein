using UnityEngine;

public class FreezePlayerControl : MonoBehaviour
{
    [SerializeField] private CameraMovement cameraMovement;
    [SerializeField] private CameraRotation cameraRotation;
    private PlayerMovement playerMovement;
    private PlayerJump playerJump;
    private PlayerAttack playerAttack;

    private void Awake()
    {
        playerMovement = GetComponent<PlayerMovement>();
        playerJump = GetComponent<PlayerJump>();
        playerAttack = GetComponent<PlayerAttack>();
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
    }

    private void EnablePlayerMovement()
    {
        cameraMovement.enabled = true;
        cameraRotation.enabled = true;
        playerMovement.enabled = true;
        playerJump.enabled = true;
        playerAttack.enabled = true;
    }
}
