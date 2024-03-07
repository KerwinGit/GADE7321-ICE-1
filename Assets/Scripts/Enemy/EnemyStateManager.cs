using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyStateManager : MonoBehaviour
{
    EnemyBaseState activeState;

    public EnemyIdleState IdleState = new EnemyIdleState();
    public EnemyPatrolState PatrolState = new EnemyPatrolState();
    public EnemyChaseState ChaseState = new EnemyChaseState();
    public EnemyAttackState AttackState = new EnemyAttackState();

    public Transform player;
    public NavMeshAgent agent;

    public PlayerController playerController;

    public float chaseRange = 10f;
    public float attackRange = 2f;

    public CapsuleCollider aggroTrigger;
    public GameObject attackObject;
    public ParticleSystem attackParticle;

    public void Start()
    {
        activeState = IdleState;
        activeState.EnterState(this);

        agent = GetComponent<NavMeshAgent>();
    }

    public void OnTriggerEnter(Collider other)
    {
        activeState.OnTriggerEnter(this, other);
    }

    public void Update()
    {
        activeState.UpdateState(this);
    }

    public void Transition(EnemyBaseState state)
    {
        activeState = state;
        state.EnterState(this);
        Debug.Log(activeState);
    }

    public void Attack()
    {
        StartCoroutine(ActivateAndDeactivateAttackHitbox());
    }

    IEnumerator ActivateAndDeactivateAttackHitbox()
    {
        // Activate attack hitbox
        attackObject.SetActive(true);

        // Wait for attack duration
        yield return new WaitForSeconds(0.1f);

        // Deactivate attack hitbox
        attackObject.SetActive(false);
    }
}
