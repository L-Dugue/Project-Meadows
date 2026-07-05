using UnityEngine;
using UnityEngine.Tilemaps;

public class Flower : Item
{
    [Header("Variant of Flower In Pots")]
    [SerializeField] private GameObject _flowerInFlowerPot;
    [SerializeField] private GameObject _flowerInTeaCup;

    // Properties
    public GameObject FlowerInFlowerPot { get { return _flowerInFlowerPot;  }   }
    public GameObject FlowerInTeaCup { get { return _flowerInTeaCup; } }




    //public override ItemData ReturnItemData()
    //{
    //    ItemData flowerData = new ItemData(base.ItemName, base.ItemDesc, gameObject.GetComponent<SpriteRenderer>().sprite, this, base.ItemObj, base.ItemRarity, base.ItemPrice);
    //    return flowerData;
    //}


    //public override void ApplyDetailsToItem(ItemData? itemData)
    //{
    //    // Applying scale for debugging
    //    gameObject.transform.localScale = new Vector3(0.08f, 0.08f, 1);

    //    // Loading Values from ItemData
    //    FlowerName = itemData?._Name;
    //    FlowerDesc = itemData?._Description;
    //    TypeOfFlower = itemData?._FlowerType;
    //    FlowerImage = itemData?._ImageSprite;


    //    // Applying Values
    //    gameObject.GetComponent<SpriteRenderer>().sprite = FlowerImage;
    //    gameObject.GetComponent<SpriteRenderer>().sortingOrder = 1;
    //    gameObject.layer = 6;
    //    gameObject.name = FlowerName;

    //}
}
