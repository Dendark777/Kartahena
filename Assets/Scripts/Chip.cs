using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class Chip : MonoBehaviour, IClickable
{
    [SerializeField] GameObject ChipPanelStart;
    [SerializeField] GameObject ChipMoveController;
    [SerializeField] public bool isSelected = false;
    [SerializeField] public int currentIndexTile = 0;
    public Outline outline;
    public UnityEvent HitSelectChipEvent;

    /*void Start()
    {
        outline = GetComponent<Outline>();
    }*/
    public void Click()
    {
        ChipPanelStart.GetComponent<ChipManagerScr>().UnselectedChip();
        isSelected = true;
        outline.enabled = true;

        HitSelectChipEvent.Invoke();
    }

}