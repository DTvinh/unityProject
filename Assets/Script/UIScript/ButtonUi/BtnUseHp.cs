using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class BtnUseHp : BaseButton
{
    protected override void OnClick()
    {
        // ItemEvent.Instance.UseHP();
        for (int i = 0; i < IventoryObject.Instance.iventory.Length; i++)
        {
            if (IventoryObject.Instance.iventory[i].id == 2)
            {
                IventoryObject.Instance.ReduceAmount(IventoryObject.Instance.iventory[i].item, i);
                Observer.Notify(CONSTANT.REFRESH_IVENTORY);
                return;
            }
        }
        Debug.Log("useHP");
        return;
    }
}
