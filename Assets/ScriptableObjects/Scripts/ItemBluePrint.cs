using UnityEngine;

[CreateAssetMenu(fileName = "ItemBluePrint", menuName = "Scriptable Objects/ItemBluePrint")]
public class ItemBluePrint : ScriptableObject
{
    public Sprite _ImageSprite; // Image to Render in Inventory
    public string _Name; // Name of the Item
    public string _Description; // Description of the Item
    public string _ItemRarity;
    public int _ItemPrice;
    public GameObject _ItemObj;
}
