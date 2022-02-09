using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHandsScr : MonoBehaviour
{
    [SerializeField] private GameObject cardPref;
    private List<GameObject> tilesOnHands;
    private int numberCard = 0;
    void Start()
    {
    }

    public void CreateTilesOnHands()
    {
        tilesOnHands = new List<GameObject>();
        for (int i = 0; i < 6; i++)
        {
            var card = (EnumCardValue)i;
            GameObject cardGO = Instantiate(cardPref, transform, false);
            cardGO.GetComponent<CardInfo>().initCard(card);
            tilesOnHands.Add(cardGO);
        }
    }

    public void TakeCardPlayer(EnumCardValue card)
    {
        var go = tilesOnHands.FirstOrDefault(c => c.GetComponent<CardInfo>().GetValue == card);
        go.GetComponent<CardInfo>().AddCard();
    }

    // Update is called once per frame
    void Update()
    {

        if (Time.deltaTime > 5)
        {
            tilesOnHands[numberCard % tilesOnHands.Count].GetComponent<CardInfo>().AddCard();
            numberCard++;
        }

    }
}
