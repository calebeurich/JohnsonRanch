using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public GameObject pausePannel;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(pausePannel.activeSelf)
            {
                pausePannel.SetActive(false);
                Time.timeScale = 1f;
            } else
            {
                pausePannel.SetActive(true);
                Time.timeScale = 0f;
            }
        }   
    }
}
