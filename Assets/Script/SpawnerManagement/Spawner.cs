using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    // [SerializeField] public int amount;
    // [SerializeField] protected GameObject objectToPool;
    [SerializeField] protected List<GameObject> objectsList;
    [SerializeField] protected List<GameObject> poolObjs;
    protected Transform holder;


    // Start is called before the first frame update
    protected virtual void Awake()
    {

        // base.Awake();
        holder = transform.Find("Holder");
    }
    protected virtual void Start()
    {
        // AddObjectToList();
    }

    // Update is called once per frame
    protected virtual void Update()
    {

    }

    // protected void AddObjectToList()
    // {
    //     Debug.Log("vinh");
    //     for (int i = 0; i < amount; i++)
    //     {
    //         GameObject objSpawn = Instantiate(objectToPool);
    //         objectsLisst.Add(objSpawn);
    //         objSpawn.SetActive(false);
    //     }
    // }

    public virtual GameObject Spawn(string prefabName, Vector3 spawnPos, Quaternion rotation)
    {

        GameObject prefab = GetObjByName(prefabName);
        if (prefab == null)
        {
            return null;
        }
        GameObject newObj = GetObjectFromPool(prefabName, prefab);
        newObj.transform.position = spawnPos;
        return newObj;
    }

    public virtual GameObject GetObjectFromPool(string prefabName, GameObject objectToPool)
    {
        foreach (var poolObj in poolObjs)
        {
            if (poolObj.name == objectToPool.name)
            {
                poolObjs.Remove(poolObj);
                return poolObj;
            }
        }

        GameObject newObj = Instantiate(objectToPool);
        newObj.name = prefabName;
        newObj.transform.parent = holder;

        newObj.SetActive(false);
        return newObj;
    }

    protected virtual GameObject GetObjByName(string Objname)
    {
        foreach (var obj in objectsList)
        {
            if (obj.name == Objname)
            {
                return obj;
            }
        }
        return null;

    }

    public virtual void Despawn(GameObject obj)
    {
        poolObjs.Add(obj);
        obj.SetActive(false);
        // }
        // public GameObject GetRandom()
        // {
        //     int indexRandom = Random.Range(0, objectsLisst.Count);
        //     return objectsLisst[indexRandom];
    }



}
