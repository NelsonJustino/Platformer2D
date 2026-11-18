using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableManager : MonoBehaviour
{
    public static CollectableManager Instance;
    public int coin;

    private void Awake()
    {
       if(Instance == null)
        {
            Instance = this;
        } 
        else
        {
            Destroy(gameObject);
        }
    }

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
