using System;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.Tilemaps;


public class PlayerInventory : MonoBehaviour
{
    // Events
    public delegate void ItemAddedToInventory(int indexAddedAt, ItemData? item);
    public static event ItemAddedToInventory OnItemAddedToInventory;

    // Create Nullable Array for Items, with 4 slots
    private ItemData?[] _items = new ItemData?[4];

    // Private Members
    private bool isInventoryFull = false;
    private bool isInventoryIsEmpty = true;

    [Header("TileSet Settings")]
    // Serialized Fields
    [SerializeField] private Tilemap worldTileMap;



    private void Awake()
    {
        InventoryUI.RemoveItemFromInventory += RemoveItemFromInventory;
    }


    public bool AddItemToInventory(ItemData itemPickedUp)
    {

        Debug.Log($"Added {itemPickedUp.GetType().Name} to Inventory\n");

        if (isInventoryIsEmpty)
        {
            _items[0] = itemPickedUp;
            isInventoryIsEmpty = false;
            OnItemAddedToInventory?.Invoke(0, _items[0]);
            return true;
        }
        if(!isInventoryFull)
        {
           for(int index = 0; index < _items.Length; index++) 
           {
                if (_items[index] == null) 
                {
                    _items[index] = itemPickedUp;
                    isInventoryFull = (index == _items.Length - 1);
                    OnItemAddedToInventory?.Invoke(index, _items[index]);
                    return true;
                }
           }
        }


        Debug.Log("Inventory is full!");
        return false;
    }


    public void RemoveItemFromInventory(int index, Vector2 mousePos)
    {
        if (isInventoryIsEmpty) { return; }

        var typeOfItem = _items[index]?._ItemDataType;
        //GameObject removedItemObj = new GameObject(_items[index]?._Name, typeOfItem.GetType());
        PlacingFlowerOnTileMap(_items[index]?._ItemTile, mousePos);

        // Remove Item from Inventory Array
        _items[index] = null;

        isInventoryFull = _items.All(i => i != null);

    }

    /// <summary>
    /// DEPRECATED!
    /// </summary>
    public void PrintOutContentsOfInventoryDEBUGGING() 
    {
        for (int index = 0; index < _items.Length; index++)
        {
            if (_items[index] == null) { continue; }
            Debug.Log($"Name: {_items[index]?._Name}, Desc: {_items[index]?._Description}, Type Of Flower: {_items[index]?._FlowerType}");
        }
    }
   

    private void PlacingFlowerOnTileMap(Tile itemTile, Vector2 mousePos) 
    {
        Vector3 mousePosInWorldSpace = Camera.main.ScreenToWorldPoint(mousePos); // Takes mousePos from Screen space to World Space
        Vector3Int cellPos = worldTileMap.WorldToCell(mousePosInWorldSpace); // Finds the grid which matches the position
        worldTileMap.SetTile(cellPos, itemTile); // Puts the item on that grid
    }

}
