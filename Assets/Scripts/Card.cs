using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    private Sprite cardLogo;
    private string logoPath;
    [SerializeField] public EnumCardValue cardValue;
    public EnumCardValue CardValue
    {
        get { return cardValue; }
    }

    void Start()
    {
        CardLogoChoice();
    }

    void CardLogoChoice()
    {
        switch (this.cardValue)
        {
            case EnumCardValue.квадрат:
                logoPath = "Sprites/Cards/Square";
                break;
            case EnumCardValue.круг:
                logoPath = "Sprites/Cards/Circle";
                break;
            case EnumCardValue.треугольник:
                logoPath = "Sprites/Cards/Triangle";
                break;
            case EnumCardValue.ромб:
                logoPath = "Sprites/Cards/Diamond";
                break;
            case EnumCardValue.сердце:
                logoPath = "Sprites/Cards/Heart";
                break;
            case EnumCardValue.крест:
                logoPath = "Sprites/Cards/Club";
                break;
            default:
                break;
        }
        cardLogo = Resources.Load<Sprite>(logoPath);
        this.GetComponent<Image>().sprite = cardLogo;
    }

}

public enum EnumCardValue
{
    круг,
    треугольник,
    квадрат,
    ромб,
    сердце,
    крест
}