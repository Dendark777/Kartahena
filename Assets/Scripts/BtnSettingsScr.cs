using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BtnSettingsScr : MonoBehaviour,IPointerClickHandler
{
    [SerializeField] private GameObject PopupSetting;
    [SerializeField] private List<GameObject> flames;
    
    public void OnPointerClick(PointerEventData eventData)
    {
        PopupSetting.SetActive(true);
        HideFlames();
    }
   
    public void HideFlames()
    {
        foreach(var elem in flames)
        {
           if (elem.activeInHierarchy)
                elem.SetActive(false);
        }
    }
}