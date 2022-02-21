using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CardManagerScr : MonoBehaviour
{
    private List<Card> _deck;
    private List<Card> _deckGO;
    /*private List<Card> _visibleCardsDeck;*/
    public Transform cardPanel;
    private EnumGameObjValue cardValue;
    public GameObject cardPref;

    [SerializeField] private List<GameObject> cardsGO;


    private void Start()
    {
        CreateDeck();
        CreateCardGOonCardPanel(_deckGO, cardPanel);
        for (int i = 0; i < 6; i++)
        {
            GiveCardToPlayerhand(_deck);
        }

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            GiveCardToPlayerhand(_deck);
        }
    }

    private void CreateDeck()
    {
        _deck = new List<Card>();
        _deckGO = new List<Card>();
        EnumGameObjValue cardValue;
        int countValue = Enum.GetValues(typeof(EnumGameObjValue)).Length;
        for (int i = 0; i < 102; i++)
        {
            cardValue = (EnumGameObjValue)(i % countValue);
            _deck.Add(new Card(cardValue, $"Sprites/Logo/{cardValue}"));
            _deckGO.Add(new Card(cardValue, $"Sprites/Logo/{cardValue}"));
        }
        for (int i = 0; i < 6; i++)
        {
            cardValue = (EnumGameObjValue)(i % countValue);
            _deckGO.Add(new Card(cardValue, $"Sprites/Logo/{cardValue}"));
        }
        _deck.Shuffle();
    }


    void CreateCardGOonCardPanel(List<Card> deck, Transform _panel)
    {

        foreach (Card card in deck)
        {

            GameObject cardGO = Instantiate(cardPref, _panel, false);

            cardGO.GetComponent<CardInfo>().ShowLogoInfo(card);
        }
    }
    void GiveCardToPlayerhand(List<Card> deck)
    {
        if (deck.Count == 0) return;
        Card card = deck[0];

        foreach (GameObject elem in cardsGO)
        {
            var cardInfo = elem.GetComponent<CardInfo>();

            if ($"{card.logo}" == $"{cardInfo.logo.sprite}")
            {
                cardInfo.cardCount++;

                cardInfo.TMProcardCount.text = $"{cardInfo.cardCount}";

                cardInfo.Image.material = cardInfo.Material;
                cardInfo.logo.material = cardInfo.Material;
            }
        }


        deck.RemoveAt(0);


        print(deck.Count);

    }





}
