using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(NavMover))]
public class MoveToPosition : MonoBehaviour, ITask
{
    NavMover navMover;
    public Vector3 destination;
    public bool destinationSet;

    void Awake() => navMover = GetComponent<NavMover>();

    public bool Evaluate()
    {
        if (!destinationSet) return false;

        navMover.Destination = destination;
        if (navMover.DestinationReached(destination)) destinationSet = false;

        return true;
    }
}
