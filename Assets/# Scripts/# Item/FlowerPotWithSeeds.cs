using UnityEngine;
using UnityEngine.Tilemaps;

public class FlowerPotWithSeeds : FlowerPot
{
    [Header("Flower Stages")]
    [SerializeField] private Sprite _semiGrownFlower;
    [SerializeField] private GameObject _fullyGrownFlower;

    
    // --- State Pattern Variables ---
    public FlowerPotWithSeedsBaseState currentState;

    // Concrete state instances
    public FullyGrownState fullyGrownState = new FullyGrownState();
    public SapplingState sapplingState = new SapplingState();
    public SeedState seedState = new SeedState();

    // Public Properties
    public Sprite SemiGrownFlower { get { return _semiGrownFlower; } }
    public GameObject FullyGrownFlower { get { return _fullyGrownFlower; } }


    private void Start()
    {
        SwitchState(seedState);
    }

    public void SwitchState(FlowerPotWithSeedsBaseState newState)
    {
        // SWITCH STATE LOGIC
        // Clean up the current state before leaving.
        if (currentState != null)
        {
            currentState.ExitState(this);
        }

        currentState = newState;
        currentState.EnterState(this);
    }
}
