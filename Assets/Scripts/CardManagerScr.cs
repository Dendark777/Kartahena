using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CardManagerScr : MonoBehaviour
{
    private List<Card> _deck;
    /*private List<Card> _visibleCardsDeck;
    public Transform cardPanel;

    public GameObject cardPref;*/

    [SerializeField] private List<GameObject> cardsGO;


    private void Start()
    {
        CreateDeck();

        GiveCardToPlayerhand(_deck);
    }

    private void CreateDeck()
    {
        _deck = new List<Card>();
        EnumGameObjValue cardValue;
        int countValue = Enum.GetValues(typeof(EnumGameObjValue)).Length;
        for (int i = 0; i < 102; i++)
        {
            cardValue = (EnumGameObjValue)(i % countValue);
            _deck.Add(new Card(cardValue, $"Sprites/Logo/{cardValue}"));
        }
        _deck.Shuffle();
    }


    /*void CreateCardGOonCardPanel(List<Card> deck, Transform _panel)
    {
        if (deck.Count == 0)
            return;
        for (int _numberCard = 0; _numberCard < 6; _numberCard++)
        {

            Card card = deck[_numberCard];
            GameObject cardGO = Instantiate(cardPref, _panel, false);
            cardGO.GetComponent<CardInfo>().ShowLogoInfo(card);

        }
    }*/
    void GiveCardToPlayerhand(List<Card> deck)
    {

        for (int numbercard = 0; numbercard < 6; numbercard++)
        {

            Card card = deck[0];

            //print($"значение карты {numbercard}:{card.Logo}");

            for (int numberGO = 0; numberGO < cardsGO.Count; numberGO++)
            {
                var cardInfo = cardsGO[numberGO].GetComponent<CardInfo>();

                //print($"значение объекта{numberGO}:{cardInfo.logo.sprite}");

                //print($"{card.Logo} {cardInfo.logo.sprite}");

                if ($"{card.logo}" == $"{cardInfo.logo.sprite}")
                {
                    cardInfo.cardCount++;

                    cardInfo.TMProcardCount.text = $"{cardInfo.cardCount}";

                    cardInfo.Image.material = cardInfo.Material;
                    cardInfo.logo.material = cardInfo.Material;
                }
            }

            deck.RemoveAt(0);

        }
        /*print(deck.Count);*/

    }





}
