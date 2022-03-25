using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Settings
{
    public AudioSource MusicAudioSource { get; set; }

    public Settings(float volumeMusic = 0.5f)
    {
    }

    public void InitMusicAudioSource(AudioSource musicAudioSource)
    {
        MusicAudioSource = musicAudioSource;
    }
}
