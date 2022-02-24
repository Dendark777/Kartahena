using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;
public class CardInfo : LogoInfo, IClickable
{

    [SerializeField] public TextMeshProUGUI TMProcardCount;
    [SerializeField] public Image Image;
    [SerializeField] public Material Material;
    [SerializeField] public GameObject ChipMoveController;
    [SerializeField] public GameObject tilePanel;
    public List<GameObject> tileMap;
    public UnityEvent HitMoveChipEvent;

    public int cardCount;

    private void Update()
    {

    }
    public void UnactiveCard()
    {
        TMProcardCount.text = $" ";
        Image.material = null;
        logo.material = null;
        return;
    }
    public void Click()
    {
        var _ChipMoveController = ChipMoveController.GetComponent<ChipMoveControllerScr>();
        _ChipMoveController.currentCardValue = $"{Image.sprite}";


        if (_ChipMoveController.currentSelectChip != null)
        {
            GetComponent<SubtractionCard>().subtractionCoundCard();
            _ChipMoveController.ChipMove();
            //HitMoveChipEvent.Invoke();
        }

        else
        {
            print("Выберите фишку!");

        }
    }


}

