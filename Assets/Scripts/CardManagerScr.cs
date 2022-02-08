using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CardManagerScr : MonoBehaviour
{
    private List<Card> _deck;
    private List<Card> _visibleCardsDeck;
    public Transform cardPanel;

    public GameObject cardPref;

    private void Start()
    {
        CreateDeck();
        CreateDeckforVisible();
        CreateCardGOonCardPanel(_visibleCardsDeck, cardPanel);
        giveCardToPlayerhand(_deck);
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

    private void CreateDeckforVisible()
    {
        _visibleCardsDeck = new List<Card>();
        EnumGameObjValue cardValue;
        int countValue = Enum.GetValues(typeof(EnumGameObjValue)).Length;
        for (int i = 0; i < 6; i++)
        {
            cardValue = (EnumGameObjValue)(i % countValue);
            _visibleCardsDeck.Add(new Card(cardValue, $"Sprites/Logo/{cardValue}"));
        }
    }

    void CreateCardGOonCardPanel(List<Card> deck, Transform _panel)
    {
        if (deck.Count == 0)
            return;
        for (int _numberCard = 0; _numberCard < 6; _numberCard++)
        {

            Card card = deck[_numberCard];
            GameObject cardGO = Instantiate(cardPref, _panel, false);
            cardGO.GetComponent<CardInfo>().ShowLogoInfo(card);

        }
    }
    void giveCardToPlayerhand(List<Card> deck)
    {
        for (int i = 0; i < 6; i++)
        {
            Card card = deck[i];
            deck.RemoveAt(i);
    }

    
    }





}
