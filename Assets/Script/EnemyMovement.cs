using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    public Transform player;
    public float chaseDistance = 10f;
    public float stopDistance = 15f;

    private NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if (!agent.isOnNavMesh) return; // NavMesh 위에 없으면 아무 것도 안 함

        float distance = Vector3.Distance(transform.position, player.position);

        if (distance <= chaseDistance)
        {
            agent.SetDestination(player.position);
        }
        else if (distance > stopDistance)
        {
            agent.ResetPath();
        }
    }
}
