using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [Header("Health")]
    [SerializeField] private int health = 100;
    [SerializeField] private int healthRegenerationSpeed = 1; // 5 health per second
    [Header("Movment")]
    [SerializeField] private float acceleration = 20f;
    [SerializeField] private float deceleration = 22f;
    [SerializeField] private float maxSpeed = 10f;
    [Header("Default Attack")]
    [SerializeField] private float attackSpeed = 2;// 2 shots per second
    [SerializeField] private int damge = 25;
    private Transform _transform;
    private Transform playerTransform;
    Stats enemyStats;


    [Header("AI")]
    [SerializeField] private float chasingRange;
    [SerializeField] private float shootingRange;

    private GameObject player;
    private Material material;
    private Node topNode;

    private void Awake()
    {
        material = GetComponentInChildren<SpriteRenderer>().material;
        player = GameObject.FindGameObjectWithTag("Player");
        playerTransform = player.transform;
    }

    void Start()
    {
        _transform = GetComponent<Transform>();
        Construct();
        ConstructBehahaviourTree();
    }

    void Update()
    {
        if(topNode != null)
        {
            topNode.Evaluate();
            if (topNode.nodeState == NodeState.FAILURE)
            {
                SetColor(Color.red);
            }
        }
        Death();
    }

    void Construct()
    {
        enemyStats = new Stats(health, healthRegenerationSpeed,
            acceleration, deceleration, maxSpeed,
            _transform, material);
    }
    private void ConstructBehahaviourTree()
    {
        //HealthNode healthNode = new HealthNode(this, lowHealthThreshold);
        ChaseNode chaseNode = new ChaseNode(playerTransform, this);
        ChasingInRangeNode chasingInRangeNode = new ChasingInRangeNode(chasingRange, playerTransform, transform);
        RangeNode shootingRangeNode = new RangeNode(shootingRange, playerTransform, transform);
        AttackNode attackNode = new AttackNode( this, playerTransform, player, damge, attackSpeed, this.gameObject.GetComponentInChildren<Weapon>());
        IsPlayerDeadNode isPlayerDeadNode = new IsPlayerDeadNode(player);
        //Sequence playerDeathSequence = new Sequence(new List<Node> { isPlayerDeadNode });

        Sequence chaseSequence = new Sequence(new List<Node> {  chaseNode });
        Sequence shootSequence = new Sequence(new List<Node> { shootingRangeNode, attackNode });
        //Sequence checkPlayerSequence = new Sequence(new List<Node> {  playerDeathSequence });
        //Sequence mainCoverSequence = new Sequence(new List<Node> { healthNode, tryToTakeCoverSelector });

        topNode = new Selector(new List<Node> { isPlayerDeadNode, shootSequence, chaseSequence });
    }

    public void SetColor(Color color)
    {
        material.color = color;
    }

    public void Movement(Vector2 distacne)
    {
        enemyStats.Movement(distacne);
    }
    public void GetHurt(float amountDamge)
    {
        enemyStats.GetHurt(amountDamge);
    }
    void Death()
    {
        if (enemyStats.IsDead())
        {
            Destroy(gameObject);
            PlayerKillsEnemyEvent playerKillsEnemyEvent = new PlayerKillsEnemyEvent();
            playerKillsEnemyEvent.xpAmount = 4;
            playerKillsEnemyEvent.FireEvent();
        }
    }
}
