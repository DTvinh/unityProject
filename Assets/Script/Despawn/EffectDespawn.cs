using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectDespawn : DespawnByTime
{
    public override void DespawnObject()
    {
        EffectSpawner.Instance.Despawn(gameObject);
    }
}
