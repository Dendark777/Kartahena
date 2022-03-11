using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerScr : MonoBehaviour
{
    [SerializeField] private PlayerHandsScr _playerHands;
    [SerializeField] private ChipPanelScr _chipPanel;

    [SerializeField] private MainBoardScr _mainBoard;
    private Color _playerColor;
    private List<ChipScr> _playerChips;
    private ChipScr _currentchip;
    public PlayerHandsScr GetPlayerHands => _playerHands;

    public bool CanMoveChip => _currentchip != null && _currentchip.GetSelect;
    public bool MoveBack(TileInfo tileInfo) => _currentchip.currentIndexTile > tileInfo.IndexInMap;

    public void InitPlayer(Color playerColor, MainBoardScr mainBoard)
    {
        _playerColor = playerColor;
        InitChipPanel();
        InitCardPanel();
        _mainBoard = mainBoard;
    }

    private void InitChipPanel()
    {
        _playerChips = _chipPanel.InitPanel(_playerColor);
        foreach (var item in _playerChips)
        {
            item.AddObserver(this);
        }
    }

    private void InitCardPanel()
    {
        _playerHands.CreateTilesOnHands();
        foreach (var item in _playerHands.GetPlaceCardOnPanel)
        {
            item.AddObserver(this);
        }
    }

    public void GiveCard(EnumCardValue card)
    {
        _playerHands.TakeCardPlayer(card);
    }

    public void PlayCard(EnumCardValue card)
    {
        //var _currentchip = _playerChips.FirstOrDefault(c => c.GetSelect);
        if (_currentchip != null && _playerHands.PlayCard(card))
        {
            var target = _mainBoard.FindTargetToMove(card);
            TurnPlayer(target);
        }
    }

    public void TurnPlayer(TileInfo target)
    {
        MoveChip(target);
        _mainBoard.ResetSubstituteLastAccess();
        ResetSelectChips();
    }

    private void MoveChip(TileInfo target)
    {
        if (target == null)
        {
            return;
        }
        if (_currentchip.currentIndexTile >= 0)
        {
            _mainBoard.GetMap[_currentchip.currentIndexTile].StepOutTile(_currentchip.gameObject);
        }
        target.StepInTile(_currentchip.gameObject);
        _currentchip.currentIndexTile = target.IndexInMap;
    }

    public void SelectedChip(ChipScr selectedChip)
    {
        ResetSelectChips();
        _currentchip = selectedChip;
        _mainBoard.PrepareMapForMove(selectedChip.currentIndexTile, _playerHands.GetCardsOnHands);
    }

    private void ResetSelectChips()
    {
        _currentchip = null;
        foreach (var chip in _playerChips)
        {
            chip.ResetChip();
        }
    }


}
