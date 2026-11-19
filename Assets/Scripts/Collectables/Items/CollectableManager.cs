using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Scripts.Core.Singleton;

public class CollectableManager : Singleton<CollectableManager>
{
    public TextMeshProUGUI tmp_Coins;

    public int coin;
   
    private void Start()
    {
        Reset();
    }

    private void Reset()
    {
        coin = 0;
    }

    public void AddCoin(int amount = 1)
    {
        coin += amount;
        tmp_Coins.text = "x " + coin.ToString("D2");
    }
}
