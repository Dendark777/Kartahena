
using UnityEngine;
using UnityEngine.UI;

public class ToggleSpriteScr : MonoBehaviour
{
    [SerializeField] private Image image;
    [SerializeField] private Sprite sprite1, sprite2;

    public void OnToggle(bool check)
    {
        if (check)
            image.sprite = sprite1;
        if (!check)
            image.sprite = sprite2;
    }

}
