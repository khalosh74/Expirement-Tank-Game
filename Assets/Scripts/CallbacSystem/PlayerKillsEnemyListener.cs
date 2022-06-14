using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerKillsEnemyListener : MonoBehaviour
{
    [SerializeField] private GameObject player;
    void Start()
    {
        PlayerKillsEnemyEvent.RegisterListener(IncreaseXP);
        player = transform.parent.parent.gameObject;
    }

    private void IncreaseXP(PlayerKillsEnemyEvent info)
    {
        player.GetComponent<Player>().IncreaseXP(info.xpAmount);
    }
}
