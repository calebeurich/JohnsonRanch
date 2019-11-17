using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DumbZombieBehaviour : MonoBehaviour
{
    public Transform target;
    private float speed = 1f;

    void Update()
    {
		float step = speed * Time.deltaTime;
		transform.position = Vector3.MoveTowards(transform.position, target.position, step);
        transform.LookAt(target);
	}
}
