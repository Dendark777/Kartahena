using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHandsScr : MonoBehaviour
{
    [SerializeField] private GameObject cardPref;
    private List<GameObject> cards;
    private int numberCard = 0;
    void Start()
    {
        var fieldHands = GetComponent<Transform>();
        cards = new List<GameObject>();
        for (int i = 0; i < 6; i++)
        {
            var card = new Card((EnumCardValue)i);
            GameObject cardGO = Instantiate(cardPref, fieldHands, false);
            cardGO.GetComponent<CardInfo>().ShowLogoInfo(card.LogoPath);
            cards.Add(cardGO);
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (Time.deltaTime > 5)
        {
            cards[numberCard % cards.Count].GetComponent<CardInfo>().AddCard();
            numberCard++;
        }

    }
}
