using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class StealyZombie : MonoBehaviour
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
		if (collision.gameObject.tag == "House")
		{
            //switfch zombies to "stupid zombie stolen"
            //send them running away
		}
        //if range is certian distance from the house
        //trigger game over
	}
}


