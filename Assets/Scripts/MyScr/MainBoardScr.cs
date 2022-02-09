using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class MainBoardScr : MonoBehaviour
{
    [SerializeField] private GameObject BlankTile;
    [SerializeField] private GameObject GameTile;
    [SerializeField] private GameObject FinishTile;

    [SerializeField] private List<GameObject> _gameMap;
    // Start is called before the first frame update
    void Start()
    {
        _gameMap = new List<GameObject>();
        CreateTilesOnBoard();
    }

    public void CreateTilesOnBoard()
    {
        for (int i = 0; i < 5; i++)
        {

            if (i == 3)
            {
                _gameMap.Add(Instantiate(GameTile, transform, false));
            }
            for (int j = 0; j < 10; j++)
            {
                if (i % 2 == 0)
                {
                    _gameMap.Add(Instantiate(GameTile, transform, false));
                }
                else
                {
                    Instantiate(BlankTile, transform, false);
                }
            }
            if (i != 3)
            {
                _gameMap.Add(Instantiate(GameTile, transform, false));
            }
        }
        for (int j = 0; j < 9; j++)
        {
            Instantiate(BlankTile, transform, false);
        }
        Instantiate(FinishTile, transform, false);
        _gameMap.Add(Instantiate(GameTile, transform, false));
        ShuffleMap();
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
                _gameMap[index].GetComponent<TileInfo>().initTile(item);
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

    // Update is called once per frame
    void Update()
    {

    }
}
