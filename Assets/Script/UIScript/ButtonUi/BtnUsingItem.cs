using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnusingItem : BaseButton
{
    protected override void OnClick()
    {

        ItemEvent.Instance.UseItem();
    }
}
