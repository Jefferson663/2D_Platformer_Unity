using UnityEngine.Audio;
using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private Sound[] sounds;

    private void Awake()
    {
        foreach(Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;

            s.source.playOnAwake = false;
        }
    }

    public void PlaySound(string soundName)
    {
        Sound s = Array.Find(sounds, sound  => sound.name == soundName);
        s.source.Play();
    }
}
