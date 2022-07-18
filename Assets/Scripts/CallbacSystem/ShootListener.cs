using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootListener : MonoBehaviour
{
    private ListenerManager listenerManager;
    // Start is called before the first frame update
    void Start()
    {
        listenerManager = GetComponentInParent<ListenerManager>();
        ShootEvent.RegisterListener(shooting);
    }

    private void shooting(ShootEvent info)
    {
        if(info.holder != null)
            listenerManager.getWeaponHolder().setHolderObject(info.holder);
    }
}
