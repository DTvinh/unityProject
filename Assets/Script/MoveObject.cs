using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEditor;
using UnityEngine;

public class MoveObject : MonoBehaviour
{
    public List<Vector2> listPoint;
    public float speed;
    Vector2 target;
    bool checkWay = true;
    int currentID = 0;

    void Start()
    {
        target = transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        Move();
        TargetPos();
    }

    private void Move()
    {
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
    }
    void TargetPos()
    {
        if (Vector2.Distance(transform.position, target) > 0.5f) { return; }

        if (checkWay)
        {
            currentID++;
            if (currentID >= listPoint.Count)
            {
                currentID = listPoint.Count - 2;
                checkWay = false;
            }
        }
        else
        {
            currentID--;
            if (currentID <= 0)
            {
                currentID = 0;
                checkWay = true;
            }
        }

        target = listPoint[currentID];
    }

    private void OnDrawGizmos()
    {
        if (listPoint.Count == 0)
        {
            return;
        }
        Gizmos.color = Color.green;
        for (int i = 0; i < listPoint.Count - 1; i++)
        {
            Gizmos.DrawLine(listPoint[i], listPoint[i + 1]);
        }
    }

}
