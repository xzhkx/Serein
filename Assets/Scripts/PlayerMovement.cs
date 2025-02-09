using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float walkSpeed, runSpeed, turnSmoothTime, turnSmoothVelocity;

    private PlayerInput playerInput;
    private Rigidbody playerRigidbody;

    private void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();   
        playerInput = GetComponent<PlayerInput>();
    }

    private void FixedUpdate()
    {
        Vector2 movementInput = playerInput.GetPlayerMovementInput();
        Vector3 movementDirection = new Vector3(movementInput.x, 0, movementInput.y);

        playerRigidbody.AddForce(movementDirection * runSpeed * Time.fixedDeltaTime, ForceMode.Impulse);

        if(movementInput != Vector2.zero)
        {
            float targetAngle = Mathf.Atan2(movementDirection.x, movementDirection.z) * Mathf.Rad2Deg;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0, angle, 0);
        }
    }
}
