using UnityEngine;

public class FlowerInFlowerPot : Item, IHarvestable
{
    [Header("Item Harvesting Properties")]
    [SerializeField] private ItemBluePrint itemHarvestedOff;
    [SerializeField] private GameObject mainItemAfterHarvest;

    public ItemBluePrint HarvestItem()
    {
        TileManager.Instance.ReplaceItems(gameObject.transform.position, this.gameObject, mainItemAfterHarvest);
        return itemHarvestedOff;
    }
}
