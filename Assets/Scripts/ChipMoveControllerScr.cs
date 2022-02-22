using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ChipMoveControllerScr : MonoBehaviour
{
    [SerializeField] private GameObject cardPanel;
    [SerializeField] private GameObject tilePanel;
    public Transform currentSelectChip;
    
    void Awake()
    {
        DOTween.Init();
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
    }

    void CompareValue()
    {
        List<GameObject> cardsList = cardPanel.GetComponent<CardManagerScr>().cardsGO;
        List<GameObject> tileMap = tilePanel.GetComponent<TilePanel>().tileMap;

        foreach (GameObject card in cardsList)
        {
            var _cardInfo = card.GetComponent<CardInfo>();
            int cardCount = _cardInfo.cardCount;
            if (cardCount > 0)
            {
                for (int i = 0; i < cardCount; i++)
                {

                    for (int index = 0; index < tileMap.Count; index++)
                    {
                        var _tile = tileMap[index].GetComponent<LogoInfo>();
                        var _bisyChipPlaceCount = _tile.bisyChipPlaceCount;
                        var _valueTile = $"{_tile.logo.sprite}";
                        var _valueCard = $"{ _cardInfo.logo.sprite}";
                       
                        if (_valueCard == _valueTile && _bisyChipPlaceCount < 3)
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

    public void ChipMove(Component _cardInfo)
    {
        List<GameObject> cardsList = cardPanel.GetComponent<CardManagerScr>().cardsGO;
        List<GameObject> tileMap = tilePanel.GetComponent<TilePanel>().tileMap;
        //var _cardInfo = card.GetComponent<CardInfo>();
        for (int index = 0; index < tileMap.Count; index++)
        {
            var _tile = tileMap[index].GetComponent<LogoInfo>();
            var _bisyChipPlaceCount = _tile.bisyChipPlaceCount;
            var _valueTile = $"{_tile.logo.sprite}";
            var _valueCard = $"{ _cardInfo.logo.sprite}";
            var _tileChipPosition = _tile.chipsPosition[0].transform.position;
            currentSelectChip.DOJump(_tileChipPosition, 1f, 1, 1f, false);
            if (_valueCard == _valueTile && _bisyChipPlaceCount < 3)
                return;
        }
    }

}
