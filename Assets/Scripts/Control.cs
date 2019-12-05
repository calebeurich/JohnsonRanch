using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Control : MonoBehaviour
{
    void NextScene()
    {
        SceneManager.LoadScene("PrettyScene", LoadSceneMode.Single);
    }
}
