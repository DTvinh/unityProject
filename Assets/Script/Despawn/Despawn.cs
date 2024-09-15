using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Despawn : MonoBehaviour
{


    protected virtual void FixedUpdate()
    {
        Despawning();
    }
    protected virtual void Despawning()
    {

        if (!CanDespawm())
        {
            return;
        }
        DespawnObject();
    }

    protected abstract bool CanDespawm();
    public virtual void DespawnObject()
    {
        Destroy(gameObject);
    }



}
