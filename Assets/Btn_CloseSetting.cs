using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Btn_CloseSetting : MonoBehaviour, IPointerClickHandler
{
    
        [SerializeField] private GameObject PopupSetting;
        [SerializeField] private List<GameObject> flames;

        public void OnPointerClick(PointerEventData eventData)
        {
            PopupSetting.SetActive(false);
            ShowFlames();
        }

        public void ShowFlames()
        {
            foreach (var elem in flames)
            {
                if (!elem.activeInHierarchy)
                    elem.SetActive(true);
            }
        }
 }

