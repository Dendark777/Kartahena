using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetMusicVolume : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    
    void Start()
    {
        GameManager.Setting.InitMusicAudioSource(_audioSource);
    }

    
    void Update()
    {

    }
}
