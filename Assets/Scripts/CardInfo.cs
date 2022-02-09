using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class CardInfo : BaseInfo
{
    private int countCard = 0;
    [SerializeField] private TextMeshProUGUI TextCount;


    public void initCard(EnumCardValue cardValue)
    {
        path = $"Sprites/Cards/{cardValue}";
        base.InitializeTile(cardValue);
        ShowLogoInfo();
    }

    public void AddCard()
    {
        countCard++;
        TextCount.text = countCard.ToString();
    }
}

