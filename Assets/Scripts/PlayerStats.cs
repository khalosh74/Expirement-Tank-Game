using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats
{
    [Header("Health")]
    [SerializeField] private int heartContainers = 3;
    [SerializeField] private int hearts = 3;
    [Header("Shield")]
    [SerializeField] private int shield = 100;
    [SerializeField] private int shieldRegenerationSpeed = 5; // 5 health per second
    private bool gotHit = false;
    private GameObject player;

    public PlayerStats(int heartContainers, int hearts, int shield, int shieldRegenerationSpeed, GameObject player)
    {
        this.heartContainers = heartContainers;
        this.hearts = hearts;
        this.shield = shield;
        this.shieldRegenerationSpeed = shieldRegenerationSpeed;
        this.player = player;
    }

    public void GetHurt(int amountDamge, int deadualtShield)
    {
        gotHit = true;
        if (shield != 0) HitShield(amountDamge);
        else if (hearts != 0) HitHeart(deadualtShield);
        else Death();
    }
    private void HitShield(int amountDamge)
    {
        shield -= amountDamge;
        if(shield <= 0) shield = 0;
    }
    float temp = 0;
    public void RegenerateShield()
    {
        if (shield >= 100) return;
        temp += (shieldRegenerationSpeed * Time.deltaTime);

        if (temp >= 1)
        {
            shield += (int)temp;
            temp = 0;
        }
    }
    public IEnumerator GotHitTimer()
    {
        yield return new WaitForSeconds(1);
        gotHit = false;
    }
    private void HitHeart(int deadualtShield)
    {
        hearts--;
        shield = deadualtShield;
    }

    void Death()
    {
        if (IsDead())
        {
            player.SetActive(false);
        }
    }
    public bool IsDead()
    {
        if (hearts <= 0)
        {
            hearts = 0;
            return true;
        }
        return false;
    }

    public bool IsGotHit()
    {
        return gotHit;
    }
    public int getShield()
    {
        return shield;
    }
    public int getHearts()
    {
        return hearts;
    }
}
