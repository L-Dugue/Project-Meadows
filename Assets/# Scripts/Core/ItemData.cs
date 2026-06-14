using UnityEngine;
using UnityEngine.Tilemaps;

// MAKE A STRUCT
[System.Serializable]
public struct ItemData
{
    // Fields
    public readonly Sprite _ImageSprite; // Image to Render in Inventory
    public readonly string _Name; // Name of the Item
    public readonly string _Description; // Description of the Item
    public readonly string _FlowerType;
    public readonly Tile _ItemTile;
    public readonly Item _ItemDataType;
    

    /// <summary>
    /// Full Param Constructor, used for Flower
    /// </summary>
    /// <param name="itemName"></param>
    /// <param name="itemDesc"></param>
    /// <param name="itemSprite"></param>
    /// <param name="flowerType"></param>
    public ItemData(string itemName, string itemDesc, Sprite itemSprite, Item item, Tile itemTile, string flowerType) 
    {
        _ImageSprite = itemSprite;
        _Name = itemName;
        _Description = itemDesc;
        _FlowerType = flowerType;
        _ItemDataType = item;
        _ItemTile = itemTile;
    }

    /// <summary>
    /// Without FlowerType param Constructor, used for any other item
    /// </summary>
    /// <param name="itemName"></param>
    /// <param name="itemDesc"></param>
    /// <param name="itemSprite"></param>
    /// <param name="flowerType"></param>
    public ItemData(string itemName, string itemDesc, Item item, Tile itemTile, Sprite itemSprite)
    {
        _ImageSprite = itemSprite;
        _Name = itemName;
        _Description = itemDesc;
        _ItemDataType = item;
        _ItemTile = itemTile;
        _FlowerType = null;
    }




}
