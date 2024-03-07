using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyIdleState : EnemyBaseState
{
    private float idleTimer;
    private float idleDuration;

    public override void EnterState(EnemyStateManager enemy)
    {
        //Debug.Log("idle");

        enemy.agent.isStopped = true;
        idleTimer = 0f;
        idleDuration = Random.Range(1, 4);
    }

    public override void UpdateState(EnemyStateManager enemy)
    {
        idleTimer += Time.deltaTime;

        if (idleTimer >= idleDuration)
        {
            enemy.agent.isStopped = false;
            enemy.Transition(enemy.PatrolState);                    // Transition to patrol state
        }
    }

    public override void OnTriggerEnter(EnemyStateManager enemy, Collider other)
    {
        if (enemy.aggroTrigger.CompareTag("Player"))
        {
            enemy.agent.isStopped = false;
            enemy.Transition(enemy.ChaseState);                     // Transition to chase state
        }
    }
}
