using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

