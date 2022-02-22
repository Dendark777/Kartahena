using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardClicked : MonoBehaviour,IClickable
{
    void Click()
    {

    }

    void IClickable.Click()
    {
        throw new System.NotImplementedException();
    }
}
