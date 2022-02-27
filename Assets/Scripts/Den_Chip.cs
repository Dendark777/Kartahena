using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ChipScr : MonoBehaviour, IPointerClickHandler
{
    private Color _playerColor;
    private Image imageChip;
    private bool _selected;
    public void ChipInit(Color playerColor)
    {
        _playerColor = playerColor;
        imageChip = GetComponent<Image>();
        imageChip.color = playerColor;
        _selected = false;

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
            StartCoroutine(Blink());
            _selected = true;
        }
        else
        {
            StopAllCoroutines();
            imageChip.color = _playerColor;
            _selected = false;
        }
    } 
    private IEnumerator Blink()
    {
        while (true)
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
}
