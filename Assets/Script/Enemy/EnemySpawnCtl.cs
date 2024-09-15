using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnCtl : MonoBehaviour
{


    [SerializeField] public int amount;
    [SerializeField] public GameObject enemySpawn;
    [SerializeField] public Transform Point;
    EnemySpawner enemySpawner;
    private void Awake()
    {
        enemySpawner = GetComponent<EnemySpawner>();
    }
    void Start()
    {
        StartSpawner();
    }

    // Update is called once per frame
    void Update()
    {
        // SpawnerRefresh();
    }

    private void StartSpawner()
    {

        for (var i = 0; i < amount; i++)
        {
            GameObject EnemyObj = enemySpawner.Spawn(enemySpawn.name, Point.transform.position, Quaternion.identity);

            EnemyObj.SetActive(true);
        }
    }

    void TemerSpawner()
    {
        // GameObject EnemyObj = enemySpawner.Spawn(Point.transform.position, Quaternion.identity);
        // EnemyObj.SetActive(true);
    }

}
