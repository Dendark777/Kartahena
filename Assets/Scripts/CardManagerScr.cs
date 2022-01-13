using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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


static class MyExtensions
{
    private static System.Random rng = new System.Random();
    public static void Shuffle<T>(this IList<T> list)
    {
        int n = list.Count;
        while (n > 1)
        {
            n--;
            int k = rng.Next(n + 1);
            T value = list[k];
            list[k] = list[n];
            list[n] = value;
        }
    }
}



public enum EnumGameObjValue
{
    круг,
    треугольник,
    квадрат,
    ромб,
    шестиугольник,
    крест,
    красный,
    оранжевый,
    желтый,
    зеленый,
    синий
}
