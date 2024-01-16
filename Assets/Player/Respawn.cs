using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    public Vector3 respawnPosition;
    public float respawnTime = 3f;

    public void Start_Respawn(IntWrapper health)
    {
        StartCoroutine(Wait());

        IEnumerator Wait()
        {
            float timer = respawnTime;
            while(timer > 0f)
            {
                timer -= Time.deltaTime;
                yield return null;
                transform.position = respawnPosition;
                health.Value = health.Max;
            }
        }
    }
}
