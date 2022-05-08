using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ChaseNode : Node
{
    private Transform target;
    private EnemyAI ai;

    public ChaseNode(Transform target, EnemyAI ai)
    {
        this.target = target;
        this.ai = ai;
    }

    public override NodeState Evaluate()
    {
        ai.SetColor(Color.yellow);
        Vector3 direction = target.position - ai.transform.position;
        var angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        ai.transform.rotation = rotation;
        float distance = Vector3.Distance(target.position, ai.transform.position);
        if(distance > 0.2f)
        {
            ai.Movement(direction);
            //agent.isStopped = false;
            //agent.SetDestination(target.position);
            return NodeState.RUNNING;
        }
        else
        {
            //agent.isStopped = true;
            return NodeState.SUCCESS;
        }
    }

   
}
