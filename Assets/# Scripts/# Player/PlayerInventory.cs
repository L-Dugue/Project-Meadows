using System;
using System.Collections.Generic;
using System.Linq;
using Unity.Mathematics;
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

    [Header("Tilemap Placement Settings")]
    [SerializeField] private Tilemap pickupTileMap;
    [SerializeField] private float placementRange;
    [SerializeField] private Player player;
    [SerializeField] private Tilemap tileMapWhichIsPlaceable;

    [Header("Placeable Tiles Lists")]
    [SerializeField] private PlaceableTilesList flowerPlaceableTiles;



    private void Awake()
    {
        InventoryUI.RemoveItemFromInventory += RemoveItemFromInventory;
    }


    public bool AddItemToInventory(ItemData itemPickedUp)
    {

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
        if (isInventoryIsEmpty) { return; } // Does nothing if Inventory is empty.

        // Mouse is outside placement range and is a valid tile.
        if (IsOnValidPlaceableTile(index) && IsMouseInPlacementRange())
        {
            var typeOfItem = _items[index]?._ItemDataType;
            PlacingFlowerOnTileMap(_items[index]?._ItemTile, mousePos);

            // Remove Item from Inventory Array
            _items[index] = null;
            isInventoryFull = _items.All(i => i != null);
        } 
    }

    //

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

    /// <summary>
    /// Used outside of PlayerInventory class to check if the item can be placed.
    /// </summary>
    /// <param name="index"></param>
    /// <returns></returns>
    public bool CheckIfPlaceable(int index) 
    {
        if(IsMouseInPlacementRange() && IsOnValidPlaceableTile(index)) 
        {
            return true;
        }
        return false;
    }

    private void PlacingFlowerOnTileMap(Tile itemTile, Vector2 mousePos) 
    {
        Vector3 mousePosInWorldSpace = Camera.main.ScreenToWorldPoint(mousePos); // Takes mousePos from Screen space to World Space
        Vector3Int cellPos = pickupTileMap.WorldToCell(mousePosInWorldSpace); // Finds the grid which matches the position
        pickupTileMap.SetTile(cellPos, itemTile); // Puts the item on that grid
    }

    private bool IsMouseInPlacementRange()
    {
        Vector2 mouseInWorldSpace = Camera.main.ScreenToWorldPoint(player.MousePos);
        if(Mathf.Pow((mouseInWorldSpace.x - transform.position.x), 2) + Mathf.Pow((mouseInWorldSpace.y - transform.position.y), 2) < Mathf.Pow(placementRange, 2)) 
        {
            return true;
        }
        else 
        {
            return false;
        }
    }

    private bool IsOnValidPlaceableTile(int index)
    {
        
        Vector2 mouseInWorldSpace = Camera.main.ScreenToWorldPoint(player.MousePos);
        Vector3Int cellPos = pickupTileMap.WorldToCell(mouseInWorldSpace);

        switch (_items[index]?._ItemDataType)
        {
            case Flower:
                if (flowerPlaceableTiles.PlaceableTiles.Contains(tileMapWhichIsPlaceable.GetTile(cellPos)) && pickupTileMap.GetTile(cellPos) == null)
                {
                    
                    return true;

                }
                else
                {
                    return false;
                }
                
            case FlowerPot:
                if(pickupTileMap.GetTile(cellPos) == null)
                {
                    Debug.Log("PLACING");
                    return true;
                }
                else 
                {
                    return false;
                }

            default: return false;
        }


    }


    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, placementRange);
    }
}
