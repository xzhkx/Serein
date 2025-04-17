using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public static PlayerInput Instance;
    private PlayerInputAction playerInputActions;

    private void Awake()
    {
        Instance = this;
        playerInputActions = new PlayerInputAction();
        EnablePlayerInputActions();
    }

    public PlayerInputAction GetPlayerInputAction()
    {
        return playerInputActions; 
    }

    public Vector2 GetPlayerMovementInput()
    {
        return playerInputActions.Player.Movement.ReadValue<Vector2>().normalized;
    }

    public void EnablePlayerInputActions()
    {
        playerInputActions.Enable();
    }

    public bool GetInteractPressed()
    {
        if (playerInputActions.Player.DialogueInteract.triggered) return true;
        return false;
    }
}
