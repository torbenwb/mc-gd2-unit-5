using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
/*
[CustomEditor(typeof(NavPath))]
public class PathEditor : Editor
{
    int targetIndex;

    public void OnSceneGUI()
    {
        Tools.current = Tool.None;
        NavPath navPath = target as NavPath;

        for(int i = 0; i < navPath.pathPoints.Count; i++)
        {
            if (Handles.Button(navPath.pathPoints[i], Quaternion.identity, 1f, 1f, Handles.SphereHandleCap))
            {
                targetIndex = i;
                break;
            }
        }

        if (targetIndex >= 0 && targetIndex < navPath.pathPoints.Count)
        {
            navPath.pathPoints[targetIndex] = Handles.PositionHandle(navPath.pathPoints[targetIndex], Quaternion.identity);
        }
    }
}
*/

public class NavPath : MonoBehaviour
{
    public List<Vector3> pathPoints;
    public bool loop;

    void OnDrawGizmos()
    {
        if (pathPoints.Count == 0) return;

        for(int i = 0; i < pathPoints.Count - 1; i++)
        {
            Gizmos.DrawLine(pathPoints[i], pathPoints[i + 1]);
            Gizmos.DrawSphere(pathPoints[i], 0.5f);
        }
        Gizmos.DrawSphere(pathPoints[pathPoints.Count - 1], 0.5f);
        if (loop)
        {
            Gizmos.DrawLine(pathPoints[pathPoints.Count - 1], pathPoints[0]);
        }
    }
}
