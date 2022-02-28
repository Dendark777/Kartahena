using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerScr : MonoBehaviour
{
    /*[SerializeField] private PlayerHandsScr _playerHands;
    [SerializeField] private ChipPanelScr _chipPanel;

    [SerializeField] private List<TileInfo> _map;
    private Color _playerColor;
    private List<ChipScr> _playerChips;

    public PlayerHandsScr GetPlayerHands => _playerHands;

    private void Start()
    {
        
    }
    public void InitPlayer(Color playerColor, List<GameObject> map)
    {
        _playerColor = playerColor;
        _playerChips = _chipPanel.InitPanel(_playerColor);
        _playerHands.CreateTilesOnHands();
        foreach (var item in _playerHands.GetCardsOnHands)
        {
            item.AddObserver(this);
        }
        _map = map.Select(t => t.GetComponent<TileInfo>()).ToList();
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
            var target = SearchTileToMove(card, currentChip);
            currentChip.MoveChipOnMap(target);
        }
    }

    private Transform SearchTileToMove(EnumCardValue cardValue, ChipScr currentChip)
    {
        var target = _map.Skip(currentChip.CurrentIndexTile).FirstOrDefault(t => t.GetValue == cardValue);
        if (currentChip.CurrentIndexTile == 0)
        {
            currentChip.StartOnMap(_map[0].transform);
        }
        if (target != null)
        {
            currentChip.CurrentIndexTile = _map.IndexOf(target)+1;
            return target.transform;
        }
        return null;
    }*/
}
