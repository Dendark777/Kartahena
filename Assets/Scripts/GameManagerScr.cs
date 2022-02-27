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

    private PlayerScr _currentPlayer;
    private List<EnumCardValue> _deck;
    public TextMeshProUGUI debug;
    private void Start()
    {
        CreateDeck();
        _mainBoard.InitMap();
        foreach (var player in _players)
        {
            player.InitPlayer(Color.blue, _mainBoard.GetMap);
            for (int i = 0; i < 6; i++)
            {
                DistributionCard(player);
            }
        }
        debug.text = $"Вся колода:{_deck.Count}";
        _currentPlayer = _players[0];
    }

    private void Update()
    {
    }

    private void CreateDeck()
    {
        _deck = new List<EnumCardValue>();
        EnumCardValue cardValue;
        int countValue = Enum.GetValues(typeof(EnumCardValue)).Length;
        for (int i = 0; i < 102; i++)
        {
            cardValue = (EnumCardValue)(i % countValue);
            _deck.Add(cardValue);
        }
        _deck.Shuffle();
    }

    private void DistributionCard(PlayerScr player)
    {
        player.GiveCard(_deck[0]);
        _deck.RemoveAt(0);
    }
}
