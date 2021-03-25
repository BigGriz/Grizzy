using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Talent", menuName = "Data/Talent", order = 1)]
public class TalentSO : ScriptableObject
{
    public int level = 0;
    public int maxLevel = 10;

    [Header("Added Damage Flat")]
    public int addedFlat = 0;
    public int addedDamageFlat;
    public float addedDamageFlatPerLevel;
    [Header("Added Damage Multipliers")]
    public float addedDamageMultiplierPerLevel;
    public float addedDamageMultiplier;
    [Header("Added Health Flat")]
    public int addedHealth;
    [Header("Added Health Multiplier")]
    public float healthMultiplier;

    public void AddLevel()
    {
        level++; 
        Debug.Log("Level " + level + " added this much flat damage " + Mathf.RoundToInt((float)addedDamageFlat * Mathf.Pow(addedDamageFlatPerLevel, level)));
        addedFlat += Mathf.RoundToInt((float)addedDamageFlat * Mathf.Pow(addedDamageFlatPerLevel, level));
        GetFlatDamage();
    }

    public int GetNextLevel()
    {
        return (addedFlat + Mathf.RoundToInt((float)addedDamageFlat * Mathf.Pow(addedDamageFlatPerLevel, level + 1)));
    }

    public int GetFlatDamage()
    {
        return (addedDamageFlat);
    }
}
