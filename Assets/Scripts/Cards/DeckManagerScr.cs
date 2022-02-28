using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class DeckManagerScr
{
    public List<Card> deck { get; private set; }
    public List<Card> deckGO { get; private set; }

    public DeckManagerScr()
    {
        deck = new List<Card>();
        deckGO = new List<Card>();
        EnumGameObjValue cardValue;
        int countValue = Enum.GetValues(typeof(EnumGameObjValue)).Length;
        for (int i = 0; i < 102; i++)
        {
            cardValue = (EnumGameObjValue)(i % countValue);
            deck.Add(new Card(cardValue, $"Sprites/Logo/{cardValue}"));
        }
        for (int i = 0; i < 6; i++)
        {
            cardValue = (EnumGameObjValue)(i % countValue);
            deckGO.Add(new Card(cardValue, $"Sprites/Logo/{cardValue}"));
        }
        deck.Shuffle();
    }
}
