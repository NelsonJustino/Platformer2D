using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Scripts.Core.Singleton;

public class CollectableManager : Singleton<CollectableManager>
{

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
    }
}
