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

    [Header("Death Animation")]
    public Animator animator;
    public string deathBool = "Bool_Death";

    private Player _player;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        _player = GetComponent<Player>();

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
        if (_isDead) return;

        _isDead = true;

        if (_player != null)
        {
            _player.enabled = false;
        }

        if (animator != null)
        {
            animator.SetBool(deathBool, true);
        }

        if (destroyOnKill == true)
        {
            Destroy(gameObject, delayToKill);
        }
    }
}
