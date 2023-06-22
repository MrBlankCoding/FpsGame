using UnityEngine;
using UnityEngine.AI;

public class ChaseAi : MonoBehaviour
{
    public Transform player;
    public Transform zombie;
    private NavMeshAgent agent;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if (player != null && zombie != null)
        {
            float distanceToPlayer = Vector3.Distance(transform.position, player.position);
            float distanceToZombie = Vector3.Distance(transform.position, zombie.position);

            if (distanceToPlayer < distanceToZombie)
            {
                agent.SetDestination(player.position);
            }
            else
            {
                agent.SetDestination(zombie.position);
            }
        }
    }
}