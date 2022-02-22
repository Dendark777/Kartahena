using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class LogoInfo : MonoBehaviour
{
    public GameObj selfGO;
    [SerializeField] public Image logo;
    [SerializeField] public List<GameObject> chipsPosition;
    [SerializeField] Material material;
    public int bisyChipPlaceCount;


    public void ShowLogoInfo(GameObj _go)
    {
        selfGO = _go;
        logo.sprite = _go.logo;
        logo.preserveAspect = true;
    }
    private void Start()
    {
       
    }

    public void ActiveTile()
    {
        GetComponent<Image>().material = material;
        logo.material = material;
    }
}