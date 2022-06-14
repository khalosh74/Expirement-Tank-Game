using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [Header("Default Attack")]
    [SerializeField] private float attackSpeed = 2f;// 2 shots per second
    [SerializeField] private Transform bullet;
    [SerializeField] private Transform bulletsSpawnPoint;
    float timer = 1;

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Shoot();
        }
        if (Input.GetMouseButtonUp(0))
        {
            timer = 1;
        }
    }
    public void Shoot()
    {
        timer += Time.deltaTime;
        if(timer > attackSpeed / 10)
        {
            ShootEvent shoot = new ShootEvent();
            shoot.holder = transform.parent.gameObject;
            shoot.FireEvent();
            Transform bulletTransform = Instantiate(bullet, bulletsSpawnPoint.position, Quaternion.identity);
            Vector3 shootDirection = (transform.position - bulletTransform.position).normalized;
            shootDirection.z = 0;
            bulletTransform.GetComponent<Bullet>().Setup(-shootDirection);
            timer = 0;
        }
    }
}
