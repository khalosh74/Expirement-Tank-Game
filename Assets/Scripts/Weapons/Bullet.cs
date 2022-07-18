using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private int damge = 25;
    [SerializeField] private float durabilityime = 4;
    [SerializeField] private float acceleration = 100;
    [SerializeField] private float maxSpeed = 15f;
    [SerializeField] private LayerMask mask;
    private Vector3 shootDirection;
    MovementSats stats;
    BulletStats bulletStats;
    public GameObject holderObject;

    // Start is called before the first frame update
    void Start()
    {
        ConstructSpeed();
        gameObject.transform.localScale = new Vector2(1, 20 / maxSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        Movment();
    }
    public void Setup(Vector3 shootDirection)
    {
        this.shootDirection = shootDirection;
        transform.eulerAngles = new Vector3(0,0, Rotate(shootDirection));
        Destroy(gameObject, durabilityime);
    }
    void Movment()
    {
        stats.Movement(shootDirection);
    }
    float Rotate(Vector3 direction)
    {
        direction = direction.normalized;
        float n = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        if (n < 0) n += 360;
        return n;
    }
    void ConstructSpeed()
    {
        stats = new MovementSats(acceleration, maxSpeed, transform);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        bulletStats = new BulletStats(damge, other.gameObject);
        if ((mask & 1 << other.gameObject.layer) != 1 << other.gameObject.layer) return;
        bulletStats.AttackGameObject();
        Destroy(gameObject);
    }
    public void setHolderObject(GameObject _gameObject)
    {
        holderObject = _gameObject;
    }
    public void setTargetMask()
    {

    }
}
