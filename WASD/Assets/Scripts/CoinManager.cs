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

    public static void AddMoney( int money)
    {
        wallet += money;
    }

    public static void RemoveMoney(int amount)
    {
        wallet -= amount;
    }
}