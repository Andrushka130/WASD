using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntryController : MonoBehaviour
{
    public EntryUI entryUI;
    public PlayerData[] highscores;
   
    void Start()
    {
        /* 
        StartCoroutine(Database.GetHighscore( result => {
          highscores = PlayerData.ParseAll(result).Item;
        })); 
        */
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
