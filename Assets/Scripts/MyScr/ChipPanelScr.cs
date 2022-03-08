using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;

public class ChipPanelScr : MonoBehaviour , IPointerClickHandler
{
    [SerializeField] private GameObject Chip;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public List<ChipScr> InitPanel(Color color)
    {
        List<ChipScr> Chips = new List<ChipScr>();
        for (int i = 0; i < 6; i++)
        {
            var currentChip = Instantiate(Chip, transform, false).GetComponent<ChipScr>();
            currentChip.ChipInit(color);
            Chips.Add(currentChip);
        }
        return Chips;
    } 

    public void OnPointerClick(PointerEventData eventData)
    {
        
    }
}
