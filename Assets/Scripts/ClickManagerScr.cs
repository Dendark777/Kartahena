using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickManagerScr : MonoBehaviour
{
    [SerializeField] private new Camera camera;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePos = camera.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero);
            if(hit)
            {
                IClickable clickable = hit.collider.GetComponent<IClickable>();
                clickable?.Click();
            }
        }

    }
}
