using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class CardInfo : LogoInfo,IClickable
{
    
    [SerializeField] public TextMeshProUGUI TMProcardCount;
    [SerializeField] public Image Image;
    [SerializeField] public Material Material;
    [SerializeField] public GameObject ChipMoveController;
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
        ChipMoveController.GetComponent<ChipMoveControllerScr>().ChipMove(this);
    }
   

}

