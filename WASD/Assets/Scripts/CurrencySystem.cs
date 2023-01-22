using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrencySystem : MonoBehaviour
{

    //Textanzeige in UI erg�nzen

    void OnDestroy()
    {
        //UpdateMoney();
        WalletManager.AddMoney(20);
    }

    //Erh�hen der Anzeige, wenn Geld eingesammelt wird
    //public void UpdateMoney()

}
