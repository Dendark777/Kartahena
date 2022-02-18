using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MoveChip : MonoBehaviour, IClickable
{
    [SerializeField] private GameObject chipPanel;

    void Awake()
    {
        DOTween.Init();
    }

    public void Click()
    {
        var cardInfo = GetComponent<CardInfo>();
        if (cardInfo.cardCount > 0)
        {
            cardInfo.cardCount--;
            if (cardInfo.cardCount == 0)
                UnactiveCard();
            else
                cardInfo.TMProcardCount.text = $"{cardInfo.cardCount}";





        }
        var chip = chipPanel.GetComponent<ChipManagerScr>().Chips[0];
        chip.transform.DOMove(cardInfo.transform.position, 2f, false);

        print($"клик!");
    }

    private void UnactiveCard()
    {
        var cardInfo = GetComponent<CardInfo>();
        cardInfo.TMProcardCount.text = $" ";
        cardInfo.Image.material = null;
        cardInfo.logo.material = null;
        return;
    }
}
