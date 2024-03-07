using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChaseState : EnemyBaseState
{
    public override void EnterState(EnemyStateManager enemy)
    {
        //Debug.Log("chase");
        enemy.agent.SetDestination(enemy.player.position);
    }

    public override void UpdateState(EnemyStateManager enemy)
    {
        enemy.agent.SetDestination(enemy.player.position);

        if (Vector3.Distance(enemy.transform.position, enemy.player.position) > enemy.chaseRange)
        {
            enemy.Transition(enemy.IdleState); // Transition to idle state
        }

        if (Vector3.Distance(enemy.transform.position, enemy.player.position) < enemy.attackRange)
        {
            enemy.agent.isStopped = true;
            enemy.Transition(enemy.AttackState); // Transition to attack state
        }
    }

    public override void OnTriggerEnter(EnemyStateManager enemy, Collider other)
    {

    }
}
