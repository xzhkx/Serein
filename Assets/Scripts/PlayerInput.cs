using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private PlayerInputAction playerInputActions;

    private void Awake()
    {
        playerInputActions = new PlayerInputAction();
        EnablePlayerInputActions();
    }

    public Vector2 GetPlayerMovementInput()
    {
        return playerInputActions.Player.Movement.ReadValue<Vector2>().normalized;
    }

    public void EnablePlayerInputActions()
    {
        playerInputActions.Enable();
    }
}
