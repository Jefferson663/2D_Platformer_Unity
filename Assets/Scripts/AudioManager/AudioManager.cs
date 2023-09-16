using UnityEngine.Audio;
using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private Sound[] audioFiles;

    private void Awake()
    {
        GenerateGameAudio();
    }

    private void GenerateGameAudio()
    {
        foreach (Sound audio in audioFiles)
        {
            audio.source = gameObject.AddComponent<AudioSource>();
            audio.source.clip = audio.audioToPlay;
            audio.source.volume = audio.volume;
            audio.source.pitch = audio.pitch;
            audio.source.playOnAwake = false;
        }
    }
    public void PlaySound(string soundName)
    {
        Sound sound = Array.Find(audioFiles, sound  => sound.name == soundName);
        sound.source.Play();
    }
}
