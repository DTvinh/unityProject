using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LegdeCheck : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] float radius;
    [SerializeField] PlayerController player;
    [SerializeField] LayerMask LayerCheck;
    bool canDeteced;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (canDeteced)
        {
            player.ledgeDeteced = Physics2D.OverlapCircle(transform.position, radius, LayerCheck);


        }

    }
    private void OnTriggerEnter2D(Collider2D _other)
    {
        if (_other.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            canDeteced = false;
        }
    }
    private void OnTriggerExit2D(Collider2D _other)
    {
        if (_other.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            canDeteced = true;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
