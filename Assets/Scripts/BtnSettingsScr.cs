using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BtnSettingsScr : MonoBehaviour,IPointerClickHandler
{
    [SerializeField] private GameObject PopupSetting;

    public void OnPointerClick(PointerEventData eventData)
    {
        PopupSetting.SetActive(true);
    }
}