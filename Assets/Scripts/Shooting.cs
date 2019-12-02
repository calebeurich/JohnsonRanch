using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Shooting : MonoBehaviour
{
    public GameObject firePoint;
    public GameObject bangParticles;
    public ParticleSystem muzzleFlash;
    public Image[] bulletImages;
    public bool canShoot = true;
    public float shotDelay = 0.5f;
    public bool reloading = false;
    public Weapon selectedWeapon;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && selectedWeapon.remainingBullets > 0 && canShoot && !reloading)
        {
            ShootGun();
            StartCoroutine(ShootDelay());
            RaycastHit hit;
            if (Physics.Raycast(firePoint.transform.position, firePoint.transform.forward, out hit))
            {
                Vector3 forward = firePoint.transform.TransformDirection(Vector3.forward) * selectedWeapon.range;
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

        if(selectedWeapon.remainingBullets == 0)
        {
            UIManager.instance.SetReloadTextActive(true);
        }

        if(Input.GetKeyDown(KeyCode.R) && selectedWeapon.remainingBullets != selectedWeapon.clipSize)
        {
            StartCoroutine(ReloadGun());
        }
    }

    

    private void ShootGun()
    {
        muzzleFlash.Play();
        selectedWeapon.remainingBullets--;
        Color dischargedColor = bulletImages[selectedWeapon.remainingBullets].color;
        dischargedColor.a = 0.12f;
        bulletImages[selectedWeapon.remainingBullets].color = dischargedColor;
        canShoot = false;
    }

    private IEnumerator ReloadGun()
    {
        reloading = true;
        foreach (Image bullet in bulletImages)
        {
            yield return new WaitForSeconds(selectedWeapon.reloadRate);
            bullet.color = Color.white;
        }
        selectedWeapon.remainingBullets = selectedWeapon.clipSize;
        UIManager.instance.SetReloadTextActive(false);
        reloading = false;
    }

    IEnumerator ShootDelay()
    {
        yield return new WaitForSeconds(shotDelay);
        canShoot = true;
    }
}

