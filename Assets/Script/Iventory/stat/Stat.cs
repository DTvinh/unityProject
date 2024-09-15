using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[Serializable]
public class StatModifier
{
    [SerializeField]
    private Stat m_ImpactedStat = null;
    [SerializeField]
    private int m_ModifierValue = 0;
    public StatModifier(Stat impactedStat, int ModifierValue)
    {
        this.m_ImpactedStat = impactedStat;
        this.m_ModifierValue = ModifierValue;
    }
    public Stat ImpactedStat => m_ImpactedStat;
    public int ModifierValue => m_ModifierValue;
    public void SetModifierValue(int value)
    {
        this.m_ModifierValue = value;
    }



}

[Serializable]
public class Stat
{
    public Attributes attribute;
    [SerializeField] int baseValue;
    public int BaseValue => baseValue;

}

// public enum NameStats
// {
//     Health,
//     Mana,
//     Attack,
//     Speed,
//     Dfense
// }

