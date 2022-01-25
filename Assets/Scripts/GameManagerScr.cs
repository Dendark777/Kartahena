using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class GameManagerScr : MonoBehaviour
{
    private List<Card> _deck;

    public TextMeshProUGUI debug;
    public Transform playerHand;
    public GameObject cardPref;
    private void Start()
    {
        CreateDeck();
        GiveHandCard(_deck, playerHand);
        debug.text = $"Вся колода:{_deck.Count}";
        
    }

    private void CreateDeck()
    {
        _deck = new List<Card>();
        EnumCardValue cardValue;
        int countValue = Enum.GetValues(typeof(EnumCardValue)).Length - 1;
        for (int i = 0; i < 102; i++)
        {
            cardValue = (EnumCardValue)(i%countValue);
            _deck.Add(new Card(cardValue, $"Sprites/Cards/{cardValue}"));
        }
        _deck.Shuffle();
    }

    void GiveHandCard(List<Card> deck,Transform hand)
    {
        int i = 0;
        while (i++ < 6)
            GiveCardToHand(deck, hand);
    }

    void GiveCardToHand(List<Card> deck, Transform hand)
    {
        if (deck.Count == 0)
            return;
        Card card = deck[0];
        GameObject cardGO = Instantiate(cardPref,hand,false);
        cardGO.GetComponent<CardInfo>().ShowLogoInfo(card);
        deck.RemoveAt(0);
    }
}
