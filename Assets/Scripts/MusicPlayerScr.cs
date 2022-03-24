using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayerScr : MonoBehaviour
{
    [SerializeField] private List<AudioClip> clips;
    [SerializeField] private AudioSource audio;
    private void Start()
    {
        audio = FindObjectOfType<AudioSource>();
        audio.loop = false;
    }
   private AudioClip GetRandomClip()
    {
        return clips[Random.Range(0,clips.Count)];
    }

    private void Update()
    {
        if(!audio.isPlaying)
        {
            audio.clip = GetRandomClip();
            audio.Play();
        }
    }
}
