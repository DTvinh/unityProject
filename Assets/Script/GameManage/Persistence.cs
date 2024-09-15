using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Persistence :Singleton<Persistence>
{
    
    protected override void Awake()
    {
       base.Awake();
        DontDestroyOnLoad(gameObject);
       

    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
