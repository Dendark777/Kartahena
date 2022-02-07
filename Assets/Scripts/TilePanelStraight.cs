using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class TilePanelStraight : MonoBehaviour
{
    private List<Tile> _stack;
    public Transform tilePanel;
    public GameObject tilePref;
    
    private void Start()
    {
        CreateTileStack();
        PlaseTileToPanel(_stack, tilePanel);
    }
    private void CreateTileStack()
    {
        _stack = new List<Tile>();
        EnumGameObjValue tileValue;
        int countValue = Enum.GetValues(typeof(EnumGameObjValue)).Length;

        for (int i = 0; i < 6; i++)
        {
            tileValue = (EnumGameObjValue)(i % countValue);
            _stack.Add(new Tile(tileValue, $"Sprites/Logo/{tileValue}"));
        }
        _stack.Shuffle();
    }
    void PlaseTileToPanel(List<Tile> _stack, Transform _tileStack)
    {
        int i = 0;
        while (i++ < 6)
            CreateTileonStack(_stack, _tileStack);
    }
    void CreateTileonStack(List<Tile> _stack, Transform _tileStack)
    {
        if (_stack.Count == 0)
            return;
        Tile tile = _stack[0];
        GameObject tileGO = Instantiate(tilePref, _tileStack, false);
        tileGO.GetComponent<LogoInfo>().ShowLogoInfo(tile);
        _stack.RemoveAt(0);
    }
}
