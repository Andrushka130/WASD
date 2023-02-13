using UnityEngine.Audio;
using UnityEngine.UI;
using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
   public Sound[] sounds;
   
   public static AudioManager instance;
   
    void Awake() {
        
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        
        DontDestroyOnLoad(this.gameObject);
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }

    }

    void Start()
    {
        Play("Don't Decay");
    }

    public void Play(String name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if(s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }
        s.source.Play();
    }

    public void ChangeMusicVolume(string name, float sliderValue)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if(s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }
        s.volume = sliderValue;
        s.source.volume = s.volume;
    }

     public void ChangeSfxVolume(float sliderValue)
    {
        foreach (Sound s in sounds)
        {
            if(s.name != "Don't Decay")
            {
                s.volume = sliderValue;
                s.source.volume = s.volume;
            }
        }
    }

}
