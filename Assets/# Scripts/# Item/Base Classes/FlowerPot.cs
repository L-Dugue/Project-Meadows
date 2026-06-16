using UnityEngine;
using UnityEngine.Tilemaps;

public class FlowerPot : Item
{
    [SerializeField] private string FlowerPotName;
    [SerializeField] private string FlowerPotDesc;
    [SerializeField] private Tile FlowerPotTile;

    public override ItemData ItemPickedUp()
    {
        ItemData flowerData = new ItemData(FlowerPotName, FlowerPotDesc, this, FlowerPotTile, gameObject.GetComponent<SpriteRenderer>().sprite);
        return flowerData;
    }
}
