
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SoundVolumeControllerScr : MonoBehaviour
{

    [Header("Components")]
    [SerializeField] private Slider slider;
    [SerializeField] TextMeshProUGUI textVolume;

    //[Header("Keys")]
    //[SerializeField] private string saveVolumeKey;

    //[Header("Tags")]
    //[SerializeField] private string sliderTag;
    //[SerializeField] private string textVolumeTag;

    [Header("Parameters")]
    [SerializeField] private float volume;

    private AudioSource _musiAudioSource;
    private void Awake()
    {
        _musiAudioSource = GameManager.Setting.MusicAudioSource;
        //volume = PlayerPrefs.GetFloat(saveVolumeKey);
        volume = _musiAudioSource.volume;
        slider.value = volume;

        //GameObject sliderObj = GameObject.FindWithTag(sliderTag);
        if (slider != null)
        {
            //slider = sliderObj.GetComponent<Slider>();
        }
    }

    public void SetVolumeMusic()
    {
        volume = slider.value;
        
        if (textVolume != null)
        {
            textVolume.text = $"{Mathf.Round(volume * 100)}";
        }
        _musiAudioSource.volume = volume;
    }

    private void LateUpdate()
    {

    }

}
