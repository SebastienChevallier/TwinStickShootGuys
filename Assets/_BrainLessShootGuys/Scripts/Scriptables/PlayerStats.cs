using NUnit.Framework;
using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerStats", menuName = "Scriptable Objects/PlayerStats")]
public class PlayerStats : ScriptableObject
{
    public float _CurrentHealth;
    public float _MaxHealth;

    public List<PairStat> _Stats;   

    public float GetStat(Stat stat)
    {
        float statValue = 0;
        foreach (PairStat pair in _Stats)
        {
            if (pair._Stat == stat)
            {
                statValue += pair._Value;
            }
        }
        return statValue;
    }

    public void Init()
    {
        _MaxHealth = GetStat(Stat.Health);
        _CurrentHealth = _MaxHealth;        
    }

    public void AddStat(PairStat stat)
    {
        _Stats.Add(stat);

        if(stat._Stat == Stat.Health)
        {
            _CurrentHealth += stat._Value;
            _MaxHealth = GetStat(Stat.Health);
        }
    }
}

public enum Stat
{
    Speed,
    Health, 
    DashForce,
    DashCD,
    HPRegen,
    Critic,
    CriticDammage,
    RotationSpeed
}

[Serializable]
public class PairStat
{
    public Stat _Stat;
    public float _Value;
}
