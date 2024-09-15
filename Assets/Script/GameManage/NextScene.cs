using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;


public class NextScene : MonoBehaviour
{
    // Start is called before the first frame update
    public string nameScene;
    public SceneAsset scene;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D _other)
    {
        if (_other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            
        }
        
    }
}
