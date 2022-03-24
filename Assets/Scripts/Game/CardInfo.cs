﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class CardInfo : BaseInfo, IObservable, IPointerClickHandler
{
    [SerializeField] private TextMeshProUGUI _textCount;
    private Animator _animTextAddCount;
    private int _countCard = 0;
    
    
    private List<PlayerScr> _observers = new List<PlayerScr>();

    public int GetCount => _countCard;
    public void InitCard(EnumCardValue cardValue)
    {
        path = $"Sprites/Game/Logo/{cardValue}";
        Value = cardValue;
        base.SetLogo();
    }

    public void AddCard()
    {
        PlayAnimation();
        _countCard++;
        _textCount.text = _countCard.ToString();
        
    }
    public void PlayAnimation()
    {
        _animTextAddCount = GetComponentInChildren<Animator>();
        _animTextAddCount.SetTrigger("Play");
    }
    public bool RemoveCard()
    {
        if (_countCard > 0)
        {
            _countCard--;
            _textCount.text = _countCard.ToString();
            return true;
        }
        return false;
    }

    public void AddObserver(MonoBehaviour o)
    {
        _observers.Add(o.GetComponent<PlayerScr>());
    }

    public void RemoveObserver(MonoBehaviour o)
    {
        _observers.Remove(o.GetComponent<PlayerScr>());
    }

    public void NotifyObservers()
    {
        foreach (var item in _observers)
        {
            item.PlayCard(Value);
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        NotifyObservers();
    }
}

