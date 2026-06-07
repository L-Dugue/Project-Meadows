using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    // Create Array for Items, with 4 slots
    private ItemData?[] _items = new ItemData?[4];

    // Private Members
    private bool isInventoryFull = false;
    private bool isInventoryIsEmpty = true;

    public bool AddItemToInventory(ItemData itemPickedUp)
    {

        Debug.Log($"Added {itemPickedUp.GetType().Name} to Inventory\n");

        if (isInventoryIsEmpty)
        {
            _items[0] = itemPickedUp;
            isInventoryIsEmpty = false;
            return true;
        }
        else if(!isInventoryFull)
        {
           for(int index = 0; index < _items.Length; index++) 
           {
                if (_items[index] == null) 
                {
                    _items[index] = itemPickedUp;
                    isInventoryFull = (index == _items.Length - 1);
                    return true;
                }
           }
        }


        Debug.Log("Inventory is full!");
        return false;
    }

    public void PrintOutContentsOfInventoryDEBUGGING() 
    {
        for (int index = 0; index < _items.Length; index++)
        {
            if (_items[index] == null) { continue; }
            Debug.Log($"Name: {_items[index]?._Name}, Desc: {_items[index]?._Description}, Type Of Flower: {_items[index]?._FlowerType}");
        }
    }
}
