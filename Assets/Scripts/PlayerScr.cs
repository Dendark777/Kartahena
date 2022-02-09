using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScr
{
    [SerializeField] private Transform PlayerHand;
    private EnumPlayerColor _playerColor;
    private List<CardInfo> _playerCards;
    private List<Chip> _playerChip;
    public PlayerScr(EnumPlayerColor playerColor)
    {
        _playerColor = playerColor;
        _playerCards = new List<CardInfo>();
        _playerChip = new List<Chip>();
    }

    public void GiveCard(CardInfo card)
    {
        _playerCards.Add(card);
    }

    public void PlayCard(CardInfo card)
    {
        _playerCards.Remove(card);
    }
}
