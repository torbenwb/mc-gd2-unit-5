using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTarget : MonoBehaviour
{
    public AttackTarget attackTarget;
    public MoveToPosition moveTarget;
    public GameObject moveVis;
    public GameObject attackVis;
    public float frequency = 2f;
    public float amplitude = 0.1f;

    // Update is called once per frame
    void Update()
    {
        transform.localScale = Vector3.one + (Vector3.one * (Mathf.Sin(Time.time * frequency) * amplitude));
        if (attackTarget.target) {
            
            transform.position = attackTarget.target.transform.position;
            attackVis.SetActive(true);
            moveVis.SetActive(false);
        }
        else if (moveTarget.destinationSet) {
            transform.position = moveTarget.destination;
            attackVis.SetActive(false);
            moveVis.SetActive(true);
        }
        else
        {
            attackVis.SetActive(false);
            moveVis.SetActive(false);
        }
    }
}
