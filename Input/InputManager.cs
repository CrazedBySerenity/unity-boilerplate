using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    public static InputManager Instance { get; private set; }

    private PlayerInputActions input;

    public Vector2 MoveInput { get; private set; }
    public bool JumpPressed => input.Player.Jump.triggered;
    public bool InteractPressed => input.Player.Interact.triggered;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        input = new PlayerInputActions();
        input.Enable();

        input.Player.Move.performed += ctx => MoveInput = ctx.ReadValue<Vector2>();
        input.Player.Move.canceled += _ => MoveInput = Vector2.zero;
    }

    private void OnDestroy()
    {
        input.Disable();
    }
}
