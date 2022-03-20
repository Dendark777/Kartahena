using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ChipScr : MonoBehaviour, IPointerClickHandler, IObservable, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private Image _chipIconBG;
    [SerializeField] private Image _frame;
    [SerializeField] private Material _frameOnEnter;
    [SerializeField] private Material _frameOnClick;
    private Color _playerColor;
    private List<PlayerScr> _observers;
    public int currentIndexTile { get; set; }
    private bool _selected;
    private bool _isMoving;
    public bool GetSelect => _selected;
    public void ChipInit(Color playerColor)
    {
        _playerColor = playerColor;

        _observers = new List<PlayerScr>();
        currentIndexTile = -1;
        _selected = false;
        _isMoving = false;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        NotifyObservers();
        _frame.material = _frameOnClick;
        gameObject.GetComponent<Btn_SFX>().ClickSound();
        if (eventData.button == PointerEventData.InputButton.Left)
        {
           
        }
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        _frame.enabled = true;
        if (!_selected)
        {
            _frame.material = _frameOnEnter;
            gameObject.GetComponent<Btn_SFX>().HoverSound();

        }
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        if (!_selected)
            _frame.enabled = false;
    }

    public void StartOnMap()
    {
        transform.localScale = new Vector3(0.5f, 0.5f);
    }

    public void MoveChipOnMap(Transform target)
    {
        _isMoving = true;
        ResetChip();
    }

    public void ResetChip()
    {
        _isMoving = false;
        _frame.enabled = false;
        _selected = false;
        
    }

    public void SelectedChip()
    {
        _frame.enabled = true;
        _frame.material = _frameOnClick;
        _selected = true;
    }

    public void AddObserver(MonoBehaviour o)
    {
        _observers.Add(o.GetComponent<PlayerScr>());
    }

    public void RemoveObserver(MonoBehaviour o)
    {
        _observers.Remove(o.GetComponent<PlayerScr>());
    }

    public void NotifyObservers()
    {
        foreach (var item in _observers)
        {
            item.SelectedChip(this);
        }
    }
}
