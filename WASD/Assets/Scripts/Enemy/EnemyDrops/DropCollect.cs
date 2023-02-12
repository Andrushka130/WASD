using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropCollect : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Experience")|| collider.gameObject.CompareTag("Eurodollar"))
        {
            if(collider.gameObject.CompareTag("Experience"))
            {
                WalletManager.AddMoney(1);
            }
            Destroy(collider.gameObject);
        }
    }
}
