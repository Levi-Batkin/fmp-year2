using UnityEngine;
using UnityEngine.AI;

public class ForceAgentToNavMesh : MonoBehaviour
{
    private NavMeshAgent agent;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    private void Start()
    {
        StartCoroutine(PlaceAgent());
    }

    private System.Collections.IEnumerator PlaceAgent()
    {
        // Wait for a short time to ensure the navmesh is baked
        yield return new WaitForSeconds(0.5f);

        NavMeshHit hit;
        if (NavMesh.SamplePosition(transform.position, out hit, 5f, NavMesh.AllAreas))
        {
            agent.Warp(hit.position);
        }
        else
        {
            Debug.LogError("Failed to place agent on the navmesh.");
        }
    }
}
