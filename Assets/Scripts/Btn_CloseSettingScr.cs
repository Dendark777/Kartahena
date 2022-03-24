using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Btn_CloseSetting : MonoBehaviour, IPointerClickHandler
{
        public void OnPointerClick(PointerEventData eventData)
        {
            ReturnToLastScene();
        }

        private void ReturnToLastScene()
        {

        }
 }

