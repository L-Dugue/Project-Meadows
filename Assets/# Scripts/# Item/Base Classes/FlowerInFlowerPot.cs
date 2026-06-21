using UnityEngine;

public class FlowerInFlowerPot : Item
{
    public override ItemData ReturnItemData()
    {
        ItemData flowerpot = new ItemData(base.ItemName, base.ItemDesc, gameObject.GetComponent<SpriteRenderer>().sprite, this, base.ItemTile, base.ItemRarity, base.ItemPrice);
        return flowerpot;
    }
}
