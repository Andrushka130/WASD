using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CoinManager : MonoBehaviour
{
    private static int coins;

    public static int Coins
    {
        get { return coins; }
    }

    private static void Awake()
    {
        coins = 0;
    }

    public static void AddCoin()
    {
        coins++;
    }

    public static void RemoveCoin(int amount)
    {
        coins -= amount;
    }
}