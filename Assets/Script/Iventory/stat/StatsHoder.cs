using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;

public class StatsHoder : Singleton<StatsHoder>
{

    // [SerializeField] private Stat[] stats = new Stat[5];
    [SerializeField] private StatModifier[] statModifiers = new StatModifier[5];
    public StatModifier[] StatModifiers => statModifiers;
    [SerializeField] int _health = 0;
    [SerializeField] int _mana = 0;
    [SerializeField] int _attack = 0;
    [SerializeField] int _speed = 0;
    [SerializeField] int _defense = 0;
    protected override void Awake()
    {
        base.Awake();
    }
    private void OnEnable()
    {

    }

    private void Start()
    {// AddModifier();
        Observer.AddListener(CONSTANT.CHANGE_EQUIP, UpdateStats);
        // Observer.Notify(CONSTANT.REFRESH_IVENTORY);

    }

    private void Update()
    {
    }
    private void UpdateStats(object[] datas)
    {
        _health = 0;
        _attack = 0;
        _defense = 0;
        _mana = 0;
        _speed = 0;
        for (int i = 0; i < IventoryObject.Instance.EquipmentSlots.Length; i++)
        {
            if (IventoryObject.Instance.EquipmentSlots[i].id <= -1)
            {
                // ComputeValueFinal();
                continue;

            }
            if (IventoryObject.Instance.EquipmentSlots[i].id >= 0)
            {
                ComputeValue(IventoryObject.Instance.EquipmentSlots[i].equipment);

            }

        }
        ComputeValueFinal();

    }
    void ComputeValue(ItemSO item)
    {
        // int value=0;
        for (int i = 0; i < item.buffs.Length; i++)
        {
            if (item.buffs[i].attribute == Attributes.Hp)
            {
                _health += item.buffs[i].value;
            }
            if (item.buffs[i].attribute == Attributes.Mp)
            {
                _mana += item.buffs[i].value;
            }
            if (item.buffs[i].attribute == Attributes.Strngth)
            {
                _attack += item.buffs[i].value;
            }
            if (item.buffs[i].attribute == Attributes.Stamina)
            {
                _defense += item.buffs[i].value;
            }
            if (item.buffs[i].attribute == Attributes.Agility)
            {
                _speed += item.buffs[i].value;
            }
        }
        // ComputeValueFinal();
    }
    private void ComputeValueFinal()
    {
        foreach (var statModifier in statModifiers)
        {
            switch (statModifier.ImpactedStat.attribute)
            {
                case Attributes.Hp:
                    statModifier.SetModifierValue(statModifier.ImpactedStat.BaseValue + _health);
                    break;
                case Attributes.Mp:
                    statModifier.SetModifierValue(statModifier.ImpactedStat.BaseValue + _mana);
                    break;
                case Attributes.Strngth:
                    statModifier.SetModifierValue(statModifier.ImpactedStat.BaseValue + _attack);
                    break;
                case Attributes.Stamina:
                    statModifier.SetModifierValue(statModifier.ImpactedStat.BaseValue + _defense);
                    break;
                case Attributes.Agility:
                    statModifier.SetModifierValue(statModifier.ImpactedStat.BaseValue + _speed);
                    break;
                default:
                    Debug.LogError("sai vai lon");
                    break;
            }

            Observer.Notify(CONSTANT.REFRESH_UISTAT);



            // if(statModifier.ImpactedStat.attribute== Attributes.Hp){

            //     continue;
            // }
            // if(statModifier.ImpactedStat.attribute== Attributes.Mp){
            //     statModifier.SetModifierValue(statModifier.ImpactedStat.BaseValue+ _mana);

            // }
        }
    }


}
