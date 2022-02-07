using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class LogoInfo : MonoBehaviour
{
    [SerializeField] public Image logo;
    
    public  void ShowLogoInfo(string logoPath)
    {
        logo.sprite = Resources.Load<Sprite>(logoPath);
        logo.preserveAspect = true;
    }
}