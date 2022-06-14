using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletStats
{
    [SerializeField] private int damge = 25;
    [SerializeField] private GameObject thisObject;
    [SerializeField] private GameObject target;


    public BulletStats(int damge, GameObject thisObject, GameObject target)
    {
        this.damge = damge;
        this.thisObject = thisObject;
        this.target = target;
    }
    public GameObject getThisGameObject()
    {
        return thisObject;
    }
    public void getObjectStats()
    {
        switch (target.tag)
        {
            case "Enemy":
                target.GetComponent<EnemyAI>().GetHurt(damge);
                break;
            case "Player":
                target.GetComponent<Player>().GetHurt(damge);
                break;
            default: return;
        }
    }
}
