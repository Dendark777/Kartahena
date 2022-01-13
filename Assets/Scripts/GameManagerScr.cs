using System.Collections;
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
        playerHand = GiveDeckCard();
    }
    List<Card> GiveDeckCard()
    {
        List<Card> list = new List<Card>();
        for (int i = 0; i < 6; i++)
            list.Add(Deck.allCards[i]);
        return list;
    }
}



public class GameManagerScr : MonoBehaviour
{
    
}
