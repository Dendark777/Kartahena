using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Chip : MonoBehaviour, IClickable
{
    [SerializeField] GameObject ChipPanelStart;
    [SerializeField] public bool isSelected = false;
    [SerializeField] public int currentIndexTile = 0;
    public Outline outline;
    /*void Start()
    {
        outline = GetComponent<Outline>();
    }*/
    public void Click()
    {
        GetComponent<ChipManagerScr>().UnselectedChip();
        isSelected = true;
        outline.enabled = true;
    }

}