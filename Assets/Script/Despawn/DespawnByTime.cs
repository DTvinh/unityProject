using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DespawnByTime : Despawn
{
    [SerializeField] protected float timeDes;
    float timer;

    protected void OnEnable()
    {
        ResetTimeDes();
    }

    // Update is called once per frame
    protected override void FixedUpdate()
    {
        base.FixedUpdate();
        CanDespawm();
    }
    private void ResetTimeDes()
    {
        timer = 0;
    }

    protected override bool CanDespawm()
    {
        timer += Time.fixedDeltaTime;
        if (timer >= timeDes)
        {
            return true;
        }
        return false;
        // EffectSpawner.Instance.Despawn(gameObject);

    }
}
