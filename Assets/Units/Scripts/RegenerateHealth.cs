using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegenerateHealth : MonoBehaviour
{
    public IntWrapper health;
    public float rate = 1f;
    public float startDelay = 1f;
    bool active = false;

    public void StartRegenerating(IntWrapper health)
    {
        StopAllCoroutines();
        this.health = health;
        StartCoroutine(Regenerate());
    }

    IEnumerator Regenerate()
    {
        yield return new WaitForSeconds(startDelay);
        while(health.Ratio < 1f)
        {
            yield return new WaitForSeconds(rate);
            health.Value += 1;
        }
    }
}
