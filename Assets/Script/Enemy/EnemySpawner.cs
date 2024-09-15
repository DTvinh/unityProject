using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class EnemySpawner : Spawner
{

    public static EnemySpawner Instance;
    public static string skeletonEnemyStr = "SkeletonEnemy";
    public static string slyEyeEnemySrt = "FlyEyeEnemy";

    protected override void Awake()
    {
        base.Awake();
        if (Instance == null)
        {
            Instance = this;
        }
    }
    protected override void Start()
    {

        // StartSpawner();
    }
    protected override void Update()
    {

    }
    // public GameObject EnemySpawn()
    // {
    //     GameObject newObj = Spawn(posSpawn.transform.position, Quaternion.identity);
    //     newObj.transform.position = posSpawn.transform.position;
    //     return newObj;
    // }




}