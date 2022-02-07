using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class GameManagerScr : MonoBehaviour
{
    private List<Card> _deck;

    [SerializeField] private List<GameObject> Players;

    public TextMeshProUGUI debug;
    private void Start()
    {
        CreateDeck();
        GiveHandCard(_deck);
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
            _deck.Add(new Card(cardValue));
        }
        _deck.Shuffle();
    }
    void GiveHandCard(List<Card> deck)
    {
        int i = 0;
        while (i++ < 6)
            GiveCardToHand(deck);
    }

    void GiveCardToHand(List<Card> deck)
    {
        if (deck.Count == 0)
            return;
        Card card = deck[0];

        deck.RemoveAt(0);
    }
}
