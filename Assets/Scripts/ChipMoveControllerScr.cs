using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class ChipMoveControllerScr : MonoBehaviour
{
    [SerializeField] private GameObject cardPanel;
    [SerializeField] public GameObject tilePanel;
    public List<GameObject> tileMap;
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
    }

    void CompareValue() //пока не учитывает кол-во фишек в игре
    {
        List<GameObject> cardsList = cardPanel.GetComponent<CardManagerScr>().cardsGO;
        var _tilePanel = tilePanel.GetComponent<TilePanel>();
        var tileMap = _tilePanel.tileMap;

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




    public void ChipMove()
    {
        //var _tilePanelforMove = tilePanel.GetComponent<TilePanel>();
        /*var tileMapforMove = _tilePanelforMove.tileMap;*/
        print("Cработало движеие!");

        for (int index = 0; index < tileMap.Count; index++)
        {

            var _tile = tileMap[index].GetComponent<LogoInfo>();
            var _bisyChipPlaceCount = _tile.bisyChipPlaceCount;
            var _valueTile = $"{_tile.logo.sprite}";
            var _tileChipPosition = _tile.chipsPosition[0].transform.position;
            currentSelectChip.transform.DOJump(endturn.position, 1f, 1, 1f, false);

            // WaitForSeconds pause = new WaitForSeconds(1);
            if (currentCardValue == _valueTile && _bisyChipPlaceCount < 3)
            {
                print(currentCardValue + " = " + _valueTile);
                return;
            }


        }
    }

}
