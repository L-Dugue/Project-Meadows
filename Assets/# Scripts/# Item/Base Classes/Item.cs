using UnityEngine;
using UnityEngine.Tilemaps;

public abstract class Item : MonoBehaviour
{
    [SerializeField] private ItemBluePrint _itemBluePrint;
    public ItemBluePrint itemBluePrint { get { return _itemBluePrint; }


    //[Header("Variables for ItemData")]
    //[SerializeField] protected string ItemName;
    //[SerializeField] protected string ItemDesc;
    //[SerializeField] protected string ItemRarity;
    //[SerializeField] protected int ItemPrice;
    //[SerializeField] protected GameObject ItemObj;

    //public abstract ItemData ReturnItemData();

    //public abstract void ApplyDetailsToItem(ItemData? itemDetails);
    // public abstract void ReadItemDesc();
}}
