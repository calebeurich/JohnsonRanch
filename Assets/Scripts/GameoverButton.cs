using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameoverButton : MonoBehaviour
{
    public Button mainMenuButton;
    public Button restartButton;

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
        Debug.Log("MM");
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Debug.Log("Restart");
    }
}
