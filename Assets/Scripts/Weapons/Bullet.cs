using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private int damge = 25;
    [SerializeField] private float durabilityime = 4;
    [SerializeField] private float acceleration = 100;
    [SerializeField] private float maxSpeed = 15f;
    [SerializeField] private string tagToHit;
    private Vector3 shootDirection;
    Stats stats;
    BulletStats bulletStats;
    public GameObject holderObject;

    // Start is called before the first frame update
    void Start()
    {
        Build();
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
        stats = new Stats(acceleration, maxSpeed, transform);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (tagToHit != other.gameObject.tag) return;
        bulletStats = new BulletStats(damge, holderObject, other.gameObject);
        
            bulletStats.getObjectStats();
        
        Destroy(gameObject);
        //if (other.gameObject.tag == gameObject.tag || other.gameObject.tag == holderObject.tag) return;
        //bulletStats = new BulletStats(damge, holderObject, other.gameObject);
        //if (other.gameObject.tag != holderObject.tag)
        //{
        //    bulletStats.getObjectStats();
        //}
        //Destroy(gameObject);
    }
    void Build()
    {
        ConstructSpeed();
    }
    public void setHolderObject(GameObject _gameObject)
    {
        holderObject = _gameObject;
    }
}
