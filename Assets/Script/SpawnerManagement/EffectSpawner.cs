using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectSpawner : Spawner
{
    public static EffectSpawner Instance;
    public static string effectExplosion = "Explosion_Enegry";
    public static string effectHit = "EffectHit";

    protected override void Awake()
    {
        base.Awake();
        if (Instance == null)
        {
            Instance = this;
        }
        DontDestroyOnLoad(gameObject);

    }
    protected override void Start()
    {

    }

    // Update is called once per frame
    protected override void Update()
    {

    }
}
