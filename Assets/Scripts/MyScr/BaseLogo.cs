using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class BaseLogo : MonoBehaviour
{
    [SerializeField] protected Image logo;
    protected string path;
    public void SetLogo()
    {
        logo.sprite = Resources.Load<Sprite>(path);
        logo.preserveAspect = true;
    }

}
