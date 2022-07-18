using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XPStats
{
    [Header("XP")]
    [SerializeField] private int xp = 0;
    [SerializeField] private int nextLevelXP = 10;
    [SerializeField] private int level = 1;
    private float deffrence = 10;
    private int currentDeffrence = 0;

    public XPStats(int xp, int nextLevelXP, int level)
    {
        this.xp = xp;
        this.nextLevelXP = nextLevelXP;
        this.level = level;
    }
    public void IncreaseXP(int amount)
    {
        xp += amount;
    }
    public void LevelUp()
    {
        if (xp >= nextLevelXP)
        {
            NextLevelEvent nextLevelEvent = new NextLevelEvent();
            nextLevelEvent.FireEvent();
            //GenerateRandomUpgrade();
            level++;
            ChangeNextLevelXP();
        }
    }
    private void ChangeNextLevelXP()
    {
        nextLevelXP = (nextLevelXP* 3);
        deffrence = (nextLevelXP - xp);
    }
    public float XPProcentTllNextLevel()
    {
        return 1-(currentDeffrence /deffrence);
    } 
    public void CurrentDeffrence()
    {
        currentDeffrence = nextLevelXP - xp;
    }
    public int getLevel()
    {
        return level;
    }
    private void GenerateRandomUpgrade()
    {
        foreach (Upgrades upgrade in (Upgrades[]) Enum.GetValues(typeof(Upgrades)))
        {
            Debug.Log(upgrade);
        }
    }
}
    public enum Upgrades
    {
        Speed,
        FireRate,
        AttackDamge,
        
    }