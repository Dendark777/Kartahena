using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CardManagerScr : MonoBehaviour
{


    [SerializeField] private DeckManagerScr deckGO;
    public Transform cardPanel;
    public GameObject cardPref;
    public List<GameObject> cardsGO;
    private DeckManagerScr deckManagerScr;



    private void Start()
    {
        deckManagerScr = new DeckManagerScr();

        CreateCardGOonCardPanel(deckManagerScr.deckGO, cardPanel);
        for (int i = 0; i < 6; i++)
        {
            AddCardToPlayerHand(deckManagerScr.deck);
        }

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            AddCardToPlayerHand(deckManagerScr.deck);
        }
    }




    void CreateCardGOonCardPanel(List<Card> deck, Transform _panel)
    {

        foreach (Card card in deck)
        {
            GameObject cardGO = Instantiate(cardPref, _panel, false);
            cardGO.GetComponent<CardInfo>().ShowLogoInfo(card);
            cardsGO.Add(cardGO);
        }
    }
    void AddCardToPlayerHand(List<Card> deck)
    {
        if (deck.Count == 0) return;
        Card card = deck[0];

        foreach (GameObject elem in cardsGO)
        {
            var cardInfo = elem.GetComponent<CardInfo>();

            if ($"{card.logo}" == $"{cardInfo.logo.sprite}")
            {
                cardInfo.cardCount++;
                cardInfo.TMProcardCount.text = $"{cardInfo.cardCount}";
                cardInfo.Image.material = cardInfo.Material;
                cardInfo.logo.material = cardInfo.Material;
            }
        }


        deck.RemoveAt(0);


        //print(deck.Count);

    }





}
