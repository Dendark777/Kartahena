using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dessolve : MonoBehaviour
{
    private Material material;

    
    float fade = 1f;
    private void Start()
    {
        material = GetComponent<Image>().material;
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            fade -= Time.deltaTime;
            if(fade<=0f)
            {
                fade = 0f;
               
            }
            material.SetFloat("_Fade", fade);
        } 

       if(Input.GetKeyDown(KeyCode.E))
       {
            fade += Time.deltaTime;
            if(fade>=1f)
            {
                fade = 1f;
              
            }
            material.SetFloat("_Fade", fade);
        }
    }
}
