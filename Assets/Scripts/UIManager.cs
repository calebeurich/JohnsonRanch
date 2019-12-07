using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    private static UIManager _instance;
    public static UIManager instance { get { return _instance; } }

    public TextMeshProUGUI roundText;
    public TextMeshProUGUI remainingText;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI livesText;
    public GameObject reloadText;
    public GameObject gameOverPannel;

    //instance variable
    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }

    public void NextRound(int round)
    {
        roundText.text = "Round: " + round;
    }

    public void RemainingEnemies(int count)
    {
        remainingText.text = "Remaining: " + count;
    }

    public void SetReloadTextActive(bool isActive)
    {
        reloadText.SetActive(isActive);
    }

    public void UpdateScore(int score)
    {
        scoreText.text = "Score: " + score;
    }

    public void SetLives(int lives)
    {
        livesText.text = "Lives: " + lives;
    }

    public void GameOver()
    {
        Debug.Log(gameOverPannel);
        gameOverPannel.SetActive(true);
        Time.timeScale = 0f;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
    public void GameStart()
    {
        Debug.Log(gameOverPannel);
        gameOverPannel.SetActive(false);
        Time.timeScale = 1f;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
}
