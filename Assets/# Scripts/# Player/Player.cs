using UnityEngine;
using UnityEngine.InputSystem;

public class Player : Character
{
    

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
