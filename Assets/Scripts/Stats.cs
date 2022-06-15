using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Stats
{
    //private string name;
    [Header("Default Health")]
    [SerializeField] private int health = 100;
    [SerializeField] private int healthRegenerationSpeed = 5; // 5 health per second
    [Header("Default Extra")]
    [SerializeField] private Material material;
    [SerializeField] private LayerMask targetLayer;

    public Stats(int health, int healthRegenerationSpeed, Material material, LayerMask targetLayer)
    {
        this.health = health;
        this.healthRegenerationSpeed = healthRegenerationSpeed;
        this.material = material;
        this.targetLayer = targetLayer;
    }

    public bool IsDead()
    {
        if(health <= 0)
        {
            return true;
        }
        return false;
    }

    float temp = 0;
    public void HealthRegeneration()
    {
        temp += (healthRegenerationSpeed * Time.deltaTime);
        if (temp >= 1)
        {
            health += (int)temp;
            temp = 0;
        }
    }
    public int getHealth()
    {
        return health;
    }

    public void GetHurt(float amountDamge)
    {
        health -= (int)amountDamge;
        SetColor();
    }
    public void SetColor()
    {
        material.color = Color.Lerp(Color.white, Color.red, Mathf.PingPong(Time.time, 1));
    }
    public LayerMask getTargetLayer()
    {
        return targetLayer;
    }
}

