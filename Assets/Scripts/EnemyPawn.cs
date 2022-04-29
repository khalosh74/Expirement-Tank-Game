using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

//[RequireComponent(typeof(CapsuleCollider))]
public class EnemyPawn : MonoBehaviour
{
    public float movementSpeed = 5.0f;
    public float rotationSpeed = 4.0f;
    public float sight = 400.0f;
    [Range(1, 21)]
    public int traces = 1;
    public float visionAngle = 70.0f;

    //public bool debugDraw = false;
    CapsuleCollider _collider;
    Transform _transform;
    Player player;
    private void Awake()
    {
        _collider = GetComponent<CapsuleCollider>();
        player = GetComponent<Player>();
    }

    void Update()
    {
        _transform = transform;

        // Apply movement
        _transform.forward = Vector3.Lerp(_transform.forward, CalculateMovementVector().normalized, Time.deltaTime * rotationSpeed);
        _transform.position += _transform.forward * movementSpeed * Time.deltaTime;
    }

    public Vector3 CalculateMovementVector()
    {
        Vector3 movementVector = Vector3.zero;
        float stepAngle = (visionAngle * 2.0f) / (traces - 1);
        // Create movement vector based on lidar sight.
        for (int i = 0; i < traces; i++) // recusuve?
        {
            float angle = (90.0f + visionAngle - (i * stepAngle)) * Mathf.Deg2Rad;
            Vector3 direction = _transform.TransformDirection(new Vector3(Mathf.Cos(angle), 0.0f, Mathf.Sin(angle)));
            if (Physics.Raycast(_transform.position, direction, out RaycastHit hitInfo, sight))
            {
                movementVector += direction * hitInfo.distance;
                if (hitInfo.distance < 1) ResolveCollisions();

                if (hitInfo.transform == player)
                {
                    return direction;
                }
            }
            else
            {
                movementVector += direction * sight;
            }
        }
        return movementVector;
    }

    public void ResolveCollisions()
    {
        //O notation
        List<Collider> colliders = Physics.OverlapCapsule(
            _transform.position + _collider.height * 0.5f * Vector3.up,
            _transform.position - _collider.height * 0.5f * Vector3.up,
            _collider.radius)
            .Where(c => c.transform != _transform)
            .ToList(); // foreach loop?

            if (colliders.Count > 0 && Physics.ComputePenetration(
                _collider,
                _transform.position,
                _transform.rotation,
                colliders[0],
                colliders[0].transform.position,
                colliders[0].transform.rotation,
                out Vector3 direction,
                out float distance))
            {
                _transform.position += direction * distance;
            }
    }
}
