
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SoundVolumeControllerScr : MonoBehaviour
{
   
    [Header("Components")]
    [SerializeField] private AudioSource audio;
    [SerializeField] private Slider slider;
    [SerializeField] TextMeshProUGUI textVolume;
    
    [Header("Keys")]
    [SerializeField] private string saveVolumeKey;

    [Header("Tags")]
    [SerializeField] private string sliderTag;
    [SerializeField] private string textVolumeTag;

    [Header("Parameters")]
    [SerializeField] private float volume;

    private void Awake()
    {
        if (PlayerPrefs.HasKey(saveVolumeKey))
        {
            volume = PlayerPrefs.GetFloat(saveVolumeKey);
            audio.volume = volume;

            GameObject sliderObj = GameObject.FindWithTag(sliderTag);
            if (slider != null)
            {
                slider = sliderObj.GetComponent<Slider>();
                slider.value = volume;
            }
        }
        else
        {
            volume = 0.5f;
            PlayerPrefs.SetFloat(saveVolumeKey,volume);
            audio.volume = volume;
        }
    }

    private void LateUpdate()
    {
        GameObject sliderObj = GameObject.FindWithTag(sliderTag);
        if(slider!=null)
        {
            slider = sliderObj.GetComponent<Slider>();
            volume = slider.value;

            if (audio.volume!=volume)
            {
                PlayerPrefs.SetFloat(saveVolumeKey,volume);
            }

            GameObject textVolumeObj = GameObject.FindWithTag(textVolumeTag);
            if(textVolume!=null)
            {
                textVolume = textVolumeObj.GetComponent<TextMeshProUGUI>();
                textVolume.text = $"{Mathf.Round(volume * 100)}";
            }
        }

        audio.volume = volume;
    }

}
