using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class FollowCamera : MonoBehaviour
{
    public Vector3 origin;
    public float pitch;
    public float yaw;
    public float distance;

    // Added after video section
    public Transform followObject;
    public float moveSpeed = 5f;

    void LateUpdate()
    {
        if (followObject){
            float distance = (origin - followObject.position).magnitude;
            float delta = distance * moveSpeed * Time.deltaTime;
            origin = Vector3.MoveTowards(origin, followObject.position, delta);
        }

        Quaternion rotation = Quaternion.Euler(pitch, yaw, 0f);
        Vector3 direction = rotation * Vector3.forward;
        Vector3 cameraPosition = origin - direction * distance;
        Camera.main.transform.position = cameraPosition;
        Camera.main.transform.rotation = rotation;
    }

}
