using System.Collections;
using UnityEngine;

public class SeedState : FlowerPotWithSeedsBaseState
{
    public override void EnterState(FlowerPotWithSeeds flowerpot)
    {
        Debug.Log("Entered Seed State");
        flowerpot.StartCoroutine(GrowTime(flowerpot));
    }
    public override IEnumerator GrowTime(FlowerPotWithSeeds flowerpot)
    {
        yield return new WaitForSeconds(2f);
        flowerpot.SwitchState(flowerpot.sapplingState);
    }
    public override void ExitState(FlowerPotWithSeeds flowerpot)
    {
    }
}
