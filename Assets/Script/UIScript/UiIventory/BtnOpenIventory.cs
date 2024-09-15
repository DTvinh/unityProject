using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnOpenIventory : BaseButton
{
    protected override void OnClick()
    {
        UiIventorySystem.Instance.Open();
    }
}
