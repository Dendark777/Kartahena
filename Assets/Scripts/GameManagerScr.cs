using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

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
        EnumGameObjValue cardValue;
        int countValue = Enum.GetValues(typeof(EnumGameObjValue)).Length;
        for (int i = 0; i < 102; i++)
        {
            cardValue = (EnumGameObjValue)(i % countValue);
            _deck.Add(new Card(cardValue, $"Sprites/Logo/{cardValue}"));
        }
        /*_deck.Shuffle();*/
    }

    void GiveHandCard(List<Card> deck, Transform hand)
    {
        int i = 0;
        while (i++ < 6)
            CreateCardToPlaeyrHand(deck, hand,i);
    }

    void CreateCardToPlaeyrHand(List<Card> deck, Transform hand,int i)
    {
        if (deck.Count == 0)
            return;
        Card card = deck[0];
        GameObject cardGO = Instantiate(cardPref, hand, false);
        cardGO.GetComponent<CardInfo>().ShowLogoInfo(card);
        cardGO.GetComponent<Transform>().SetSiblingIndex(i);
        deck.RemoveAt(0);
    }

    
    

    
}
