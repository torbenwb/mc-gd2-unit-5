using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAbility
{
    public bool Request{get;set;}
    public Vector3 Target{get;set;}
}

public class ProjectileAbility : MonoBehaviour, IAbility, ITask
{
    bool request;
    bool aimActive;
    Vector3 aimDirection;
    public float cooldownTime = 1f;
    bool cooldownActive = false;
    public GameObject projectilePrefab;

    public bool Request{
        get => request;
        set => request = value;
    }

    public Vector3 Target{
        get => aimDirection;
        set => aimDirection = Vector3.ProjectOnPlane((value - transform.position), Vector3.up).normalized;
    }

    public bool Evaluate()
    {
        if (cooldownActive) return false;

        if (request && !aimActive){
            aimActive = true;
            return true;
        }
        else if (request && aimActive) return true;
        else if (!request && aimActive){
            Instantiate(projectilePrefab, transform.position, Quaternion.LookRotation(aimDirection));
            aimActive = false;
            StartCoroutine(Cooldown());
        }
        return false;
    }

    IEnumerator Cooldown(){
        cooldownActive = true;
        yield return new WaitForSeconds(cooldownTime);
        cooldownActive = false;
    }

}
