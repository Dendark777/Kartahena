using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubtractionCard : MonoBehaviour/*,IClickable*/
{
    /*public void Click()
    {
        subtractionCoundCard();
    }*/
    public void subtractionCoundCard()
    {
        var cardInfo = GetComponent<CardInfo>();
        if (cardInfo.cardCount > 0)
        {
            cardInfo.cardCount--;

            if (cardInfo.cardCount == 0)
                cardInfo.UnactiveCard();
            else
                cardInfo.TMProcardCount.text = $"{cardInfo.cardCount}";
        }
    }
}