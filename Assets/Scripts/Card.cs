using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Card : GameObj
    {
        public Card(EnumCardValue gameObjValue, string logoPath) : base(gameObjValue, logoPath)
        {
        }
    }