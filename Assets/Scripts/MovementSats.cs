using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementSats
{
    [Header("Default Movment")]
    [SerializeField] private float acceleration = 60;
    [SerializeField] private float deceleration = 60;
    [SerializeField] private float maxSpeed = 10;
    private Vector3 velocity;
    private Transform _transform;
    public MovementSats(float acceleration, float deceleration, float maxSpeed, Transform transform)
    {
        this.acceleration = acceleration;
        this.deceleration = deceleration;
        this.maxSpeed = maxSpeed;
        this._transform = transform;
    }
    public MovementSats(float acceleration, float maxSpeed, Transform transform)
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
}
