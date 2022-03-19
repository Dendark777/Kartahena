using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ChipScr : MonoBehaviour, IPointerClickHandler, IObservable
{
    [SerializeField] private Image _chipSkull;
    [SerializeField] private Image _selectOnChip;

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
        if (eventData.button == PointerEventData.InputButton.Left && !_selected)
        {
            _selectOnChip.enabled = true;
            _selected = true;

            //StartCoroutine(Blink());
        }
    }
    /*private IEnumerator Blink()
    {
        while (_selected)
        {
            if (_chipHat.color == _playerColor)
            {
                _chipSkull.color = NewColor(Color.white, 0);
                _chipHat.color = NewColor(_playerColor, 0);
            }
            else
            {
                _chipSkull.color = NewColor(Color.white, 1);
                _chipHat.color = _playerColor;
            }

            yield return new WaitForSeconds(0.4f);
        }
    }*/

    private Color NewColor(Color color, float alpha)
    {
        return new Color(color.r, color.g, color.b, alpha);
    }

    public void StartOnMap(Transform target)
    {
        transform.position = target.position;
    }

    public void MoveChipOnMap(Transform target)
    {
        _isMoving = true;
        ResetChip();

    }

    private IEnumerator MoveToTile(Transform target)
    {
        while (_isMoving)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, 0.01f);
            yield return new WaitForSeconds(0.001f);
            if (transform.position == target.position)
            {
                transform.SetParent(transform, true);
                ResetChip();
                break;
            }
        }

    }
    public void ResetChip()
    {
        _isMoving = false;
        _selectOnChip.enabled = false;
        _selected = false;
        // _chipSkull.color = NewColor(Color.white, 1);

        //StopAllCoroutines();
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
