using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootListener : MonoBehaviour
{
    [SerializeField] private Bullet weaponHolder;
    // Start is called before the first frame update
    void Start()
    {
        ShootEvent.RegisterListener(shooting);
    }

    private void shooting(ShootEvent info)
    {
        if(info.holder != null)
        weaponHolder.setHolderObject(info.holder);
    }
}
