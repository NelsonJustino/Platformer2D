using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    public int startingLife = 10;
    public bool destroyOnKill = false;
    public float delayToKill;

    private bool _isDead = false;
    private int _currentLife;

    private void Awake()
    {
        Init();
    }

    public void Init()
    {
        _currentLife = startingLife;
       _isDead = false;
    }

    public void Damage(int damage)
    {
        if (_isDead) return;

        _currentLife -= damage;

        if (_currentLife <= 0)
        {
            Death();
        }
    }

    public void Death()
    {
        _isDead = true;

       if(destroyOnKill == true)
        {
            Destroy(gameObject,delayToKill);
        }
    }
}
