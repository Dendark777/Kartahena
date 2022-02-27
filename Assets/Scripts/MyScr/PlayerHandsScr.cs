using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHandsScr : MonoBehaviour
{
    [SerializeField] private GameObject cardPref;
    private List<CardInfo> _cardsOnHands;
    public List<CardInfo> GetCardsOnHands => _cardsOnHands;

    void Start()
    {
    }

    public void CreateTilesOnHands()
    {
        _cardsOnHands = new List<CardInfo>();
        for (int i = 0; i < 6; i++)
        {
            var card = (EnumCardValue)i;
            GameObject cardGO = Instantiate(cardPref, transform, false);
            _cardsOnHands.Add(cardGO.GetComponent<CardInfo>());
            _cardsOnHands[i].InitCard(card);
        }
    }

    public bool PlayCard(EnumCardValue card)
    {
        var playCard = _cardsOnHands.FirstOrDefault(c => c.GetValue == card);
        return playCard.RemoveCard();
    }

    public void TakeCardPlayer(EnumCardValue card)
    {
        var cardInfo = _cardsOnHands.FirstOrDefault(c => c.GetValue == card);
        cardInfo.AddCard();
    }

    // Update is called once per frame
    void Update()
    {
    }
}
