using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardGOValue : MonoBehaviour
{
    
    [SerializeField] public GameObject selfGO;
    public string GOValue;
    void Start()
    {
      public string GOValue = ShowGOValue(selfGO);
    }

    public string ShowGOValue(GameObject GO)
    {
        string _cardValue = $"{GO.GetComponent<Image>().sprite}";
        return _cardValue;
    }
}
