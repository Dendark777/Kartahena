using System.Collections;
using System.Collections.Generic;
using System;

using UnityEngine;
using UnityEngine.UI;

public class TilePanelStraight : MonoBehaviour
{
    private List<Tile> tileStack;
    [SerializeField] private List<bool> mapPattern;
    [SerializeField] public List<Tile> tileMap;
    public Transform tilePanelTop;
    public Transform tilePanelMiddle;
    public Transform tilePanelBottom;
    public GameObject tilePref;
    public GameObject tilePrefInvisible;

    
    
    private void Start()
    {
        CreateTileStack();
        PlaseTileToPanel(tileStack);

    }
    private void CreateTileStack()
    {
        tileStack = new List<Tile>();
        EnumGameObjValue tileValue;
        int countValue = Enum.GetValues(typeof(EnumGameObjValue)).Length;

        for (int i = 0; i < 6; i++)
        {
            tileValue = (EnumGameObjValue)(i % countValue);
            tileStack.Add(new Tile(tileValue, $"Sprites/Logo/{tileValue}"));
        }
        tileStack.Shuffle();
    }
   
    void PlaseTileToPanel(List<Tile> _stack)
    {
        Transform _tilePanel = tilePanelTop;

        if (_stack.Count == 0)
            return;
        int _numberTile=0;
        
        tileMap = new List<Tile>();
        
        
        for (int i = 0; i < 66; i++)
        {
            
            if (mapPattern[i])
            {
                Tile tile = _stack[_numberTile++];
                if (_numberTile > 5)
                {
                    _numberTile = 0;
                    tileStack.Shuffle();
                }
                
                if (i > 21 && i < 44) _tilePanel = tilePanelMiddle;
                if (i >= 44) _tilePanel = tilePanelBottom;
                
                GameObject tileGO = Instantiate(tilePref, _tilePanel, false);
                
                tileGO.GetComponent<LogoInfo>().ShowLogoInfo(tile);
                tileMap.Add(tile);
            }
            else
            {
                Instantiate(tilePrefInvisible, _tilePanel, false);
            }
            
        }
    }

   
}
