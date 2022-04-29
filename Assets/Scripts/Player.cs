using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[RequireComponent(typeof(CapsuleCollider))]
public class Player : MonoBehaviour
{
    public float movementSpeed = 10.0f;
    CapsuleCollider _collider;
    private void Awake()
    {
        _collider = GetComponent<CapsuleCollider>();
    }
    void Update()
    {
        Vector3 input =
            Input.GetAxisRaw("Horizontal") * Vector3.right +
            Input.GetAxisRaw("Vertical") * Vector3.forward;

        transform.position += input.normalized * movementSpeed * Time.deltaTime;

        // Resolve collisions
        List<Collider> colliders = Physics.OverlapCapsule(
            transform.position + _collider.height * 0.5f * Vector3.up,
            transform.position - _collider.height * 0.5f * Vector3.up,
            _collider.radius)
            .Where(c => c.transform != transform)
            .ToList();

        if (colliders.Count > 0)
        {
            if (Physics.ComputePenetration(
                _collider,
                transform.position,
                transform.rotation,
                colliders[0],
                colliders[0].transform.position,
                colliders[0].transform.rotation,
                out Vector3 direction,
                out float distance))
            {
                transform.position += direction * distance;
            }
        }
    }
}
