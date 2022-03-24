using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BtnSettingsScr : MonoBehaviour,IPointerClickHandler
{
    [SerializeField] private GameObject SettingsMenu;
    [SerializeField] private List<GameObject> flames;
    
    public void OnPointerClick(PointerEventData eventData)
    {
        SettingsMenu.SetActive(true);
        HideFlames();
    }
   
    public void HideFlames()
    {
        if (flames != null)
        {
            foreach (var elem in flames)
            {
                if (elem.activeInHierarchy)
                    elem.SetActive(false);
            }
        }
    }
}