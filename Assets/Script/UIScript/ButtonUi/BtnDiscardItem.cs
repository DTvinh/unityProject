using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnDiscardItem : BaseButton
{
    protected override void OnClick()
    {
        ItemEvent.Instance.UpdateDiscardItem();

    }


}
