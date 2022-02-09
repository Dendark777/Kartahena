using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : BaseImage
{
    public Tile(EnumCardValue gameObjValue, string logoPath) : base(logoPath)
    {
    }
}
public static class GameFieldScr
{
    public static List<Tile> allTile = new List<Tile>();
}
public class TileManagerScr : MonoBehaviour
{
    public BaseInfo LogoInfo { get; set; } = new BaseInfo();

    public void Awake()
    {
        //GameField.allTile.Add(new Tile(EnumCardValue.квадрат, "Sprites/Tile/T_Square"));
        //GameField.allTile.Add(new Tile(EnumCardValue.круг, "Sprites/Tile/T_Circle"));
        //GameField.allTile.Add(new Tile(EnumCardValue.треугольник, "Sprites/Tile/T_Triangle"));
        //GameField.allTile.Add(new Tile(EnumCardValue.ромб, "Sprites/Tile/T_Diamond"));
        //GameField.allTile.Add(new Tile(EnumCardValue.шестиугольник, "Sprites/Tile/T_Hexagon"));
        //GameField.allTile.Add(new Tile(EnumCardValue.крест, "Sprites/Tile/T_Xform"));

        //GameField.allTile.Shuffle();

    }
    public void Start()
    {
       //LogoInfo.ShowLogoInfo(GameField.allTile[transform.GetSiblingIndex()]);
    }
}
