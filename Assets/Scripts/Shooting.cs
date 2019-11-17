using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Shooting : MonoBehaviour
{

    public GameObject player;
    public GameObject gun;
    //put firePoint in right place
    public GameObject firePoint;


    // Start is called before the first frame update
    void Start()
    {



    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        { 
            RaycastHit hit;
            if (Physics.Raycast(firePoint.transform.position, firePoint.transform.forward, out hit))
            {
                //add shooting affect
                Collider target = hit.collider; // What did I hit?
                float distance = hit.distance; // How far out?
                Vector3 location = hit.point; // Where did I make impact?
                GameObject targetGameObject = hit.collider.gameObject; // What's the GameObject?

                if (target.tag == "enemy") {
                    //also check if its too far away?
                    GameManager.instance.RemoveEnemy(target.gameObject);
                    //kill the enemy anamation
                }
            }

            
        }
    }
}
