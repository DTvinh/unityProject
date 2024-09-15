using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : Spawner
{
    // Start is called before the first frame update
    public static BulletSpawner Instance;
    public static string bulletName = "EnergyBall_0";

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
    protected override void Update()
    {

    }
    // public override GameObject Spawn(Vector3 spawnPos, Quaternion rotation)
    // {
    //     GameObject newObj = Instantiate(objectToPool, spawnPos, rotation);
    //     return newObj;

    // }

}
