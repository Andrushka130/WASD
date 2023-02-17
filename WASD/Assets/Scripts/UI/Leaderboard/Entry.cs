using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Entry : MonoBehaviour
{
    [SerializeField] private Transform entryTemplate;
    [SerializeField] private Transform entryContainer;

    private Database db = new Database();
  
   
    async void Awake()
    {
        
        entryTemplate.gameObject.SetActive(false);

        PlayerData[] result = await db.GetHighscore();
        for(int i = 0; i < result.Length; i++)
        {
            Transform entry = Instantiate(entryTemplate, entryContainer);
            entry.Find("TextPos").GetComponent<TextMeshProUGUI>().text = (i+1).ToString();
            entry.Find("TextName").GetComponent<TextMeshProUGUI>().text = result[i].PlayerTag;
            entry.Find("TextScore").GetComponent<TextMeshProUGUI>().text  = result[i].Highscore.ToString();
            entry.gameObject.SetActive(true);       
        }
    }

   


}
