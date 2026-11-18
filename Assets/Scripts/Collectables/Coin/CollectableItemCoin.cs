using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableItemCoin : CollectableItensBase
{
    protected override void OnCollect()
    {
        base.OnCollect();
        CollectableManager.Instance.AddCoin();
    }
}
