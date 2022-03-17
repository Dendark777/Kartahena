using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TileInfo : BaseInfo, IPointerClickHandler, IObservable
{
    [SerializeField] private Transform _placeOnTile;

    private List<GameObject> _chipsOnTile;
    public int CountChipsOnTile => _chipsOnTile.Count;
    public bool CanStepToForward => CountChipsOnTile == 0;
    public bool CanstepToBack => CountChipsOnTile > 0 && CountChipsOnTile < 3;
    public int IndexInMap { get; private set; }
    private bool _canSelect;
    public void InitTile(EnumCardValue cardValue, int index)
    {
        path = $"Sprites/Logo/{cardValue}";
        _canSelect = false;
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
        logo.color = Color.yellow;
        _canSelect = true;
    }

    public void ResetShadow()
    {
        logo.color = Color.white;
        _canSelect = false;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (_canSelect)
        {
            NotifyObservers();
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
        GameManagerScr.Instance.NotifyClickOnTile(this);
    }
}
