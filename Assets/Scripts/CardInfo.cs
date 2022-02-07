using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class CardInfo : LogoInfo
{
    private int countCard = 0;
    [SerializeField] private TextMeshProUGUI TextCount;

    public void AddCard()
    {
        countCard++;
        TextCount.text = countCard.ToString();
    }
}

