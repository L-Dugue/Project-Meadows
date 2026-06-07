using UnityEngine;

public class Flower : Item
{
    [SerializeField] private string FlowerName;
    [SerializeField] private string FlowerDesc;
    [SerializeField] private string TypeOfFlower;

    public override ItemData ItemPickedUp() 
    {
        ItemData flowerData = new ItemData(FlowerName, FlowerDesc, gameObject.GetComponent<SpriteRenderer>().sprite, this, TypeOfFlower);
        return flowerData;
    }
}
