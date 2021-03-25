using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    #region Singleton
    public static UIController instance;
    private void Awake()
    {
        if (instance != null)
        {
            Debug.Log("More than one UIController exists!");
            Destroy(this);
        }
        instance = this;
    }
    #endregion Singleton

    public event Action<float> updateDamage;
    public void UpdateDamage(float _damage)
    {
        if (updateDamage != null)
            updateDamage(_damage);      
    }

    public event Action<int> updateCoins;
    public void UpdateCoins(int _coins)
    {
        if (updateCoins != null)
            updateCoins(_coins);
    }

    public event Action<string, int> updateLevel;
    public void UpdateLevel(string _area, int _level)
    {
        if (updateLevel != null)
            updateLevel(_area, _level);
    }

    public event Action<int, float> updateXP;
    public void UpdateXP(int _level, float _xp)
    {
        if (updateXP != null)
            updateXP(_level, _xp);
    }

    public event Action<Gear> addGear;
    public void AddGear(Gear _gear)
    {
        if (addGear != null)
            addGear(_gear);
    }

    public event Action<int> updateTalentPoints;
    public void UpdateTalentPoints(int _points)
    {
        if (updateTalentPoints != null)
            updateTalentPoints(_points);
    }
}
