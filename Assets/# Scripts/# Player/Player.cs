// Socket smells

using UnityEngine;
using UnityEngine.InputSystem;


public class Player : Character
{
    // Private Var
    private Vector2 mousePos;
    private int _maxGems = 999;


    // Public Properties
    public Vector2 MousePos { get { return mousePos; } }
    

    void FixedUpdate()
    {
        // Checks to see if the Player is in dialogue.
        if (DialogueManager.Instance.DialogueOn && (rigidBody.linearVelocity.x != 0 || rigidBody.linearVelocity.y != 0))
        {
            rigidBody.linearVelocity = Vector2.zero;
            return;
        }
        else if(DialogueManager.Instance.DialogueOn)
        {
            
            return;
        }


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

    public void OnHarvest(InputAction.CallbackContext context) 
    {
        if (context.started) 
        {
            playerInteraction.HarvestItem();
        }
    }

   

    public override void MoveCharacter()
    {
        moveInput = moveInput.normalized;
        rigidBody.linearVelocity = new Vector2(moveInput.x * Speed, moveInput.y * Speed);
    }
}
