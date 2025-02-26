using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerJump : MonoBehaviour
{
    [SerializeField] private float jumpForce;

    private PlayerAnimatorControl playerAnimatorControl;
    private Rigidbody playerRigidbody;
    private float groundCheckDistance;
    private bool isJump;

    private void Awake()
    {
        playerRigidbody = GetComponent<Rigidbody>();
        playerAnimatorControl = GetComponent<PlayerAnimatorControl>();

        groundCheckDistance = GetComponent<CapsuleCollider>().height / 2 + 0.1f;

        isJump = false;
    }

    private void Update()
    {
        float velocityY = playerRigidbody.velocity.y;
        playerAnimatorControl.SetVelocityY(velocityY); 
    }

    private void Start()
    {
        GetComponent<PlayerInput>().GetPlayerInputAction().Player.Jump.performed += Jump;
    }

    private void FixedUpdate()
    {
        HitGroundCheck();
    }

    private void HitGroundCheck()
    {
        RaycastHit rayCastHit;
        if (Physics.Raycast(transform.position, Vector3.down, out rayCastHit, groundCheckDistance))
        {
            playerAnimatorControl.SetGrounded(true);
            isJump = false;
        }
        else
        {
             isJump = true;
        }
    }

    private void Jump(InputAction.CallbackContext context)
    {
        if (isJump) return;
        playerRigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        playerAnimatorControl.SetGrounded(false);
    }
}
