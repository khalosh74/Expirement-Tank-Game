using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListenerManager : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private Bullet weaponHolder;
    [SerializeField] private UIHandler UI;
    // Start is called before the first frame update
    void Start()
    {
        //player = transform.parent.parent.gameObject;
    }
    public GameObject getPlayer()
    {
        return player;
    }
    public Bullet getWeaponHolder()
    {
        return weaponHolder;
    }
    public UIHandler getUI()
    {
        return UI;
    }
}
