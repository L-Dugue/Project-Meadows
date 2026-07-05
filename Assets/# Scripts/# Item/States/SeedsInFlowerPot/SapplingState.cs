using System.Collections;
using UnityEngine;

public class SapplingState : FlowerPotWithSeedsBaseState
{
    public override void EnterState(FlowerPotWithSeeds flowerpot)
    {
        Debug.Log("Entered Sappling State");
        //TileManager.ChangeTileSpriteTo(flowerpot.SemiGrownFlower, flowerpot.transform);
        TileManager.RefreshTileAtPos(flowerpot.transform);
        flowerpot.StartCoroutine(GrowTime(flowerpot));
    }
    public override IEnumerator GrowTime(FlowerPotWithSeeds flowerpot)
    {
        yield return new WaitForSeconds(4f);
        flowerpot.SwitchState(flowerpot.fullyGrownState);
    }
    public override void ExitState(FlowerPotWithSeeds flowerpot)
    {

    }
}
