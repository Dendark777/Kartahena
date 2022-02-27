using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ChipScr : MonoBehaviour, IPointerClickHandler
{
    private Color _playerColor;
    private int _currentTile;
    private Image imageChip;
    private bool _selected;
    private bool _isMoving;
    public bool GetSelect => _selected;
    public int CurrentIndexTile
    {
        get
        {
            return _currentTile;
        }
        set
        {
            _currentTile = value;
        }
    }
    public void ChipInit(Color playerColor)
    {
        _playerColor = playerColor;
        imageChip = GetComponent<Image>();
        imageChip.color = playerColor;
        _currentTile = 0;
        _selected = false;
        _isMoving = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        ChipInit(Color.blue);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left && !_selected)
        {
            _selected = true;
            StartCoroutine(Blink());
        }
        else
        {
            ResetChip();
        }
    }
    private IEnumerator Blink()
    {
        while (_selected)
        {
            if (imageChip.color == _playerColor)
            {
                imageChip.color = Color.white;
            }
            else
            {
                imageChip.color = _playerColor;
            }
            yield return new WaitForSeconds(0.4f);
        }
    }

    public void StartOnMap(Transform target)
    {
        transform.position = target.position;
    }

    public void MoveChipOnMap(Transform target)
    {
        _isMoving = true;
        StartCoroutine(MoveToTile(target));

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
    private void ResetChip()
    {
        _isMoving = false;
        _selected = false;
        imageChip.color = _playerColor;
        StopAllCoroutines();
    }
}
