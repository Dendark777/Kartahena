using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dessolve : MonoBehaviour
{
    private Material material;

    bool isDissolving = false;
    float fade = 1f;
    private void Start()
    {
        material = GetComponent<Image>().material;
    }
    private void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            isDissolving = true;
        }

        if (isDissolving)
        {
            fade -= Time.deltaTime;
            if (fade <= 0f)
            {
                fade = 0f;

            }
            material.SetFloat("_Fade", fade);
        }

        if (Input.GetKey(KeyCode.E))
        {
            isDissolving = false;
            fade = 1f;
            material.SetFloat("_Fade", fade);
        }
    }
}
