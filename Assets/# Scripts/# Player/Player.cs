// Socket smells

using UnityEngine;
using UnityEngine.InputSystem;


public class Player : Character
{
   

    // Private Var
    private Vector2 mousePos;
    private int _maxGems = 999;

    // Debugging Properties
    public MarketInteraction DEBUGVAR_OPENUPSELLUI;

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
            playerInteraction.Interact();
            
        }
        
    }

    public void OnUICursorPos(InputAction.CallbackContext context)
    {
        mousePos = context.ReadValue<Vector2>();
    }

    public void OnDebug(InputAction.CallbackContext context) 
    {
        if (context.started) 
        {
            DEBUGVAR_OPENUPSELLUI.EnterSellMarketDEBUG();
        }
    }

   

    public override void MoveCharacter()
    {
        moveInput = moveInput.normalized;
        rigidBody.linearVelocity = new Vector2(moveInput.x * Speed, moveInput.y * Speed);
    }
}
