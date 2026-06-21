using UnityEngine;
using UnityEngine.Tilemaps;

public abstract class Item : MonoBehaviour
{
    [Header("Variables for ItemData")]
    [SerializeField] protected string ItemName;
    [SerializeField] protected string ItemDesc;
    [SerializeField] protected string ItemRarity;
    [SerializeField] protected int ItemPrice;
    [SerializeField] protected Tile ItemTile;

    public abstract ItemData ReturnItemData();

    //public abstract void ApplyDetailsToItem(ItemData? itemDetails);
    // public abstract void ReadItemDesc();
}
