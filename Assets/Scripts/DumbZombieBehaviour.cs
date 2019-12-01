using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class DumbZombieBehaviour : MonoBehaviour
{
    public Transform target;
    private float speed = 3f;
    public int lives = 3;

    void Update()
    {
		float step = speed * Time.deltaTime;
		transform.position = Vector3.MoveTowards(transform.position, target.position, step);
        transform.LookAt(target);
	}
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            lives--;
            UIManager.instance.SetLives(lives);

            if (lives == 0)
            {
                Debug.Log("YOUDIE");
            }
        }
    }
}
