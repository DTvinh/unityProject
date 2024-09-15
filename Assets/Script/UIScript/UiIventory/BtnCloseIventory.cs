using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnCloseIventory : BaseButton
{
    protected override void OnClick()
    {
        UiIventorySystem.Instance.Close();
    }
}
