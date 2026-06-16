using UnityEngine;

public abstract class Item : MonoBehaviour
{
    public abstract ItemData ItemPickedUp();

    //public abstract void ApplyDetailsToItem(ItemData? itemDetails);
    // public abstract void ReadItemDesc();
}
