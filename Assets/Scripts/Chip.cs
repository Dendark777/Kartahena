using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Chip : MonoBehaviour,IClickable
{
    private Outline outline; 

    void Start()
    {
        outline = GetComponent<Outline>();
    }
public void Click()
{
        outline.enabled = !outline.enabled;
}
}