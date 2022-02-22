using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScr : MonoBehaviour
{
    private Color _playerColor;
    private PlayerHandsScr _playerHands;
    private ChipPanelScr _chipPanel;
    private List<ChipScr> _playerChip;

    private void Start()
    {
        
    }
    public void InitPlayer(Color playerColor)
    {
        _playerColor = playerColor;
        //_playerChip = new List<Chip>();
    }

    public void GiveCard(CardInfo card)
    {
        //_playerCards.Add(card);
    }

    public void PlayCard(CardInfo card)
    {
        //_playerCards.Remove(card);
    }
}
