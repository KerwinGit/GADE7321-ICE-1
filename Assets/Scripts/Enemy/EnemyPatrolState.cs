using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyPatrolState : EnemyBaseState
{
    private Vector3 patrolDestination;

    public override void EnterState(EnemyStateManager enemy)
    {
        enemy.agent.destination = SetRandomDestination();
        //Debug.Log("patrol");
        //Debug.Log(enemy.agent.destination);
    }

    public override void UpdateState(EnemyStateManager enemy)
    {

        if (!enemy.agent.pathPending && enemy.agent.remainingDistance < 0.1f)
        {
            if (Random.value < 0.5f)
            {
                enemy.Transition(enemy.IdleState);
            }
            else
            {
                enemy.agent.SetDestination(patrolDestination);
            }
        }
    }

    public override void OnTriggerEnter(EnemyStateManager enemy, Collider other)
    {
        if (other.CompareTag("Player"))
        {
            enemy.Transition(enemy.ChaseState);                     // Transition to chase state
        }
    }

    private Vector3 SetRandomDestination()
    {
        NavMeshHit hit;
        Vector3 randomPosition = Vector3.zero;
        if (NavMesh.SamplePosition(Random.insideUnitSphere * 10f, out hit, 10f, NavMesh.AllAreas))
        {
            randomPosition = hit.position;
        }
        return randomPosition;
    }
}

