using UnityEngine;
using UnityEngine.Tilemaps;

public class Seeds : Item
{
    [Header("Seeds in Pots")]
    [SerializeField] private GameObject _seedsInFlowerPotObj;
    [SerializeField] private Tile _seedsInFlowerPotTile;

    // Properties
    public GameObject SeedsInFlowerPotObj { get { return _seedsInFlowerPotObj; } }
    public Tile SeedsInFlowerPotTile { get { return _seedsInFlowerPotTile; } }

    //public override ItemData ReturnItemData()
    //{
    //    ItemData seedItem = new ItemData(base.ItemName, base.ItemDesc, gameObject.GetComponent<SpriteRenderer>().sprite, this, base.ItemObj, base.ItemRarity, base.ItemPrice);
    //    return seedItem;
    //}

   
}
