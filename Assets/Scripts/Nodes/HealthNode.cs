using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthNode : Node
{
    private EnemyAI ai;
    private int threshold;
    private int health;

    public HealthNode(EnemyAI ai, int health, int threshold)
    {
        this.ai = ai;
        this.threshold = threshold;
        this.health = health;
    }

    public override NodeState Evaluate()
    {
        return health <= threshold ? NodeState.SUCCESS : NodeState.FAILURE;
    }
}
