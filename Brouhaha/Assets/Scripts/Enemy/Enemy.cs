using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : PoolableObject
{
    public EnemyFollow EnemyFollow;
    public NavMeshAgent Agent;

    public override void OnDisable()
    {
        base.OnDisable();

        Agent.enabled = false;
    }

}
