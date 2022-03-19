using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using UnityEngine.EventSystems;

public class GameManagerScr : MonoBehaviour
{


    [SerializeField] private List<PlayerScr> _players;
    [SerializeField] private MainBoardScr _mainBoard;
    [SerializeField] private CardManagerScr _cardManager;
    private PlayerScr _currentPlayer;
    public static GameManagerScr Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        _cardManager.Init();
        _mainBoard.InitMap();
        foreach (var player in _players)
        {
            InitPlayer(player);
        }
        _currentPlayer = _players[0];
    }

    private void InitPlayer(PlayerScr player)
    {
        player.InitPlayer(Color.yellow, _mainBoard);
        TakeCardInDeck(player, 6);
    }

    private void TakeCardInDeck(PlayerScr player, int count)
    {
        for (int i = 0; i < count; i++)
        {
            player.GiveCard(_cardManager.GiveCard());
        }
    }

    public void NotifyClickOnTile(TileInfo tileInfo)
    {
        if (!_currentPlayer.CanMoveChip)
        {
            return;
        }
        if (_currentPlayer.MoveBack(tileInfo))
        {
            _currentPlayer.TurnPlayer(tileInfo);
            TakeCardInDeck(_currentPlayer, tileInfo.CountChipsOnTile - 1);
            return;
        }
        _currentPlayer.PlayCard(tileInfo.GetValue);
    }

    private void Update()
    {
    }

}
