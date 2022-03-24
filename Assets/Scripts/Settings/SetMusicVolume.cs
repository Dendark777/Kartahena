using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetMusicVolume : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    // Start is called before the first frame update
    void Start()
    {
        GameManager.Setting.InitMusicAudioSource(_audioSource);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
