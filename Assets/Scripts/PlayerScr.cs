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

    public PlayerHandsScr GetPlayerHands => _playerHands;


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
        var currentChip = _playerChips.FirstOrDefault(c => c.GetSelect);
        if (currentChip != null && _playerHands.PlayCard(card))
        {
            var target = _mainBoard.FindTargetToMove(card);
            MoveChip(currentChip, target);
            _mainBoard.ResetSubstituteLastAccess();
            ResetSelectChips();
        }
    }

    private void MoveChip(ChipScr currentChip, TileInfo target)
    {
        if (target == null)
        {
            return;
        }
        if (currentChip.currentIndexTile >= 0)
        {
            _mainBoard.GetMap[currentChip.currentIndexTile].StepOutTile(currentChip.gameObject);
        }
        target.StepInTile(currentChip.gameObject);
        currentChip.currentIndexTile = target.IndexInMap;
    }

    public void SelectedChip(ChipScr selectedChip)
    {
        ResetSelectChips();
        _mainBoard.PrepareMapForMove(selectedChip.currentIndexTile, _playerHands.GetCardsOnHands);
    }

    private void ResetSelectChips()
    {
        foreach (var chip in _playerChips)
        {
            chip.ResetChip();
        }
    }
}
