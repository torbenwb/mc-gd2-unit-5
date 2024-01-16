using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour, IIntListener
{
    public Unit blueBase;
    public Unit redBase;
    bool gameOver = false;
    public TextMeshProUGUI gameOverText;

    // Start is called before the first frame update
    void Start()
    {
        blueBase.health.listeners.Add(gameObject);
        redBase.health.listeners.Add(gameObject);
    }

    public void IntUpdate(IntWrapper i)
    {
        if (i == blueBase.health) BlueBaseUpdate();
        else if (i == redBase.health) RedBaseUpdate();
    }

    void BlueBaseUpdate(){
        if (blueBase.health.Value > 0 || gameOver) return;
        gameOverText.text = "Red Team Wins";
        StartCoroutine(GameOver());
    }

    void RedBaseUpdate(){
        if (redBase.health.Value > 0 || gameOver) return;
        gameOverText.text = "Blue Team Wins";
        StartCoroutine(GameOver());
    }

    IEnumerator GameOver()
    {
        gameOver = true;
        while(Time.timeScale > 0)
        {
            float alpha = gameOverText.color.a;
            alpha += Time.deltaTime;
            Color newColor = gameOverText.color;
            newColor.a = alpha;
            gameOverText.color = newColor;

            Time.timeScale -= Time.deltaTime;
            if (Time.timeScale < 0.2f)
            { 
                Time.timeScale = 1f;
                SceneManager.LoadScene(0);
            }
            yield return null;
        }
    }
}
