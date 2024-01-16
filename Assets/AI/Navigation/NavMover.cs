
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class NavMover : MonoBehaviour
{

    NavMeshAgent agent;
    private Vector3 destination;

    void Awake() => agent = GetComponent<NavMeshAgent>();


    public void StartMove(){
        if (agent.isOnNavMesh) agent.isStopped = false;
    }
    public void StopMove(){
        if (agent.isOnNavMesh) agent.isStopped = true;
    }

    public Vector3 Destination
    {
        get => destination;
        set
        {
            
            destination = value;
            if (agent.isOnNavMesh) agent.destination = value;
            StartMove();
        }
    }

    public float Speed
    {
        get => agent.velocity.magnitude / agent.speed;
    }

    public bool DestinationReached(Vector3 position, float stopRange = 1f)
    {
        if (!agent.isOnNavMesh) return false;
        if (position == destination)
        {
            if (agent.remainingDistance <= stopRange) return true;
        }

        return false;
    }
}
