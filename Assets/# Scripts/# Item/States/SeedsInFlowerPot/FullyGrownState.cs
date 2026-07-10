using System.Collections;
using UnityEngine;

public class FullyGrownState : FlowerPotWithSeedsBaseState
{
    public override void EnterState(FlowerPotWithSeeds flowerpot)
    {
        Debug.Log("Entered Fully GrownState");
        flowerpot.StartCoroutine(GrowTime(flowerpot));
    }
    public override IEnumerator GrowTime(FlowerPotWithSeeds flowerpot)
    {
        yield return null;
        ExitState(flowerpot);
    }
    public override void ExitState(FlowerPotWithSeeds flowerpot)
    {
        TileManager.Instance.ReplaceItems(flowerpot.transform.position, flowerpot.gameObject, flowerpot.FullyGrownFlower);
    }
}
