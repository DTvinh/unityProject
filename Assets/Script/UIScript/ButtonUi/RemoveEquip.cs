using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveEquip : BaseButton
{
    protected override void OnClick()
    {
        ItemEvent.Instance.RemoveEquip();
    }


}
