﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public abstract class GameObj
{
    public Sprite Logo;

    public GameObj(EnumGameObjValue gameObjValue, string logoPath)
    {
        Logo = Resources.Load<Sprite>(logoPath);
    }

}
public class Game
{
    public List<Card> playerHand;
    public Game()
    {
        playerHand = GiveHandCard();
    }
    List<Card> GiveHandCard()
    {
        
    List<Card> list = new List<Card>();
        for (int i = 0; i < 6; i++)
        {
            list.Add(Deck.allCards[i]);
            Deck.allCards.RemoveAt(i);
        }
        return list;
    }
}



public class GameManagerScr : MonoBehaviour
{
    public TextMeshProUGUI debug;
    public Game currentGame;
    public Transform playerHand;
    public GameObject cardPref;
    private void Start()
    {
        currentGame = new Game();
        GiveHandCard(currentGame.playerHand, playerHand);
        debug.text = $"Вся колода:{Deck.allCards.Count}";
        
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
        cardGO.GetComponent<CardInfo>().ShowcardInfo(card);

        deck.RemoveAt(0);
    }
}
