﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class CardInfo : LogoInfo
{
    
    [SerializeField] public TextMeshProUGUI TMProcardCount;
    [SerializeField] public Image Image;
    [SerializeField] public Material Material;
    public int cardCount;

    private void Update()
    {
        
    }
    public void UnactiveCard()
    {
        TMProcardCount.text = $" ";
        Image.material = null;
        logo.material = null;
        return;
    }
}

