using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class MainBoardScr : MonoBehaviour
{
    [SerializeField] private GameObject _blankTile;
    [SerializeField] private GameObject _gameTile;
    [SerializeField] private GameObject _finishTile;
    [SerializeField] private List<TileInfo> _gameMap;
    private List<int> _IndexsAccessTile;

    public List<TileInfo> GetMap => _gameMap;

    public void InitMap()
    {
        _gameMap = new List<TileInfo>();
        _IndexsAccessTile = new List<int>();
        CreateTilesOnBoard();
        ShuffleMap();
    }

    public void CreateTilesOnBoard()
    {
        for (int i = 0; i < 5; i++)
        {
            if (i == 3)
            {
                _gameMap.Add(Instantiate(_gameTile, transform, false).GetComponent<TileInfo>());
            }
            for (int j = 0; j < 10; j++)
            {
                if (i % 2 == 0)
                {
                    _gameMap.Add(Instantiate(_gameTile, transform, false).GetComponent<TileInfo>());
                }
                else
                {
                    Instantiate(_blankTile, transform, false);
                }
            }
            if (i != 3)
            {
                _gameMap.Add(Instantiate(_gameTile, transform, false).GetComponent<TileInfo>());
            }
        }
        for (int j = 0; j < 9; j++)
        {
            Instantiate(_blankTile, transform, false);
        }
        //_gameMap.Add(Instantiate(_finishTile, transform, false));
        Instantiate(_finishTile, transform, false);
        _gameMap.Add(Instantiate(_gameTile, transform, false).GetComponent<TileInfo>());
        _gameMap.Reverse(12, 11);
        //_gameMap.Reverse(35, 2);
    }

    private void ShuffleMap()
    {
        int index = 0;
        var listValues = CreateListValue();
        for (int j = 0; j < 6; j++)
        {
            listValues.Shuffle();
            foreach (var item in listValues)
            {
                _gameMap[index].InitTile(item, index);
                index++;
            }
        }
    }

    private List<EnumCardValue> CreateListValue()
    {
        var temp = new List<EnumCardValue>();
        int countValue = Enum.GetValues(typeof(EnumCardValue)).Length;
        for (int i = 0; i < countValue; i++)
        {
            temp.Add((EnumCardValue)(i % countValue));
        }
        return temp;
    }



    public void FindTileMoveToForward(EnumCardValue cardValue, int indexCurrentTile)
    {
        var result = _gameMap.Skip(indexCurrentTile+1).FirstOrDefault(t => t.GetValue == cardValue && t.CanStepToForward);
        if (result != null)
        {
            result.Shadow();
            _IndexsAccessTile.Add(result.IndexInMap);
        }
    }

    private void FindTileMoveToBack(int indexCurrentTile)
    {
        var result = _gameMap.LastOrDefault(t => t.CanstepToBack && t.IndexInMap < indexCurrentTile);
        if (result != null)
        {
            result.Shadow();
            _IndexsAccessTile.Add(result.IndexInMap);
        }
    }

    public void PrepareMapForMove(int indexCurrentTile, List<CardInfo> cardOnHands)
    {
        ResetSubstituteLastAccess();
        foreach (var card in cardOnHands)
        {
            FindTileMoveToForward(card.GetValue, indexCurrentTile);
        }
        FindTileMoveToBack(indexCurrentTile);
    }

    public TileInfo FindTargetToMove(EnumCardValue cardValue)
    {
        foreach (var index in _IndexsAccessTile)
        {
            if (_gameMap[index].GetValue == cardValue)
            {
                return _gameMap[index];
            }
        }
        return null;
    }

    public void ResetSubstituteAll()
    {
        foreach (var tile in _gameMap)
        {
            tile?.ResetShadow();
        }
        _IndexsAccessTile.Clear();
    }


    public void ResetSubstituteLastAccess()
    {
        foreach (var item in _IndexsAccessTile)
        {
            _gameMap[item].ResetShadow();
        }
        _IndexsAccessTile.Clear();
    }

}
