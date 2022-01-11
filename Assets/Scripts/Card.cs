using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Card : MonoBehaviour
{
    [SerializeField] public EnumCardValue cardValue;
    [SerializeField] public int cardCount;
    [SerializeField] TextMeshProUGUI cardCountTMP;
    public EnumCardValue CardValue
    {
        get { return cardValue; }
    }
    
    void Start()
    {
        GetComponent<Image>().sprite = Resources.Load<Sprite>(CardLogoPathChoice(cardValue));
        cardCountTMP.text = cardCount.ToString();
    }

    string CardLogoPathChoice(EnumCardValue _cardValue)
    {
        string _logoPath = "";
        switch (_cardValue)
        {
            case EnumCardValue.квадрат:
                _logoPath = "Sprites/Cards/Square";
                break;
            case EnumCardValue.круг:
                _logoPath = "Sprites/Cards/Circle";
                break;
            case EnumCardValue.треугольник:
                _logoPath = "Sprites/Cards/Triangle";
                break;
            case EnumCardValue.ромб:
                _logoPath = "Sprites/Cards/Diamond";
                break;
            case EnumCardValue.сердце:
                _logoPath = "Sprites/Cards/Heart";
                break;
            case EnumCardValue.крест:
                _logoPath = "Sprites/Cards/Club";
                break;
        }
        return _logoPath;
    }
    /*private string CardLogoPathChoice(EnumCardValue i)
     {
         string v = i switch
         {
             EnumCardValue.круг => "Sprites/Cards/Circle",
             EnumCardValue.треугольник => "Sprites/Cards/Triangle",
             EnumCardValue.квадрат => "Sprites/Cards/Square",
             EnumCardValue.ромб => "Sprites/Cards/Diamond",
             EnumCardValue.сердце => "Sprites/Cards/Heart",
             EnumCardValue.крест => "Sprites/Cards/Club",
             _ => "Sprites/Cards/Circle"
         };
         return v;
     }*/

    public enum EnumCardValue
    {
        круг,
        треугольник,
        квадрат,
        ромб,
        сердце,
        крест
    }
}