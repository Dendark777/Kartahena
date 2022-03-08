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
        player.InitPlayer(Color.blue, _mainBoard);
        for (int i = 0; i < 6; i++)
        {
            player.GiveCard(_cardManager.GiveCard());
        }
    } 

    private void Update()
    {
    }

}
