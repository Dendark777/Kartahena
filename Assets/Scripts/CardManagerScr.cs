using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Card : GameObj
{
    public Card(EnumGameObjValue gameObjValue, string logoPath) : base(gameObjValue, logoPath)
    {
    }
}

public static class Deck
{
    public static List<Card> allCards = new List<Card>();
}


public class CardManagerScr : MonoBehaviour
{
    
    public void Awake()
    {
        for (int i = 0; i < 17; i++)
        {
            Deck.allCards.Add(new Card(EnumGameObjValue.квадрат, "Sprites/Cards/Square"));
            Deck.allCards.Add(new Card(EnumGameObjValue.круг, "Sprites/Cards/Circle"));
            Deck.allCards.Add(new Card(EnumGameObjValue.треугольник, "Sprites/Cards/Triangle"));
            Deck.allCards.Add(new Card(EnumGameObjValue.ромб, "Sprites/Cards/Diamond"));
            Deck.allCards.Add(new Card(EnumGameObjValue.шестиугольник, "Sprites/Cards/Hexagon"));
            Deck.allCards.Add(new Card(EnumGameObjValue.крест, "Sprites/Cards/Xform"));
        }
        Deck.allCards.Shuffle();
        
    }
}

public enum EnumGameObjValue
{
    круг,
    треугольник,
    квадрат,
    ромб,
    шестиугольник,
    крест    
}
