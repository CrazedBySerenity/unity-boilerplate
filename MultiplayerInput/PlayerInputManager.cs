using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputHandler : MonoBehaviour
{
    private Vector2 moveInput;

    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Debug.Log($"Player {GetComponent<PlayerInput>().playerIndex} jumped");
        }
    }

    private void Update()
    {
        if (moveInput != Vector2.zero)
        {
            transform.Translate(moveInput * Time.deltaTime * 5f);
        }
    }
}