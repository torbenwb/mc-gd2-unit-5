using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IIntListener
{
    public void IntUpdate(IntWrapper intWrapper);
}

[System.Serializable]
public class IntWrapper
{
    [SerializeField] int value;
    [SerializeField] int max;
    [SerializeField] public List<GameObject> listeners;

    public int Value
    {
        get => value;
        set
        {
            this.value = value;
            foreach(GameObject gameObject in listeners)
            {
                gameObject.GetComponent<IIntListener>().IntUpdate(this);
            }
        }
    }

    public float Ratio => (float)value / max;
    public int Max => max;
}
