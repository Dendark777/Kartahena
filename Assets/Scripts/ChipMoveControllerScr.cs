﻿using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class ChipMoveControllerScr : MonoBehaviour
{
    [SerializeField] private GameObject cardPanel;
    [SerializeField] private GameObject tilePanel;
    public List<GameObject> tileMapOnChipController;
    [SerializeField] private GameObject startTile;
    private GameObject[] currentSelectChips = null;
    public GameObject currentSelectChip;
    public Transform endturn;
    public string currentCardValue;
    public int TESTvalue;

    void Awake()
    {
        DOTween.Init();
        TESTvalue = 0;
    }

    private void Start()
    {
        CompareValue();

    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            CompareValue();

        }
        if (Input.GetKeyDown(KeyCode.Z))
        {

            ChipMove();
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            SelectCurrentChip();
        }
    }

    void CompareValue() //пока не учитывает кол-во фишек в игре
    {
        List<GameObject> cardsList = cardPanel.GetComponent<CardManagerScr>().cardsGO;
        List<GameObject> tileList = tilePanel.GetComponent<TilePanelScr>().tileMap;

        foreach (GameObject card in cardsList)
        {
            var _cardInfo = card.GetComponent<CardInfo>();
            int cardCount = _cardInfo.cardCount;
            if (cardCount > 0)
            {
                for (int i = 0; i < cardCount; i++)
                {

                    for (int index = 0; index < tileList.Count; index++)
                    {
                        var _tile = tileList[index].GetComponent<LogoInfo>();
                        var _bisyChipPlaceCount = _tile.bisyChipPlaceCount;
                        var _valueTile = $"{_tile.logo.sprite}";
                        var _valueCard = $"{ _cardInfo.logo.sprite}";

                        if (_valueCard == _valueTile && _bisyChipPlaceCount < 1)
                        {
                            int indexCoincidingTile = index;
                            _tile.bisyChipPlaceCount++;

                            _tile.ActiveTile();
                            break;

                        }

                    }
                }

            }
        }
    }

    public void SelectCurrentChip()
    {
        if (currentSelectChips == null)
            currentSelectChips = GameObject.FindGameObjectsWithTag("Chip");

        foreach (GameObject _chip in currentSelectChips)
        {
            if (_chip.GetComponentInChildren<Chip>().isSelected)
            {
                currentSelectChip = _chip;
                print($"{currentSelectChip}");
            }
        }
        print($"{currentSelectChip}");
    }

    public void ChipMove()
    {

        var tileList = tilePanel.GetComponent<TilePanelScr>().tileMap;
        print("Cработало движеие!");

        for (int index = 0; index < tileList.Count; index++)
        {

            var _tile = tileList[index].GetComponent<LogoInfo>();
            var _bisyChipPlaceCount = _tile.bisyChipPlaceCount;
            var _valueTile = $"{_tile.logo.sprite}";
            var _tileChipPosition = _tile.chipsPosition[0].transform.position;
            currentSelectChip.transform.DOJump(endturn.position, 1f, 1, 1f, false);

            // WaitForSeconds pause = new WaitForSeconds(0.5f);
            if (currentCardValue == _valueTile && _bisyChipPlaceCount < 3)
            {
                print(currentCardValue + " = " + _valueTile);
                return;
            }


        }
    }



}
