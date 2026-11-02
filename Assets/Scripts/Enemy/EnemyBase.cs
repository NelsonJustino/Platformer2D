using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    public int damage = 5;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var health = collision.gameObject.GetComponent<HealthBar>();

        if(health != null)
        {
            Debug.Log(collision.transform.name);
            health.Damage(damage);
        }
    }

}
