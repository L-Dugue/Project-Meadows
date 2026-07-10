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
    public delegate void ItemAddedToInventory(int indexAddedAt, ItemBluePrint? item);
    public static event ItemAddedToInventory OnItemAddedToInventory;

    // Create Nullable Array for Items, with 4 slots
    private ItemBluePrint?[] _items = new ItemBluePrint[4];

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
    public ItemBluePrint?[] Items {  get { return _items; } }
    public float PlacementRange { get { return placementRange; } }


    private void Awake()
    {
        //InventoryUI.RemoveItemFromInventory += RemoveItemFromInventory;
    }


    public bool AddItemToInventory(ItemBluePrint itemPickedUp)
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


    // Instead of the Inventory dealing with deciding if it goes into a flowerpot/teacup, the flower should.

    /// <summary>
    /// Remove Item from Inventory, placing it on the ground.
    /// </summary>
    /// <param name="index"></param>
    /// <param name="mousePos"></param>
    public void RemoveItemFromInventory(int index, Vector2 mousePos)
    {
        if (isInventoryIsEmpty) { return; } // Does nothing if Inventory is empty.

        // Mouse is inside placement range and is a valid tile.
        if (TileManager.Instance.CheckIfPlaceable(_items, index))
        {
            Debug.Log("CALLED");
           
            var typeOfItem = _items[index]?._ItemObj.GetComponent<Item>();
            if (typeOfItem is Flower && TileManager.Instance.IsEmptyOfItem<FlowerPot>(mousePos))
            {
                TileManager.Instance.PlacingItem(_items[index]?._ItemObj, mousePos);
                RemoveItemDataFromInventory(index);
            }
            else if (TileManager.Instance.IsEmptyOfItem(mousePos))
            {
                TileManager.Instance.PlacingItem(_items[index]?._ItemObj, mousePos);
                RemoveItemDataFromInventory(index);

            }


            //if (pickupTileMap.GetTile(cellPos) == null)
            //{

            //}


            /*

            if ((typeOfItem is Flower flower) && flowerPotTiles.PlaceableTiles.Contains(pickupTileMap.GetTile(cellPos)))
            {
                // Checks if its a teacup or ordinary flowerpot
                if (flowerPotTiles.PlaceableTiles[0] == pickupTileMap.GetTile(cellPos))
                {
                    Debug.Log("RAN1");
                    PlacingItem(flower.FlowerInFlowerPot, mousePos);
                }
                else if (flowerPotTiles.PlaceableTiles[1] == pickupTileMap.GetTile(cellPos))
                {
                    Debug.Log("RAN2");
                    //PlacingItemOnTileMap(flower.FlowerInTeaCup, mousePos);
                }

                Debug.Log("RAN3");
                //PlacingItem(_items[index]?._ItemObj, mousePos);

                // Remove Item from Inventory Array
                _items[index] = null;
                isInventoryFull = _items.All(i => i != null);
            }

            // Places the Seeds within a FlowerPot.
            else if ((typeOfItem is Seeds seed) && flowerPotTiles.PlaceableTiles.Contains(pickupTileMap.GetTile(cellPos)))
            {
                if (flowerPotTiles.PlaceableTiles[0] == pickupTileMap.GetTile(cellPos))
                {
                    // Places the gameobject in the world, unabled to use the Tile GameObject Instiation.
                    seed.SeedsInFlowerPotTile.gameObject = seed.SeedsInFlowerPotObj;
                    //PlacingItemOnTileMap(seed.SeedsInFlowerPotTile, mousePos);
                }

                // Remove Item from Inventory Array
                _items[index] = null;
                isInventoryFull = _items.All(i => i != null);
            }
            */




        }
    }

    /// <summary>
    /// Remove a specific Item from Inventory, ignores the index of said item, doesn't place it on the ground.
    /// </summary>
    /// <param name="index"></param>
    public bool RemoveItemFromInventory(ItemBluePrint item) 
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

    private void RemoveItemDataFromInventory(int index)
    {
        // Remove Item from Inventory Array
        _items[index] = null;
        isInventoryFull = _items.All(i => i != null);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, placementRange);
    }
}
