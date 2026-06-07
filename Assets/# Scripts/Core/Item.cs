using UnityEngine;

public abstract class Item : MonoBehaviour
{
    [SerializeField] private Sprite _ImageSprite; // Image to Render in Inventory
    [SerializeField] private string _Name; // Name of the Item
    [SerializeField] private string _Description; // Description of the Item

    public void RemoveObjectFromWorld() 
    {
        Destroy(gameObject);
    }
}
