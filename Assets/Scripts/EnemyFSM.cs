using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyFSM : MonoBehaviour
{
    NavMeshAgent agent;
    [SerializeField] Transform targetPlayer;

    enum EnemyStates { Idle, Patrol, Chase };
    EnemyStates currentState;

    [SerializeField]
    float chaseRange = 10f, stopChaseRange = 15f,
        patrolDistance = 10f, idleTime = 3f, idleTimer;

    private Vector3 patrolTarget;
    private bool isPatrolTargetSet = false;

    public LayerMask groundLayers;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        targetPlayer = GameObject.FindWithTag("Player").transform;
        currentState = EnemyStates.Idle;
        // reset the amount of time we've been idle
        idleTimer = idleTime;
    }

    // Update is called once per frame
    void Update()
    {
        switch(currentState)
        {
            case EnemyStates.Idle:
                Debug.Log("Enemy Idle");
                IdleState();
                break;
            case EnemyStates.Patrol:
                Debug.Log("Enemy Patrolling");
                break;
            case EnemyStates.Chase:
                Debug.Log("Enemy Chasing");
                ChaseState();
                break;
            default:
                Debug.LogError("Enemy State Invalid");
                break;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.gameObject.CompareTag("Player"))
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
        }
    }

    void IdleState()
    {
        idleTimer -= Time.deltaTime;

        if(idleTimer <= 0)
        {
            currentState = EnemyStates.Patrol;
            idleTimer = idleTime;
        }

        if(Vector3.Distance
            (transform.position, targetPlayer.position) < chaseRange)
        {
            currentState = EnemyStates.Chase;
            idleTimer = idleTime;
        }
    }

    void PatrolState()
    {

    }

    void ChaseState()
    {
        agent.SetDestination(targetPlayer.position);

        if(Vector3.Distance(transform.position, targetPlayer.position) > stopChaseRange)
        {
            currentState = EnemyStates.Idle;
            // agent.SetDestination(transform.position);
        }
    }

    void FindPatrolTarget()
    {
        float randomX = Random.Range(-patrolDistance, patrolDistance);
        float randomZ = Random.Range(-patrolDistance, patrolDistance);

        patrolTarget = new(transform.position.x + randomX,
            transform.position.y, transform.position.z + randomZ);
    }
}
