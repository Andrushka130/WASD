using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicPlayerScript : MonoBehaviour
{
   public Slider volumeSlider;
   public GameObject objectMusic;
   private float musicVolume = 0f;
   private AudioSource AudioSource;

   private void Start()
   {
      objectMusic = GameObject.FindWithTag("GameMusic");
      AudioSource = objectMusic.GetComponent<AudioSource>();

      //Set Volume
      musicVolume = PlayerPrefs.GetFloat("volume");
      AudioSource.volume = musicVolume;
      if(volumeSlider != null)
      {
         volumeSlider.value = musicVolume;
      }

   }

   private void Update()
   {
      AudioSource.volume = musicVolume;
      PlayerPrefs.SetFloat("volume", musicVolume);
   }

   public void updateVolume(float volume)
   {
      musicVolume = volume;
   }

   public void MusicReset()
   {
      PlayerPrefs.DeleteKey("volume");
      AudioSource.volume = 1;
      volumeSlider.value = 1;
   }
}
