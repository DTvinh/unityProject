using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptRock : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("Destroy", 4f);
    }
    private void OnCollisionEnter2D(Collision2D _other)
    {

        IDamageAble isCanTakeDamage = _other.gameObject.GetComponent<IDamageAble>();

        if(isCanTakeDamage != null)
        {
            isCanTakeDamage.TakeDamage(4);
            Debug.Log("vo dau ");
        }
        
        
    }
    private void Destroy()
    {
        Destroy(gameObject);

    }
}
