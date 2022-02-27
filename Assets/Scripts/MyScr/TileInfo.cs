using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TileInfo : BaseInfo, IPointerClickHandler
{
    [SerializeField] private Transform PlaceOnTile;
    private List<GameObject> _chipsOnTile;

    public delegate void Selected(TileInfo Tile);
    public void initTile(EnumCardValue cardValue)
    {
        path = $"Sprites/Tiles/T_{cardValue}";
        Value = cardValue;
        _chipsOnTile = new List<GameObject>();
        base.SetLogo();     
    }

    public void StepInTile(GameObject chip)
    {
        if (_chipsOnTile.Count <= 3)
        {
            _chipsOnTile.Add(chip);
            chip.transform.parent = PlaceOnTile;
        }
    }

    public void StepOutTile(GameObject chip)
    {
        _chipsOnTile.Remove(chip);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        
    }
}
