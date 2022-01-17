using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class LogoInfo : MonoBehaviour
{
    public Card selfCard;
    [SerializeField] public Image logo;
    

    public void ShowLogoInfo(Card _card)
    {
        selfCard = _card;
        logo.sprite = _card.Logo;
        logo.preserveAspect = true;
    }
}