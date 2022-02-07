using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManagerScr : MonoBehaviour
{
    private List<Card> _deck;
    private List<Tile> _stack;

    public TextMeshProUGUI debug;
    public Transform playerHand;
    public Transform tilePanel;
    public GameObject cardPref;
    public GameObject tilePref;
    private void Start()
    {
        CreateDeck();
        CreateTileStack();
        GiveHandCard(_deck, playerHand);
        PlaseTileToPanel(_stack, tilePanel);
        debug.text = $"Вся колода:{_stack.Count}";
                
    }

    private void CreateDeck()
    {
        _deck = new List<Card>();
        EnumGameObjValue tileValue;
        int countValue = Enum.GetValues(typeof(EnumGameObjValue)).Length - 1;
        for (int i = 0; i < 102; i++)
        {
            tileValue = (EnumGameObjValue)(i % countValue);
            _deck.Add(new Card(tileValue, $"Sprites/Logo/{tileValue}"));
        }
        _deck.Shuffle();
    }

    void GiveHandCard(List<Card> deck, Transform hand)
    {
        int i = 0;
        while (i++ < 6)
            CreateCardToPlaeyrHand(deck, hand);
    }

    void CreateCardToPlaeyrHand(List<Card> deck, Transform hand)
    {
        if (deck.Count == 0)
            return;
        Card card = deck[0];
        GameObject cardGO = Instantiate(cardPref, hand, false);
        cardGO.GetComponent<CardInfo>().ShowLogoInfo(card);
        deck.RemoveAt(0);
    }

    private void CreateTileStack()
    {
        _stack = new List<Tile>();
        EnumGameObjValue tileValue;
        int countValue = Enum.GetValues(typeof(EnumGameObjValue)).Length - 1;

        for (int i = 0; i < 6; i++)
        {
            tileValue = (EnumGameObjValue)(i % countValue);
            _stack.Add(new Tile(tileValue, $"Sprites/Logo/{tileValue}"));
        }
        _stack.Shuffle();
    }
    void CreateTileonStack(List<Tile> _stack, Transform _tileStack)
    {
        if (_stack.Count == 0)
            return;
        Tile tile = _stack[0];
        GameObject tileGO = Instantiate(tilePref, _tileStack, false);
        tileGO.GetComponent<LogoInfo>().ShowLogoInfo(tile);
        _stack.RemoveAt(0);
    }

    void PlaseTileToPanel(List<Tile> _stack, Transform _tileStack)
    {
        int i = 0;
        while (i++ < 6)
            CreateTileonStack(_stack, _tileStack);
    }
}
