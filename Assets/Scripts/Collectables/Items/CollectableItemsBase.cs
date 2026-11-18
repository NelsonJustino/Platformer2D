using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableItensBase : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.CompareTag("Player"))
        {
            Collect();
        }
    }
    protected virtual void Collect()
    {
        Debug.Log("Item Collected");
        OnCollect();
        Destroy(gameObject);
    }

    protected virtual void OnCollect()
    {
        Debug.Log("On Collect");
    }
}
