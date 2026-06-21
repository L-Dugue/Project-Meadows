using UnityEngine;
using UnityEngine.Tilemaps;

public class FlowerPot : Item
{
    [SerializeField] private string FlowerPotName;
    [SerializeField] private string FlowerPotDesc;
    [SerializeField] private string ItemRarity;
    [SerializeField] private int FlowerPotPrice;
    [SerializeField] private Tile FlowerPotTile;


    public override ItemData ReturnItemData()
    {
        ItemData itemData = new ItemData(FlowerPotName, FlowerPotDesc, GetComponent<SpriteRenderer>().sprite, this, FlowerPotTile, ItemRarity, FlowerPotPrice);
        return itemData;
    }
}
