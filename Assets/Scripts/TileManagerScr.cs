using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : GameObj
{
    public Tile(EnumGameObjValue gameObjValue, string logoPath) : base(gameObjValue, logoPath)
    {
    }
}
public static class Map
{
    public static List<Tile> allTile = new List<Tile>();
}
public class TileManagerScr : MonoBehaviour
{

    public void Awake()
    {
        Map.allTile.Add(new Tile(EnumGameObjValue.квадрат, "Sprites/Tile/T_Square"));
        Map.allTile.Add(new Tile(EnumGameObjValue.круг, "Sprites/Tile/T_Circle"));
        Map.allTile.Add(new Tile(EnumGameObjValue.треугольник, "Sprites/Tile/T_Triangle"));
        Map.allTile.Add(new Tile(EnumGameObjValue.ромб, "Sprites/Tile/T_Diamond"));
        Map.allTile.Add(new Tile(EnumGameObjValue.шестиугольник, "Sprites/Tile/T_Hexagon"));
        Map.allTile.Add(new Tile(EnumGameObjValue.крест, "Sprites/Tile/T_Xform"));

        Map.allTile.Shuffle();

    }
}
