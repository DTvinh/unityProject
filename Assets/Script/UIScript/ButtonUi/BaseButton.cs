using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class BaseButton : MonoBehaviour
{

    protected Button button;
    protected virtual void Awake()
    {
        button = GetComponent<Button>();
    }
    protected virtual void Start()
    {
        AddOnclickEvent();

    }

    // Update is called once per frame
    void AddOnclickEvent()
    {
        this.button.onClick.AddListener(OnClick);
    }

    protected abstract void OnClick();
}
