using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamageable
{
    public void TakeDamage(int damage);
}

public class Unit : MonoBehaviour, IDamageable
{
    public IntWrapper health;
    public RegenerateHealth regen;
    public bool respawn = false;
    public Vector3 respawnPosition;

    void Awake() => regen = GetComponent<RegenerateHealth>();
    void Start() => respawnPosition = transform.position;

    public void TakeDamage(int damage)
    {
        health.Value -= damage;
        if (health.Value <= 0) 
        {
            if (respawn) {
                transform.position = respawnPosition;
                health.Value = health.Max;
            }
            else Destroy(gameObject);
        }
        else if (regen) regen.StartRegenerating(health);
    }
}
