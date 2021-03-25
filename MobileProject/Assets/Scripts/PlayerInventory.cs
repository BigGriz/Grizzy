using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public static PlayerInventory instance;
    private void Awake()
    {
        if (instance != null)
        {
            Debug.Log("More than one Player Inventory exists!");
            Destroy(this);
        }
        instance = this;
    }

    public int coins;
    public int xp;
    public int xpRequired;
    public int level = 1;
    public int talentPoints;

    public void GiveXP(int _xp)
    {
        xp += _xp;
        if (xp >= xpRequired)
        {
            xp -= xpRequired;
            level++;
        }
        UIController.instance.UpdateXP(level, (float)xp / (float)xpRequired);
    }

    public void GiveCoin(int _coin)
    {
        coins += _coin;
        UIController.instance.UpdateCoins(coins);
    }
    public bool SpendCoin(int _coin)
    {
        if (coins >= _coin)
        {
            coins -= _coin;
            UIController.instance.UpdateCoins(coins);
            return true;
        }
        return false;
    }
    public bool SpendTalentPoint()
    {
        if (talentPoints > 0)
        {
            talentPoints--;
            return true;
        }
        return false;
    }
}
