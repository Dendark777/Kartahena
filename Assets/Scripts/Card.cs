using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Card
{
    public EnumCardValue CardValue { get; private set; }
    public string LogoPath { get; private set; }
    public Card(EnumCardValue cardValue)
    {
        CardValue = cardValue;
        LogoPath = $"Sprites/Cards/{CardValue}";
    }
}
