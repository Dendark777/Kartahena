using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;
public class CardInfo : LogoInfo, IClickable, IObservable
{

    [SerializeField] public TextMeshProUGUI TMProcardCount;
    [SerializeField] public Image Image;
    [SerializeField] public Material Material;
    private readonly ChipMoveManagerScr chipMoveControllerScr;
    private List<ChipMoveManagerScr> _observers;
    public UnityEvent HitMoveChipEvent;
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

    public void SubCoundCard()
    {

        if (cardCount > 0)
        {
            cardCount--;

            if (cardCount == 0)
                UnactiveCard();
            else
                TMProcardCount.text = $"{cardCount}";
        }
    }


    public void Click()
    {

        if (chipMoveControllerScr.currentSelectChipTransform != null)
        {
            SubCoundCard();
            NotifyObservers();
        }

        else
        {
            print("Выберите фишку!");
        }
    }
    public void AddObserver(MonoBehaviour o)
    {
        _observers.Add(o.GetComponent<ChipMoveManagerScr>());
    }

    public void RemoveObserver(MonoBehaviour o)
    {
        _observers.Remove(o.GetComponent<ChipMoveManagerScr>());
    }

    public void NotifyObservers()
    {
        foreach (var item in _observers)
        {
            item.ChipMove();
        }

    }

}

