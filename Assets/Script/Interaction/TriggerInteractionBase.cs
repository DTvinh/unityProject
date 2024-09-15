using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerInteractionBase : MonoBehaviour, Interectable
{
    public GameObject Player { get ; set; }
    public bool CanInteract { get ; set; }

  

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (CanInteract)
        {
            Interact();
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) {
        CanInteract=true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        //if (collision.gameObject == Player)
        //{

        //    CanInteract = false;
        //}
        if (collision.CompareTag("Player"))
        {
            CanInteract = false;
        }
    }
    public virtual void  Interact()
    {

    }
}
