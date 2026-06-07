using System;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    // Create Array for Items, with 4 slots
    private ItemData[] _items = new ItemData[4];
    private bool isInventoryIsEmpty = true;

    public void AddItemToInventory(ItemData itemPickedUp)
    {

        Debug.Log($"Added {itemPickedUp.GetType().Name} to Inventory\n");

        if (isInventoryIsEmpty)
        {
            _items[0] = itemPickedUp;
            isInventoryIsEmpty = false;
        }
        else
        {
           for(int index = 1; index < _items.Length; index++) 
           {
                if(_items[index] == null) 
                {
                    _items[index] = itemPickedUp;
                    break;
                }
                
           }
        }
    }

    public void PrintOutContentsOfInventoryDEBUGGING() 
    {
        for (int index = 0; index < _items.Length; index++)
        {
            if (_items[index] == null) { continue; }
            _items[index].PintOutInfo();
        }
    }
}
