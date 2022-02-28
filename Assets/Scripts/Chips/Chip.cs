using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Chip : MonoBehaviour, IClickable, IObservable
{
    [SerializeField] GameObject ChipPanelStart;
    [SerializeField] GameObject ChipMoveController;
    [SerializeField] public bool isSelected = false;
    [SerializeField] public int currentIndexTile = 0;
    public Outline outline;


    private List<ChipMoveManagerScr> _observers;

    void Awake()
    {
        _observers = new List<ChipMoveManagerScr>();
    }

    void Start()
    {

    }
    public void Click()
    {
        ChipPanelStart.GetComponent<ChipManagerScr>().UnselectedChip();
        isSelected = true;
        outline.enabled = true;
        NotifyObservers();
    }

    public void AddObserver(MonoBehaviour o)
    {
        _observers.Add(o.GetComponent<ChipMoveManagerScr>());
    }

    public void RemoveObserver(MonoBehaviour o)
    {
        _observers.Remove(o.GetComponent<ChipMoveManagerScr>());
    }

    public void NotifyObservers()
    {

        foreach (var item in _observers)
        {
            item.SetCurrentChip(this);
        }

    }
}