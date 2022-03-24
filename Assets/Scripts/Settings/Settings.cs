using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Settings
{
    public AudioSource MusicAudioSource { get; set; }

    public Settings(float volumeMusic = 1)
    {
    }

    public void InitMusicAudioSource(AudioSource musicAudioSource)
    {
        MusicAudioSource = musicAudioSource;
    }
}
