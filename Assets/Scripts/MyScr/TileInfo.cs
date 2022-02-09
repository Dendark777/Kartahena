using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileInfo : BaseInfo
{
    public void initTile(EnumCardValue cardValue)
    {
        path = $"Sprites/Tiles/T_{cardValue}";
        base.InitializeTile(cardValue);
        ShowLogoInfo();
    }
}
