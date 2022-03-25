
using UnityEngine;


public class BtnSfxScr : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip hoverFX;
    public AudioClip clickFX;

    
    public void SoundOnPointerEnter()
    {
        audioSource.PlayOneShot(hoverFX);
    }

    public void SoundOnPointerClick()
    {
        audioSource.PlayOneShot(clickFX);
    }
}
