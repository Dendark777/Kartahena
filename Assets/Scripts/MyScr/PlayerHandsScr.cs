using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHandsScr : MonoBehaviour
{
    [SerializeField] private GameObject cardPref;
    private List<CardInfo> cardsOnHands;
    private int numberCard = 0;
    void Start()
    {
    }

    public void CreateTilesOnHands()
    {
        cardsOnHands = new List<CardInfo>();
        for (int i = 0; i < 6; i++)
        {
            var card = (EnumCardValue)i;
            GameObject cardGO = Instantiate(cardPref, transform, false);
            cardsOnHands.Add(cardGO.GetComponent<CardInfo>());
            cardsOnHands[i].InitCard(card);
        }
    }

    public void TakeCardPlayer(EnumCardValue card)
    {
        var cardInfo = cardsOnHands.FirstOrDefault(c => c.GetValue == card);
        cardInfo.AddCard();
    }

    // Update is called once per frame
    void Update()
    {
    }
}
