using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerManager : MonoBehaviour
{
    public GameObject playerPrefab;
    public float respawnTime = 3f;
    public Vector3 respawnPosition;
    public TextMeshProUGUI respawnText;
    bool timerActive = false;

    public void Respawn()
    {
        if (timerActive) return;
        StartCoroutine("Wait");

        IEnumerator Wait()
        {
            timerActive = true;
            float timer = respawnTime;
            while(timer > 0f)
            {
                respawnText.text = timer.ToString(".");
                respawnTime -= Time.deltaTime;
                yield return null;
            }
            
            FindObjectOfType<FollowCamera>().followObject = Instantiate(playerPrefab, respawnPosition, Quaternion.identity).transform;
            timerActive = false;
        }
    }
    
}
