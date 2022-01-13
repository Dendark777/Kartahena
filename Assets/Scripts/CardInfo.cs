using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class CardInfo : MonoBehaviour
{
    public Card selfCard;
    [SerializeField] public Image logo;
    [SerializeField] public TextMeshProUGUI cardCount;

    public void ShowcardInfo(Card _card)
    {
        selfCard = _card;
        logo.sprite = _card.Logo;
        logo.preserveAspect = true;
    }
}

