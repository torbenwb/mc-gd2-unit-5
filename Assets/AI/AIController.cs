using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ITask
{
    public bool Evaluate();
}

public class AIController : MonoBehaviour
{
    public float updateFrequency = 0.2f;
    public List<MonoBehaviour> tasks = new List<MonoBehaviour>();

    public MonoBehaviour activeTask;

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < tasks.Count; i++) if (!(tasks[i] is ITask)) tasks.RemoveAt(i--);
        StartCoroutine(EvaluateTasks());
    }

    IEnumerator EvaluateTasks()
    {
        while(true)
        {
            for(int i = 0; i < tasks.Count; i++)
            {
                if ((tasks[i] as ITask).Evaluate()){
                    activeTask = tasks[i];
                    break;
                }
            }
            yield return new WaitForSeconds(updateFrequency);
        }
    }
}
