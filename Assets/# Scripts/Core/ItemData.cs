using UnityEngine;

// MAKE A STRUCT
[System.Serializable]
public struct ItemData
{
    // Fields
    public readonly Sprite _ImageSprite; // Image to Render in Inventory
    public readonly string _Name; // Name of the Item
    public readonly string _Description; // Description of the Item
    public readonly string _FlowerType;
    public readonly Item itemDataType;

    /// <summary>
    /// Full Param Constructor, used for Flower
    /// </summary>
    /// <param name="itemName"></param>
    /// <param name="itemDesc"></param>
    /// <param name="itemSprite"></param>
    /// <param name="flowerType"></param>
    public ItemData(string itemName, string itemDesc, Sprite itemSprite, Item item, string flowerType) 
    {
        _ImageSprite = itemSprite;
        _Name = itemName;
        _Description = itemDesc;
        _FlowerType = flowerType;
        itemDataType = item;
    }

    /// <summary>
    /// Without FlowerType param Constructor, used for any other item
    /// </summary>
    /// <param name="itemName"></param>
    /// <param name="itemDesc"></param>
    /// <param name="itemSprite"></param>
    /// <param name="flowerType"></param>
    public ItemData(string itemName, string itemDesc, Item item, Sprite itemSprite)
    {
        _ImageSprite = itemSprite;
        _Name = itemName;
        _Description = itemDesc;
        itemDataType = item;
        _FlowerType = null;
    }




}
