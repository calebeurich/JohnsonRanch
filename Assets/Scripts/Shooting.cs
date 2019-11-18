using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Shooting : MonoBehaviour
{
    public GameObject firePoint;
    public GameObject bangParticles;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            if (Physics.Raycast(firePoint.transform.position, firePoint.transform.forward, out hit))
            {
                Vector3 forward = firePoint.transform.TransformDirection(Vector3.forward) * 10;
                Debug.DrawRay(firePoint.transform.position, forward, Color.green);
                //add shooting affect
                Collider target = hit.collider; // What did I hit?
                float distance = hit.distance; // How far out?
                Vector3 location = hit.point; // Where did I make impact?
                GameObject targetGameObject = hit.collider.gameObject; // What's the GameObject?
                if (targetGameObject.tag == "Enemy")
                {
                    //also check if its too far away?
                    Instantiate(bangParticles, location, Quaternion.identity);
                    GameManager.instance.RemoveEnemy(target.gameObject);
                    //kill the enemy anamation
                }
            }


        }
    }
}
