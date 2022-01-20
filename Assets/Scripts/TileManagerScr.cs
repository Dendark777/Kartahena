using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : GameObj
{
    public Tile(EnumGameObjValue gameObjValue, string logoPath) : base(gameObjValue, logoPath)
    {
    }
}
public static class GameField
{
    public static List<Tile> allTile = new List<Tile>();
}
public class TileManagerScr : MonoBehaviour
{
    public LogoInfo LogoInfo { get; set; } = new LogoInfo();

    public void Awake()
    {
        GameField.allTile.Add(new Tile(EnumGameObjValue.квадрат, "Sprites/Tile/T_Square"));
        GameField.allTile.Add(new Tile(EnumGameObjValue.круг, "Sprites/Tile/T_Circle"));
        GameField.allTile.Add(new Tile(EnumGameObjValue.треугольник, "Sprites/Tile/T_Triangle"));
        GameField.allTile.Add(new Tile(EnumGameObjValue.ромб, "Sprites/Tile/T_Diamond"));
        GameField.allTile.Add(new Tile(EnumGameObjValue.шестиугольник, "Sprites/Tile/T_Hexagon"));
        GameField.allTile.Add(new Tile(EnumGameObjValue.крест, "Sprites/Tile/T_Xform"));

        GameField.allTile.Shuffle();

    }
    public void Start()
    {
       LogoInfo.ShowLogoInfo(GameField.allTile[transform.GetSiblingIndex()]);
    }
}
