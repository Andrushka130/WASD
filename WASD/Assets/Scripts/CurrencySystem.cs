using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrencySystem : MonoBehaviour
{
    public int money;

    //Textanzeige in UI erg�nzen

    void OnDestroy()
    {
        //UpdateMoney();
        GainMoney(20);
    }

    //Erh�hen der Anzeige, wenn Geld eingesammelt wird
    /*public void UpdateMoney()
    {
       
    }*/

    public void GainMoney(int moneyGained)
    {
        money += moneyGained;
    }
}
