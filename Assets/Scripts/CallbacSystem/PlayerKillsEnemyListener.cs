using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerKillsEnemyListener : MonoBehaviour
{
    private ListenerManager listenerManager;
    void Start()
    {
        listenerManager = GetComponentInParent<ListenerManager>();
        PlayerKillsEnemyEvent.RegisterListener(IncreaseXP);
    }

    private void IncreaseXP(PlayerKillsEnemyEvent info)
    {
        listenerManager.getPlayer().GetComponent<Player>().IncreaseXP(info.xpAmount);
    }
}
