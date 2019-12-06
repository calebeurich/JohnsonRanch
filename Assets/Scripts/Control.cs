using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Basic script to switch scenes
public class Control : MonoBehaviour
{
    public string sceneName;

    void NextScene()
    {
        SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
    }
}
