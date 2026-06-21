using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Tilemaps;


[CreateAssetMenu(fileName = "PlaceableTilesList", menuName = "Scriptable Objects/PlaceableTilesList")]
public class PlaceableTilesList : ScriptableObject
{
    public List<Tile> PlaceableTiles;
}

