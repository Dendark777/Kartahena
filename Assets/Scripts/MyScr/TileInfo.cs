using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TileInfo : BaseInfo
{
    [SerializeField] private Transform _placeOnTile;
    //[SerializeField] private bool canStepToForward;
    //[SerializeField] private bool canstepToBack;

    private List<GameObject> _chipsOnTile;

    public bool CanStepToForward => _chipsOnTile.Count == 0;
    public bool CanstepToBack => _chipsOnTile.Count > 0 && _chipsOnTile.Count < 3;

    public int IndexInMap { get; private set; }
    public void InitTile(EnumCardValue cardValue, int index)
    {
        path = $"Sprites/Tiles/T_{cardValue}";
        //canstepToBack = false;
        //canStepToForward = false;
        Value = cardValue;
        _chipsOnTile = new List<GameObject>();
        IndexInMap = index;
        base.SetLogo();
    }

    public void StepInTile(GameObject chip)
    {
        _chipsOnTile.Add(chip);
        chip.transform.SetParent(_placeOnTile);
        //CanStep();
    }

    public void StepOutTile(GameObject chip)
    {
        _chipsOnTile.Remove(chip);
        //CanStep();
    }

    private void CanStep()
    {
        var countChip = _chipsOnTile.Count;
        //canStepToForward = countChip == 0;
        //canstepToBack = countChip > 0 && countChip < 3;
    }

    public void Shadow()
    {
        logo.color = Color.yellow;
    }

    public void ResetShadow()
    {
        logo.color = Color.white;

    }

}
