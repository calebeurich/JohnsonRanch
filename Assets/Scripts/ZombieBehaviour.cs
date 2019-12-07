using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieBehaviour : MonoBehaviour
{
    public Transform target;
    private float speed = 3f;
    public GameObject gameoverPanel;
    public float range = 1f;
    public float hitRate = 1f;

    private void Start()
    {
        StartCoroutine(CheckHit());
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        transform.LookAt(target);
    }

    private IEnumerator CheckHit()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.forward, out hit))
        {
            GameObject targetGameObject = hit.collider.gameObject;
            if (targetGameObject.tag == "Player" && hit.distance <= range)
            {
                GameManager.instance.DecreaseLives();
            }
        }
        yield return new WaitForSeconds(hitRate);
        StartCoroutine(CheckHit());
    }
}
