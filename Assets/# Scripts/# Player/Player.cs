// Socket smells

using UnityEngine;
using UnityEngine.InputSystem;


public class Player : Character
{
    // Serialized Fields
    [SerializeField] private int playerGems;

    // Private Var
    private Vector2 mousePos;
    private int _maxGems = 999;

    // Debugging Properties
    public MarketInteraction DEBUGVAR_OPENUPSELLUI;

    // Public Properties
    public Vector2 MousePos { get { return mousePos; } }
    public int PlayerGems { get { return playerGems; } set { playerGems = Mathf.Clamp(value, 0, _maxGems);  } }

    void FixedUpdate()
    {
        MoveCharacter();
        FlipSprite(moveInput.x);
        Debug.Log(playerGems);
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

    public void UpdatePlayerGems(int amount)
    { 
        playerGems -= amount;
        Debug.Log(PlayerGems);
    }
}
