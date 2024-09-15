using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UiStats : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI txtHealth;
    [SerializeField] TextMeshProUGUI txtMana;
    [SerializeField] TextMeshProUGUI txtAttack;
    [SerializeField] TextMeshProUGUI txtDefense;
    [SerializeField] TextMeshProUGUI txtSpeed;
    private void Start()
    {
        Observer.AddListener(CONSTANT.REFRESH_UISTAT, UpdateUiStats);

    }
    private void UpdateUiStats(object[] datas)
    {
        foreach (var i in StatsHoder.Instance.StatModifiers)
        {


            switch (i.ImpactedStat.attribute)
            {

                case Attributes.Hp:
                    txtHealth.text = i.ModifierValue.ToString();

                    break;
                case Attributes.Mp:
                    txtMana.text = i.ModifierValue.ToString();
                    break;
                case Attributes.Strngth:
                    txtAttack.text = i.ModifierValue.ToString();
                    break;
                case Attributes.Stamina:
                    txtDefense.text = i.ModifierValue.ToString();
                    break;
                case Attributes.Agility:
                    txtSpeed.text = i.ModifierValue.ToString();
                    break;

            }
        }

    }



}
