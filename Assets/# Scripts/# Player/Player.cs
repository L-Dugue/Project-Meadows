using UnityEngine;
using UnityEngine.InputSystem;

public class Player : Character
{
    // Private Var
    private Vector2 mousePos;

    // Public Properties
    public Vector2 MousePos { get { return mousePos; } }

    void FixedUpdate()
    {
        MoveCharacter();
        FlipSprite(moveInput.x);
    }

    public void OnMove(InputAction.CallbackContext context) 
    {
        moveInput = context.ReadValue<Vector2>();
    }

    public void OnInteract(InputAction.CallbackContext context) 
    {
        if (context.started) 
        {
            playerInteraction.PerformPickingUpItem();
        }
        
    }

    public void OnUICursorPos(InputAction.CallbackContext context)
    {
        mousePos = context.ReadValue<Vector2>();
    }

    public void OnPrintOutContentsDEBUGGING(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            playerInteraction.DEBUGGER();
        }

    }

    public override void MoveCharacter()
    {
        moveInput = moveInput.normalized;
        rigidBody.linearVelocity = new Vector2(moveInput.x * Speed, moveInput.y * Speed);
    }
}
