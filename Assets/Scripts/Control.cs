using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

//Basic script to switch scenes
public class Control : MonoBehaviour
{
    public string sceneName;
    public Image black;
    public Animator anim;

    public void NextScene()
    {
        SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
    }

   // IEnumerator Fading()
    //{
       // anim.SetBool("Fade", true);
      //  yield return new WaitUntil(()=>black.color.a==1);
       // SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
    //}

}
