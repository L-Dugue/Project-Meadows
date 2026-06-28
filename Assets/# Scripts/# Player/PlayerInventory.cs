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
    [SerializeField] private PlaceableTilesList flowerPotTiles;

    // Public Properties
    public ItemData?[] Items {  get { return _items; } }


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

    /// <summary>
    /// Remove Item from Inventory, placing it on the ground.
    /// </summary>
    /// <param name="index"></param>
    /// <param name="mousePos"></param>
    public void RemoveItemFromInventory(int index, Vector2 mousePos)
    {
        if (isInventoryIsEmpty) { return; } // Does nothing if Inventory is empty.

        // Mouse is outside placement range and is a valid tile.
        if (IsOnValidPlaceableTile(index) && IsMouseInPlacementRange())
        {
            Vector3 mousePosInWorldSpace = Camera.main.ScreenToWorldPoint(mousePos); // Takes mousePos from Screen space to World Space
            Vector3Int cellPos = pickupTileMap.WorldToCell(mousePosInWorldSpace);
            var typeOfItem = _items[index]?._ItemDataType;

            if ( (typeOfItem is Flower flower) && flowerPotTiles.PlaceableTiles.Contains(pickupTileMap.GetTile(cellPos)))
            {

                // Checks if its a teacup or ordinary flowerpot
                if (flowerPotTiles.PlaceableTiles[0] == pickupTileMap.GetTile(cellPos))
                {
                    PlacingItemOnTileMap(flower.FlowerInFlowerPot, mousePos);
                }
                else if (flowerPotTiles.PlaceableTiles[1] == pickupTileMap.GetTile(cellPos))
                {
                    PlacingItemOnTileMap(flower.FlowerInTeaCup, mousePos);
                }

                // Remove Item from Inventory Array
                _items[index] = null;
                isInventoryFull = _items.All(i => i != null);
            }

            // Places the Seeds within a FlowerPot.
            else if((typeOfItem is Seeds seed) && flowerPotTiles.PlaceableTiles.Contains(pickupTileMap.GetTile(cellPos)))
            {
                if (flowerPotTiles.PlaceableTiles[0] == pickupTileMap.GetTile(cellPos))
                {
                    // Places the gameobject in the world, unabled to use the Tile GameObject Instiation.
                    seed.SeedsInFlowerPotTile.gameObject = seed.SeedsInFlowerPotObj;
                    PlacingItemOnTileMap(seed.SeedsInFlowerPotTile, mousePos);
                }

                // Remove Item from Inventory Array
                _items[index] = null;
                isInventoryFull = _items.All(i => i != null);
            }

            else if (pickupTileMap.GetTile(cellPos) == null)
            {
                PlacingItemOnTileMap(_items[index]?._ItemTile, mousePos);

                // Remove Item from Inventory Array
                _items[index] = null;
                isInventoryFull = _items.All(i => i != null);
            }

            
        } 
    }

    /// <summary>
    /// Remove a specific Item from Inventory, ignores the index of said item, doesn't place it on the ground.
    /// </summary>
    /// <param name="index"></param>
    public bool RemoveItemFromInventory(ItemData item) 
    {
        if (isInventoryIsEmpty) { return false; } // Does nothing if Inventory is empty.

        // Remove Item from Inventory Array
        foreach (var itemData in _items) 
        {
            if (itemData != null && (itemData?._Name == item._Name)) 
            {
                _items[Array.IndexOf(_items, itemData)] = null;
                isInventoryFull = _items.All(i => i != null);
                Debug.Log("Removed item!");
                return true; // Item Removed
            }
        }

        return false;
    }



/// <summary>
/// DEPRECATED!
/// </summary>
public void PrintOutContentsOfInventoryDEBUGGING() 
    {
        for (int index = 0; index < _items.Length; index++)
        {
            if (_items[index] == null) { continue; }
            Debug.Log($"Name: {_items[index]?._Name}, Desc: {_items[index]?._Description}, Type Of Flower: {_items[index]?._ItemRarity}");
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

    private void PlacingItemOnTileMap(Tile itemTile, Vector2 mousePos) 
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
                if (flowerPlaceableTiles.PlaceableTiles.Contains(tileMapWhichIsPlaceable.GetTile(cellPos)))
                {
                    return true;
                }
                else
                {
                    return false;
                }

            case Seeds:
                if(flowerPotTiles.PlaceableTiles.Contains(pickupTileMap.GetTile(cellPos)) || pickupTileMap.GetTile(cellPos) == null)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            case FlowerPotWithSeeds:
            case FlowerInFlowerPot:
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
