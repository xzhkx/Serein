using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private Transform cameraTransform;

    [SerializeField]
    private float walkSpeed, runSpeed, turnSmoothTime;

    private float turnSmoothVelocity;

    private PlayerAnimatorControl playerAnimatorControl;
    private PlayerInput playerInput;
    private Rigidbody playerRigidbody;

    private void Start()
    {
        playerInput = GetComponent<PlayerInput>();

        playerRigidbody = GetComponent<Rigidbody>();
        playerAnimatorControl = GetComponent<PlayerAnimatorControl>();
    }

    private void FixedUpdate()
    {
        Vector2 movementInput = playerInput.GetPlayerMovementInput();

        Vector3 xDirection = cameraTransform.right;
        xDirection.y = 0f;
        Vector3 zDirection = cameraTransform.forward;
        zDirection.y = 0f;
        Vector3 yDirection = new Vector3(0, -9.18f, 0);

        Vector3 direction = xDirection * movementInput.x * runSpeed + zDirection * movementInput.y * runSpeed
            + yDirection;

        playerRigidbody.velocity = direction;

        if (movementInput != Vector2.zero)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
            float angle = Mathf.SmoothDampAngle(transform.localEulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);

            playerAnimatorControl.SetIdle(false);
            transform.localRotation = Quaternion.Euler(0, angle, 0);
        }
        else playerAnimatorControl.SetIdle(true);
    }
}
