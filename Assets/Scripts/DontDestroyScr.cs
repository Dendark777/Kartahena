using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyScr : MonoBehaviour
{
    public static DontDestroyScr instance;
    private void Start()
    {
        if(instance!=null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
}
