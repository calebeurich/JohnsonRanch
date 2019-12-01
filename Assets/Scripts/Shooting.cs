using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Shooting : MonoBehaviour
{
    public GameObject firePoint;
    public GameObject bangParticles;
    public ParticleSystem muzzleFlash;
    public float range = 500f;
    public Image[] bulletImages;
    private int remainingBullets;
    private int totalBullets;
    public bool canShoot = true;
    public float delayInSeconds;
    public float RDelayInSeconds;
    public bool notReloading = true;

    private void Start()
    {
        totalBullets = bulletImages.Length;
        remainingBullets = totalBullets;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && remainingBullets > 0 && canShoot && notReloading)
        {
            ShootGun();
            StartCoroutine(ShootDelay());
            RaycastHit hit;
            if (Physics.Raycast(firePoint.transform.position, firePoint.transform.forward, out hit))
            {
                Vector3 forward = firePoint.transform.TransformDirection(Vector3.forward) * range;
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
                    GameManager.instance.RemoveEnemy(targetGameObject);
                    //kill the enemy anamation
                }
            }


        }

        if(remainingBullets == 0)
        {
            UIManager.instance.SetReloadTextActive(true);
        }

        if(Input.GetKeyDown(KeyCode.R) && remainingBullets != totalBullets)
        {
            ReloadGun();
            StartCoroutine(ReloadDelay());

        }
    }

    

    private void ShootGun()
    {
        muzzleFlash.Play();
        remainingBullets--;
        Color dischargedColor = bulletImages[remainingBullets].color;
        dischargedColor.a = 0.12f;
        bulletImages[remainingBullets].color = dischargedColor;
        canShoot = false;
    }

    private void ReloadGun()
    {
        foreach(Image bullet in bulletImages)
        {
            bullet.color = Color.white;
        }
        remainingBullets = totalBullets;
        UIManager.instance.SetReloadTextActive(false);
        notReloading = true;
    }

    IEnumerator ShootDelay()
    {
        yield return new WaitForSeconds(delayInSeconds);
        canShoot = true;
    }
    IEnumerator ReloadDelay()
    {
        yield return new WaitForSeconds(RDelayInSeconds);
        notReloading = true;
    }

}

