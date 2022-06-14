using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Stats
{
    //private string name;
    [Header("Default Health")]
    [SerializeField] private int health = 100;
    [SerializeField] private int healthRegenerationSpeed = 5; // 5 health per second
    [Header("Default Movment")]
    [SerializeField] private float acceleration = 60;
    [SerializeField] private float deceleration = 60;
    [SerializeField] private float maxSpeed = 10;
    [SerializeField] private Material material;
    private Vector3 velocity;
    private Transform _transform;

    public Stats(int health, int healthRegenerationSpeed,
        float acceleration, float deceleration, float maxSpeed,
        Transform transform, Material material)
    {
        this.health = health;
        this.healthRegenerationSpeed = healthRegenerationSpeed;
        this.acceleration = acceleration;
        this.deceleration = deceleration;
        this.maxSpeed = maxSpeed;
        this._transform = transform;
        this.material = material;
    }
    public Stats(float acceleration, float deceleration, float maxSpeed, Transform transform)
    {
        this.acceleration = acceleration;
        this.deceleration = deceleration;
        this.maxSpeed = maxSpeed;
        this._transform = transform;
    }
    public Stats(float acceleration, float maxSpeed, Transform transform)
    {
        this.acceleration = acceleration;
        this.maxSpeed = maxSpeed;
        this._transform = transform;
    }
    public void Movement(Vector3 input)
    {
        if (input.magnitude > float.Epsilon)
        {
            Accelerate(input);
        }
        else
        {
            Decelerate();
        }
        _transform.position += velocity * Time.deltaTime;
    }

    public void Accelerate(Vector3 input)
    {
        velocity += input.normalized * acceleration * Time.deltaTime;
        if (velocity.x > velocity.normalized.x * maxSpeed || velocity.x < velocity.normalized.x * maxSpeed)
        {
            velocity = Vector3.ClampMagnitude(velocity, maxSpeed);
        }
        if (velocity.y > velocity.normalized.y * maxSpeed || velocity.y < velocity.normalized.y * maxSpeed)
        {
            velocity = Vector3.ClampMagnitude(velocity, maxSpeed);
        }

    }

    public void Decelerate()
    {
        if (deceleration / 100 > Mathf.Abs(velocity.x))
        {
            velocity.x = Vector2.zero.x;
        }
        if (deceleration / 100 > Mathf.Abs(velocity.y))
        {
            velocity.y = Vector2.zero.y;
        }
        Vector3 projection = new Vector2(velocity.x, velocity.y).normalized;
        velocity -= projection * deceleration * Time.deltaTime;
    }
    public Vector3 getVelocity()
    {
        return velocity;
    }

    public bool IsDead()
    {
        if(health <= 0)
        {
            return true;
        }
        return false;
    }

    float temp = 0;
    public void HealthRegeneration()
    {
        temp += (healthRegenerationSpeed * Time.deltaTime);
        if (temp >= 1)
        {
            health += (int)temp;
            temp = 0;
        }
    }
    public int getHealth()
    {
        return health;
    }

    public void GetHurt(float amountDamge)
    {
        health -= (int)amountDamge;
        SetColor();
    }
    public void SetColor()
    {
        material.color = Color.Lerp(Color.white, Color.red, Mathf.PingPong(Time.time, 1));
    }
}

