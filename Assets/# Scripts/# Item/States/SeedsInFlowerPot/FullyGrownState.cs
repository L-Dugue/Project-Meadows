using System.Collections;
using UnityEngine;

public class FullyGrownState : FlowerPotWithSeedsBaseState
{
    public override void EnterState(FlowerPotWithSeeds flowerpot)
    {
        Debug.Log("Entered Fully GrownState");
        //TileManager.ChangeTileSpriteTo(flowerpot.FullyGrownFlower, flowerpot.transform);
        //TileManager.RefreshTileAtPos(flowerpot.transform);
        flowerpot.StartCoroutine(GrowTime(flowerpot));
    }
    public override IEnumerator GrowTime(FlowerPotWithSeeds flowerpot)
    {
        yield return null;
        ExitState(flowerpot);
        //flowerpot.SwitchState(flowerpot.fullyGrownState);
    }
    public override void ExitState(FlowerPotWithSeeds flowerpot)
    {

    }
}
