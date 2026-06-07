using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public abstract class Character : MonoBehaviour
{

    // Public Fields
    [HideInInspector] public Rigidbody2D rigidBody;
    [HideInInspector] public Vector2 moveInput;

    // Private Fields
    [SerializeField] private float m_speed;

    // Protected Fields
    [SerializeField] protected bool facesLeftByDefault = false;
    [SerializeField] protected PlayerInteraction playerInteraction;

    // Properties
    public float Speed { get { return m_speed; } }



    protected virtual void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }


    /// <summary>
    /// Flips the Character Horizontally depending on their Horizontal Velocity.
    /// </summary>
    /// <param name="horizontalVelocity">The horizontal velocity of the character in World Space</param>
    protected void FlipSprite(float horizontalVelocity) 
    {
        if(Mathf.Abs(horizontalVelocity) > 0.1f) 
        {
            Vector2 objScale = gameObject.transform.localScale;
            float directionToFace = horizontalVelocity > 0 ? Mathf.Abs(objScale.x) : -Mathf.Abs(objScale.x);
            objScale.x = facesLeftByDefault ? (directionToFace * -1f) : directionToFace;

            gameObject.transform.localScale = objScale;
        }
    }

    

    // Abstract Methods
    public abstract void MoveCharacter();
}
