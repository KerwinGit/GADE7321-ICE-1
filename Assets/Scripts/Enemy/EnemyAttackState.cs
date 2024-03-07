using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackState : EnemyBaseState
{
    public override void EnterState(EnemyStateManager enemy)
    {
        enemy.agent.isStopped = true;
        enemy.attackParticle.Play();
        enemy.Attack();
    }

    public override void UpdateState(EnemyStateManager enemy)
    {
        if (Vector3.Distance(enemy.transform.position, enemy.player.position) > enemy.attackRange)
        {
            enemy.agent.isStopped = false;
            enemy.Transition(enemy.ChaseState); // Transition to chase state
        }       
    }

    public override void OnTriggerEnter(EnemyStateManager enemy, Collider other)
    {

    }
}
