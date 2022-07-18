using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextLevelListener : MonoBehaviour
{
    private ListenerManager listenerManager;
    // Start is called before the first frame update
    void Start()
    {
        listenerManager = GetComponentInParent<ListenerManager>();
        NextLevelEvent.RegisterListener(Upgrade);
    }

    private void Upgrade(NextLevelEvent info)
    {
        listenerManager.getUI().ShowUpgradePanel();
        listenerManager.getUI().AssaignUpgradeButtons();
    }
}
