using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = transform.right * 20;
        OnDestroy();
    }


    private void OnDestroy()
    {
        Destroy(gameObject,5f);
    }
}
