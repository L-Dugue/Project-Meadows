using UnityEngine;

[System.Serializable]
public abstract class ItemData
{
    protected Sprite _ImageSprite; // Image to Render in Inventory
    protected string _Name; // Name of the Item
    protected string _Description; // Description of the Item

    public abstract void PintOutInfo();


}
