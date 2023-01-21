using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CoinManager : MonoBehaviour
{
    private static int wallet;

    public static int Wallet
    {
        get { return wallet; }
    }

    private static void Awake()
    {
        wallet = 0;
    }

    public static void AddCoin( int coins)
    {
        wallet += coins;
    }

    public static void RemoveCoin(int amount)
    {
        wallet -= amount;
    }
}