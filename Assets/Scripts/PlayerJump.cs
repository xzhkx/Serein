using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerJump : MonoBehaviour
{
    [SerializeField] private float jumpForce;

    private PlayerAnimatorControl playerAnimatorControl;
    private Rigidbody playerRigidbody;

    private void Awake()
    {
        playerRigidbody = GetComponent<Rigidbody>();
        playerAnimatorControl = GetComponent<PlayerAnimatorControl>();
    }

    private void Update()
    {
        playerAnimatorControl.SetVelocityY(playerRigidbody.velocity.y); 
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
        if (Physics.Raycast(transform.position, Vector3.down, out rayCastHit))
        {
            if (!rayCastHit.collider.CompareTag("Ground")) return;
            playerAnimatorControl.SetGrounded(true);
        }
    }

    private void Jump(InputAction.CallbackContext context)
    {
        playerRigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        playerAnimatorControl.SetGrounded(false);
    }
}
