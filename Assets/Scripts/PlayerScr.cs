using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScr
{
    [SerializeField] private Transform PlayerHand;
    private EnumPlayerColor _playerColor;
    private List<Card> _playerCards;
    private List<Chip> _playerChip;
    public PlayerScr(EnumPlayerColor playerColor)
    {
        _playerColor = playerColor;
        _playerCards = new List<Card>();
        _playerChip = new List<Chip>();
    }

    public void GiveCard(Card card)
    {
        _playerCards.Add(card);
    }

    public void PlayCard(Card card)
    {
        _playerCards.Remove(card);
    }
}
