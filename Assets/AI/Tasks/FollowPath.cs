using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(NavMover))]
public class FollowPath : MonoBehaviour, ITask
{
    NavMover navMover;
    public NavPath path;
    public int pathIndex;
    public bool followInReverse = false;

    void Awake() => navMover = GetComponent<NavMover>();

    // Update is called once per frame
    public bool Evaluate()
    {
        if (!path) return false;

        if (navMover.DestinationReached(path.pathPoints[pathIndex]))
        {
            Debug.Log("Destination Reached");
            pathIndex = followInReverse ? pathIndex - 1 : pathIndex + 1;

            if (path.loop)
            {
                if (pathIndex < 0) pathIndex = path.pathPoints.Count - 1;
                if (pathIndex >= path.pathPoints.Count) pathIndex = 0;
            }
            else{
                pathIndex = Mathf.Clamp(pathIndex, 0, path.pathPoints.Count - 1);
            }
        }

        navMover.Destination = path.pathPoints[pathIndex];
        return true;
    }
}
