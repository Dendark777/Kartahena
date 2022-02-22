using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class CardInfo : BaseInfo
{
    private int countCard = 0;
    [SerializeField] private TextMeshProUGUI TextCount;


    public void InitCard(EnumCardValue cardValue)
    {
        path = $"Sprites/Cards/{cardValue}";
        Value = cardValue;
        base.SetLogo();
    }

    public void AddCard()
    {
        countCard++;
        TextCount.text = countCard.ToString();
    }
    public void RemoveCard()
    {
        countCard--;
        TextCount.text = countCard.ToString();
    }
}

