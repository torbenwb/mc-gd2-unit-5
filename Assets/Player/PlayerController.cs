using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MoveToPosition))]
[RequireComponent(typeof(AttackTarget))]
public class PlayerController : MonoBehaviour
{
    MoveToPosition moveToPosition;
    AttackTarget attackTarget;
    public List<MonoBehaviour> abilities = new List<MonoBehaviour>();

    public static Vector3 PlayerTarget{
        get{
            RaycastHit hit; Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit)) return hit.point;
            return Vector3.zero;
        }
        
    }
    
    void Awake()
    {
        moveToPosition = GetComponent<MoveToPosition>();
        attackTarget = GetComponent<AttackTarget>();
    }

    void Update()
    {
        (abilities[0] as IAbility).Request = Input.GetKey(KeyCode.Q);
        (abilities[0] as IAbility).Target = PlayerTarget;

        if (!Input.GetMouseButtonDown(1)) return;
        RaycastHit hit; Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
        {
            GameObject hitObject = hit.collider.gameObject;
            if (hitObject.layer == LayerMask.NameToLayer("Team 2")){
                if (hitObject.GetComponent<Unit>()){
                    Attack(hitObject);
                }
            }
            else SetDestination(hit.point);
        }
    }
    
    void SetDestination(Vector3 position)
    {
        moveToPosition.destination = position;
        moveToPosition.destinationSet = true;
        attackTarget.target = null;
    }

    void Attack(GameObject target)
    {
        attackTarget.target = target;
        moveToPosition.destinationSet = false;
    }
}
