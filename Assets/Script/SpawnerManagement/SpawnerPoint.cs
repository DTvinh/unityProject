using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerPoint : MonoBehaviour
{
    [SerializeField] public List<Transform> Points;


    void Awake()
    {
        LoadPoint();
    }

    private void Reset()
    {
        LoadPoint();
    }

    void LoadPoint()
    {
        if (Points.Count > 0) { return; }
        Transform prefabObjs = transform.Find("Prefab");
        foreach (Transform point in transform)
        {
            Points.Add(point);
        }
    }
}
