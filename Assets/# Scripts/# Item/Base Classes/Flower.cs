using UnityEngine;
using UnityEngine.Tilemaps;

public class Flower : Item
{
    [SerializeField] private string FlowerName;
    [SerializeField] private string FlowerDesc;
    [SerializeField] private string TypeOfFlower;
    [SerializeField] private Sprite FlowerImage;
    [SerializeField] private Tile FlowerTile;

    public override ItemData ItemPickedUp() 
    {
        ItemData flowerData = new ItemData(FlowerName, FlowerDesc, gameObject.GetComponent<SpriteRenderer>().sprite, this, FlowerTile, TypeOfFlower);
        return flowerData;
    }

    public override void ApplyDetailsToItem(ItemData? itemData)
    {
        // Applying scale for debugging
        gameObject.transform.localScale = new Vector3(0.08f, 0.08f, 1);
       
        // Loading Values from ItemData
        FlowerName = itemData?._Name;
        FlowerDesc = itemData?._Description;
        TypeOfFlower = itemData?._FlowerType;
        FlowerImage = itemData?._ImageSprite;


        // Applying Values
        gameObject.GetComponent<SpriteRenderer>().sprite = FlowerImage;
        gameObject.GetComponent<SpriteRenderer>().sortingOrder = 1;
        gameObject.layer = 6;
        gameObject.name = FlowerName;

    }
}
