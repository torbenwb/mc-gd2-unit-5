using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
/*
using UnityEditor;

[CustomEditor(typeof(AgentDemo))]
public class ADEditor : Editor
{
    int targetIndex = -1;
    public void OnSceneGUI()
    {
        AgentDemo agentDemo = target as AgentDemo;

        Tools.current = Tool.None;
        
        for(int i = 0; i < agentDemo.movePoints.Count; i++){
            if (Handles.Button(agentDemo.movePoints[i], Quaternion.identity, 1f, 1f, Handles.SphereHandleCap)){
                targetIndex = i; break;
            }
        }

        if (targetIndex >= 0 && targetIndex < agentDemo.movePoints.Count)
        {
            Vector3 newPosition = Handles.PositionHandle(agentDemo.movePoints[targetIndex], Quaternion.identity);
            RaycastHit hit;
            if (Physics.Raycast(newPosition + Vector3.up * 10, Vector3.down, out hit)){
                newPosition = hit.point;
            }
            agentDemo.movePoints[targetIndex] = newPosition;
        }
    }
}
*/

[RequireComponent(typeof(NavMeshAgent))]
public class AgentDemo : MonoBehaviour
{
    NavMeshAgent agent;
    public List<Vector3> movePoints = new List<Vector3>();

    void Awake() => agent = GetComponent<NavMeshAgent>();

    // Update is called once per frame
    void Update()
    {
        if (movePoints.Count <= 0) return;
        agent.destination = movePoints[0];
        Vector3 destination = movePoints[0];
        Vector3 position = transform.position;
        Vector3 move = destination - position;
        move.y = 0f;
        if (move.magnitude <= 0.5f)
        {
            movePoints.RemoveAt(0);
        }
    }
}
