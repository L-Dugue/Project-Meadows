using UnityEngine;

public class FlowerData : ItemData
{
    public readonly string _typeOfFlower;

    public FlowerData(string flowerName, string flowerType, string flowerDesc, Sprite sprite) 
    {
        base._Name = flowerName;
        base._Description = flowerDesc;
        base._ImageSprite = sprite;
        _typeOfFlower = flowerType; 
    }

    public override void PintOutInfo() 
    {
        Debug.Log($"Name: {base._Name}, Desc: {base._Description}, Type Of Flower: {_typeOfFlower}\n");
    }
}
