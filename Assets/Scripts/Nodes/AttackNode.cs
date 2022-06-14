using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AI;

public class AttackNode : Node
{
    private EnemyAI ai;
    private Transform target;
    private GameObject player;
    private int damge;
    private float attackSpeed;

    public AttackNode(EnemyAI ai, Transform target, GameObject player, int damge, float attackSpeed)
    {
        this.ai = ai;
        this.target = target;
        this.player = player;
        this.attackSpeed = attackSpeed;
        this.damge = damge;
    }

    public override NodeState Evaluate()
    {
        //agent.isStopped = true;
        ai.SetColor(Color.green);
        Vector3 direction = target.position - ai.transform.position;
        var angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        ai.transform.rotation = rotation;
        attack();
        return NodeState.RUNNING;
    }
    float timer = 1;
    void attack()
    {
        timer += Time.deltaTime;
        if (timer > attackSpeed)
        {
            Player playerS = player.GetComponent<Player>();
            playerS.GetHurt(damge);
            timer = 0;
        }
    }
}

