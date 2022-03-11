using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CardManagerScr : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _countCardsInDeck;
    private List<EnumCardValue> _deck;


    public void Init()
    {
        CreateDeck();
        _deck.Shuffle();
        _countCardsInDeck.text = $"Вся колода:{_deck.Count}";
    }

    private void CreateDeck()
    {
        _deck = new List<EnumCardValue>();
        EnumCardValue cardValue;
        int countValue = Enum.GetValues(typeof(EnumCardValue)).Length;
        for (int i = 0; i < 102; i++)
        {
            cardValue = (EnumCardValue)(i % countValue);
            _deck.Add(cardValue);
        }
    }

    public EnumCardValue GiveCard()
    {
        var card = _deck[0];
        _deck.Remove(card);
        _countCardsInDeck.text = $"Вся колода:{_deck.Count}";
        return card;
    }
}
