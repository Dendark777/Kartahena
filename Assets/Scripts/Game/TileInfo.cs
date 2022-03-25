using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class TileInfo : BaseInfo, IPointerClickHandler, IObservable, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private Transform _placeOnTile;
    [SerializeField] private Image _frame;
    [SerializeField] private Material _frameOnEnter;
    [SerializeField] private Material _frameCanSelect;

    private List<GameObject> _chipsOnTile;
    public int CountChipsOnTile => _chipsOnTile.Count;
    public bool CanStepToForward => CountChipsOnTile == 0;
    public bool CanstepToBack => CountChipsOnTile > 0 && CountChipsOnTile < 3;
    public int IndexInMap { get; private set; }
    private bool _canSelect;
    public void InitTile(EnumCardValue cardValue, int index)
    {
        path = $"Sprites/Game/Logo/{cardValue}";
        _canSelect = false;
        //logo.color = new Color. ((int)cardValue),0,0,1);
        Value = cardValue;
        _chipsOnTile = new List<GameObject>();
        IndexInMap = index;
        base.SetLogo();
    }

    public void StepInTile(GameObject chip)
    {
        _chipsOnTile.Add(chip);
        chip.transform.SetParent(_placeOnTile);
    }

    public void StepOutTile(GameObject chip)
    {
        _chipsOnTile.Remove(chip);
    }

    public void Shadow()
    {
        //logo.color = Color.yellow;
        _frame.enabled = true;
        _canSelect = true;
    }

    public void ResetShadow()
    {
        //logo.color = Color.white;
        _frame.enabled = false;
        _canSelect = false;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (_canSelect)
        {
            _frame.enabled = true;
            _frame.material = _frameOnEnter;
            GetComponent<BtnSfxScr>().SoundOnPointerEnter();
        }  
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        if (_canSelect)
            _frame.material = _frameCanSelect;
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        if (_canSelect)
        {
            NotifyObservers();
          
        }
        else if (_chipsOnTile.Count > 0)
        {
            var chip = _chipsOnTile[0].GetComponent<ChipScr>();
            chip.OnPointerClick(eventData);
            GetComponent<BtnSfxScr>().SoundOnPointerClick();
        }
    }

    public void AddObserver(MonoBehaviour o)
    {
        throw new System.NotImplementedException();
    }

    public void RemoveObserver(MonoBehaviour o)
    {
        throw new System.NotImplementedException();
    }

    public void NotifyObservers()
    {
        ManagerGameSceneScr.Instance.NotifyClickOnTile(this);
    }
}
