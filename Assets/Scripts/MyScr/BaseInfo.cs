using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class BaseInfo : MonoBehaviour
{
    [SerializeField] private Image logo;
    [SerializeField] private EnumCardValue Value;
    protected string path;

    public void InitializeTile(EnumCardValue cardValue)
    {
        Value = cardValue;
        ShowLogoInfo();
    }

    public EnumCardValue GetValue => Value;

    public void ShowLogoInfo()
    {

        logo.sprite = Resources.Load<Sprite>(path);
        logo.preserveAspect = true;
    }
}