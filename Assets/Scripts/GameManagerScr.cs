using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class GameManagerScr : MonoBehaviour
{
    private List<EnumCardValue> _deck;

    [SerializeField] private List<GameObject> Players;

    public TextMeshProUGUI debug;
    private void Start()
    {
        CreateDeck();
        foreach (var player in Players)
        {
            var hand = player.GetComponent<PlayerHandsScr>();
            hand.CreateTilesOnHands();
            for (int i = 0; i < 6; i++)
            {
                DistributionCard(hand);
            }
        }
        debug.text = $"Вся колода:{_deck.Count}";

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
        _deck.Shuffle();
    }

    private void DistributionCard(PlayerHandsScr handsPlayer)
    {
        handsPlayer.TakeCardPlayer(_deck[0]);
        _deck.RemoveAt(0);
    }
    //void GiveHandCard(List<EnumCardValue> deck)
    //{
    //    int i = 0;
    //    while (i++ < 6)
    //        GiveCardToHand(deck);
    //}

    //void GiveCardToHand(List<EnumCardValue> deck)
    //{
    //    if (deck.Count == 0)
    //        return;

    //    deck.RemoveAt(0);
    //}
}
