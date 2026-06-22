using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class EnemyMovement : MonoBehaviour
{
    public Transform player;
    public float chaseDistance = 10f;
    public float stopDistance = 15f;

    private NavMeshAgent agent;

    public int randomMap = 0;

    public string targetSceneName="지뢰찾기"; // 이동할 씬 이름

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

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            /*
            randomMap = Random.Range(1, 3); // 0, 1, 2 중 하나를 랜덤으로 선택

            if(randomMap == 1)
            {
                targetSceneName = "지뢰찾기"; // 씬 이름 설정
            }
            else if(randomMap == 2)
            {
                targetSceneName = "솔리테어"; // 씬 이름 설정
            }
            */
            // 플레이어와 충돌 시 씬 전환
            SceneManager.LoadScene(targetSceneName);
        }
    }
}
