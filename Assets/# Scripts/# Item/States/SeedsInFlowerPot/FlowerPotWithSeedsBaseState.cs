using UnityEngine;
using System.Collections;


public abstract class FlowerPotWithSeedsBaseState
{
    public abstract void EnterState(FlowerPotWithSeeds flowerpot);
    public abstract IEnumerator GrowTime(FlowerPotWithSeeds flowerpot);
    public abstract void ExitState(FlowerPotWithSeeds flowerpot);
}
