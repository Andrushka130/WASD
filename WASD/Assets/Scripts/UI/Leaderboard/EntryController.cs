using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EntryController : MonoBehaviour
{
    [SerializeField] private Transform entryTemplate;
    [SerializeField] private Transform entryContainer;
  
   
    void Awake()
    {
        
        entryTemplate.gameObject.SetActive(false);

        StartCoroutine(Database.GetHighscore( result => {
            PlayerData[] highscores = PlayerData.ParseAll(result).Items;
                for(int i = 0; i < highscores.Length; i++)
                {
                Transform entry = Instantiate(entryTemplate, entryContainer);
                Debug.Log("Instantiate");
                entry.Find("TextPos").GetComponent<TextMeshProUGUI>().text = (i+1).ToString();
                entry.Find("TextName").GetComponent<TextMeshProUGUI>().text = highscores[i].PlayerTag;
                entry.Find("TextScore").GetComponent<TextMeshProUGUI>().text  = highscores[i].Highscore.ToString();
                entry.gameObject.SetActive(true);       
                }
        })); 
 
      

       
        
    }


}
