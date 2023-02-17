using UnityEngine.UI;
using UnityEngine;


public class ButtonSoundManager : MonoBehaviour
{
   [SerializeField] private Slider musicSlider = null;
   [SerializeField] private Slider sfxSlider = null;

   private float musicVolume = 1f;
   private float sfxVolume = 1f;

   private void Start()
   {
      if(!PlayerPrefs.HasKey("MusicVolume") || !PlayerPrefs.HasKey("SfxVolume"))
      {
        PlayerPrefs.SetFloat("MusicVolume", musicVolume);
        PlayerPrefs.SetFloat("SfxVolume", sfxVolume);
        Load();
        ChangeMusicVolume(musicVolume);
        ChangeSfxVolume(sfxVolume);
      }
      else
      {
         Load();
         ChangeMusicVolume(musicVolume);
         ChangeSfxVolume(sfxVolume);
      }
   }

   public void ClickedButton()
   {
      FindObjectOfType<AudioManager>().Play("ButtonClicked");
   }

   public void ClickedReroll()
   {
     FindObjectOfType<AudioManager>().Play("Reroll");
   }

   public void ChangeMusicVolume(float volume)
   {
      if(musicSlider != null)
      {
         musicSlider.value = volume;
         SaveVolume();
      }
      FindObjectOfType<AudioManager>().ChangeMusicVolume("Don't Decay", volume);
   }

   public void ChangeSfxVolume(float volume)
   {
      if(sfxSlider != null)
      {
         sfxSlider.value = volume;
         SaveVolume();
      }
      FindObjectOfType<AudioManager>().ChangeSfxVolume(volume);
   }

   private void SaveVolume()
   {
      PlayerPrefs.SetFloat("MusicVolume", musicSlider.value);
      PlayerPrefs.SetFloat("SfxVolume", sfxSlider.value);
   }

   private void Load()
   {
      musicVolume =  PlayerPrefs.GetFloat("MusicVolume");
      sfxVolume =  PlayerPrefs.GetFloat("SfxVolume");
   }
}
