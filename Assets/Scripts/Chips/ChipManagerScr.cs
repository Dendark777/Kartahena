using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChipManagerScr : MonoBehaviour
{
    [SerializeField] public List<GameObject> Chips;


    public void UnselectedChip()
    {
        foreach (GameObject element in Chips)
        {
            element.GetComponentInChildren<Chip>().isSelected = false;
            element.GetComponentInChildren<Outline>().enabled = false;
        }

    }
}
