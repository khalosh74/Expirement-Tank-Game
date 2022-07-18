using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Health")]
    [SerializeField] private int heartContainers = 3;
    [SerializeField] private int hearts = 3;
    [Header("Shield")]
    [SerializeField] private int shield = 100;
    [SerializeField] private int shieldRegenerationSpeed = 5; // 5 health per second
    [Header("Movment")]
    [SerializeField] private float acceleration = 20f;
    [SerializeField] private float deceleration = 22f;
    [SerializeField] private float maxSpeed = 10f;
    [Header("XP")]
    [SerializeField] private int xp = 0;
    [SerializeField] private int nextLevelXP = 10;
    [SerializeField] private int level = 1;

    MovementSats playerMovmentStats;
    PlayerStats playerStats;
    XPStats playerXPStats;
    private Weapon weapon;
    [SerializeField] private Material material;
    [SerializeField] private LayerMask targetLayer;

    void Start()
    {
        //hearts = heartContainers;
        ConstructPlayer();
        weapon = gameObject.GetComponentInChildren<Weapon>();
    }
    void Update()
    {
        Rotate();
        Controllers();
        Shoot();
        RegeneratShield();
        CurrentXPDeffrence();
        LevelUp();
        Death();
    }
    void ConstructPlayer()
    {
        playerStats = new PlayerStats(heartContainers, hearts, shield, shieldRegenerationSpeed, gameObject);
        playerMovmentStats = new MovementSats(acceleration, deceleration, maxSpeed, transform);
        playerXPStats = new XPStats(xp, nextLevelXP, level);
    }

    void Death()
    {
        if (IsDead())
        {
            gameObject.SetActive(false);
        }
    }
    void Controllers()
    {
        Vector2 input = Vector2.right * Input.GetAxisRaw("Horizontal") + Vector2.up * Input.GetAxisRaw("Vertical");
        //input = transform.rotation * input;

        playerMovmentStats.Movement(input);
    }
    void RegeneratShield()
    {
        if (!playerStats.IsGotHit() && getShield() != shield)
        {
            playerStats.RegenerateShield();
        }
    }
    public bool IsDead()
    {
        return playerStats.IsDead();
    }
    public void GetHurt(int amountDamge)
    {
        //StartCoroutine(playerStats.GotHitTimer());
        playerStats.GetHurt(amountDamge, shield);
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
    public int getShield()
    {
        return playerStats.getShield();
    }
    private void LevelUp()
    {
        playerXPStats.LevelUp();
    }
    public int getHearts()
    {
        return playerStats.getHearts();
    }
    public void IncreaseXP(int amount)
    {
        playerXPStats.IncreaseXP(amount);
    }
    public float XPProcentTllNextLevel()
    {
        return playerXPStats.XPProcentTllNextLevel();
    }
    public void CurrentXPDeffrence()
    {
        playerXPStats.CurrentDeffrence();
    }
    public int getLevel()
    {
        return playerXPStats.getLevel();
    }
    public void Shoot()
    {
        if (Input.GetMouseButton(0))
        {
            weapon.Shoot();
        }
        if (Input.GetMouseButtonUp(0))
        {
            weapon.timer = 1;
        }
    }
    public void setSpeed(int speed)
    {
        acceleration += speed * 10;
        deceleration += speed * 10;
        maxSpeed += speed;
        playerMovmentStats = new MovementSats(acceleration, deceleration, maxSpeed, transform);
    }
}
