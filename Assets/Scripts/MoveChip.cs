using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;

public class MoveChip : MonoBehaviour, IClickable
{
    [SerializeField] private GameObject chipPanel;
    [SerializeField] private GameObject tilePanel;

    void Awake()
    {
        DOTween.Init();
    }

    public void Click()
    {
        var tileMap = tilePanel.GetComponent<TilePanel>().tileMap;
        var cardInfo = GetComponent<CardInfo>();
        var chip = chipPanel.GetComponent<ChipManagerScr>();
        var chipi = GetComponent<Chip>();

       // subtractionCoundCard();

        //print($"{cardInfo.logo.sprite}");

        foreach (GameObject elem in tileMap)
        {
            var _tile = elem.GetComponent<LogoInfo>();
            //var _countJumpTile = Math.Abs(tileMap.IndexOf(elem) - chipi.currentIndexTile);
            var _tileChipPosition = _tile.chipsPosition[0].transform.position;
            //print($"{Math.Abs(tileMap.IndexOf(elem) - currentTile)}");
            chip.Chips[0].transform.DOJump(_tileChipPosition, 1f, 1 /*_countJumpTile*/, 1f, false);
            if ($"{cardInfo.logo.sprite}" == $"{_tile.logo.sprite}")
            {
                // chipi.currentIndexTile = tileMap.IndexOf(elem);
                return;
            }
        }
    }

    

   /* private void subtractionCoundCard()
    {
        var cardInfo = GetComponent<CardInfo>();
        if (cardInfo.cardCount > 0)
        {
            cardInfo.cardCount--;

            if (cardInfo.cardCount == 0)
                UnactiveCard();
            else
                cardInfo.TMProcardCount.text = $"{cardInfo.cardCount}";
        }
    }*/
}
