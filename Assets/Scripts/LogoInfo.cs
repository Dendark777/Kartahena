using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class LogoInfo : MonoBehaviour
{
    public GameObj selfGO;
    [SerializeField] public Image logo;
    
    public  void ShowLogoInfo(GameObj _go)
    {
        selfGO = _go;
        logo.sprite = _go.Logo;
        logo.preserveAspect = true;
    }
}