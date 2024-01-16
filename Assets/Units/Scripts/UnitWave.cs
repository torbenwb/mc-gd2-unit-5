using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class UnitWave : ScriptableObject
{
    public List<GameObject> prefabs;
    public float startDelay = 2f;
    public float spawnDelay = 0.2f;
    public float spawnInterval = 10f;
}
