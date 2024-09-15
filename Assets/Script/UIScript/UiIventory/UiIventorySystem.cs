using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiIventorySystem : Singleton<UiIventorySystem>
{


    protected bool isOpen = false;
    protected override void Awake()
    {
        base.Awake();
    }
    void Start()
    {
        Close();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public virtual void Toggle()
    {
        this.isOpen = !this.isOpen;
        if (this.isOpen)
        {
            Close();
        }
        else
        {
            Open();
        }
    }

    public virtual void Open()
    {
        gameObject.SetActive(true);
        isOpen = true;
    }
    public virtual void Close()
    {
        gameObject.SetActive(false);
        isOpen = false;

    }

}
