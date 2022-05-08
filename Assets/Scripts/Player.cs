using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Health")]
    [SerializeField] private int health = 100;
    [SerializeField] private int healthRegenerationSpeed = 5; // 5 health per second
    [Header("Movment")]
    [SerializeField] private float acceleration = 20f;
    [SerializeField] private float deceleration = 22f;
    [SerializeField] private float maxSpeed = 10f;

    static private Transform _transform;
    Stats playerStats;
    [SerializeField] private Material material;

    void Start()
    {
        _transform = GetComponent<Transform>();
        ConstructPlayer();
    }
    void Update()
    {
        Rotate();
        Controllers();
        RegeneratHealth();
        Death();
    }
    void ConstructPlayer()
    {
        playerStats = new Stats(health, healthRegenerationSpeed,
            acceleration, deceleration, maxSpeed,
            _transform, material);
    }

    void Death()
    {
        if (playerStats.IsDead())
        {
            gameObject.SetActive(false);
        }
    }
    void Controllers()
    {
        Vector2 input = Vector2.right * Input.GetAxisRaw("Horizontal") + Vector2.up * Input.GetAxisRaw("Vertical");
        //input = transform.rotation * input;

        playerStats.Movement(input);
    }
    void RegeneratHealth()
    {
        if(playerStats.getHealth() <= 50)
            playerStats.HealthRegeneration();
    }
    public bool IsDead()
    {
        return playerStats.IsDead();
    }
    public void GetHurt(float amountDamge)
    {
        playerStats.GetHurt(amountDamge);
    }
    void Rotate()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);
        Vector3 direction = mousePos - transform.position;
        var angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = rotation;
    }
}
