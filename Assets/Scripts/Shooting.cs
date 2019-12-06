using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Shooting : MonoBehaviour
{
    public GameObject bangParticles;
    public Weapon selectedWeapon;
    public Image[] bulletImages;
    public bool canShoot = true;
    public float shotDelay = 0.5f;
    public bool reloading = false;
    public AudioSource gunNoise;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && selectedWeapon.remainingBullets > 0 && canShoot && !reloading)
        {
            ShootGun();
            StartCoroutine(ShootDelay());
            RaycastHit hit;
            if (Physics.Raycast(selectedWeapon.firePoint.transform.position, selectedWeapon.firePoint.transform.forward, out hit))
            {
                Vector3 forward = selectedWeapon.firePoint.transform.TransformDirection(Vector3.forward) * selectedWeapon.range;
                Debug.DrawRay(selectedWeapon.firePoint.transform.position, forward, Color.green);
                //add shooting affect
                Collider target = hit.collider; // What did I hit?
                float distance = hit.distance; // How far out?
                Vector3 location = hit.point; // Where did I make impact?
                GameObject targetGameObject = hit.collider.gameObject; // What's the GameObject?

                if (targetGameObject.tag == "Enemy")
                {
                    Instantiate(bangParticles, location, Quaternion.identity);
                    GameManager.instance.RemoveEnemy(targetGameObject);
                } else if(targetGameObject.tag == "Weapon")
                {
                    //Todo weapon pickups:

                    //This raycasting would need to be moved to a seperate script and would call this shooting script,
                    //and a selected gun handler script (not created yet) that would handle the following:
                        //Position the newly selected weapon properly (so that it shoots where the cursor is, difficult because the gun is offset from center of screen)
                        //Drop old weapon
                        //Change the UI to display the right number of bullets
                        //Assign to the shooting script the newly selected weapon (class I already created)
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
        gunNoise.Play();
        selectedWeapon.muzzleFlash.Play();
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

    public void SelectWeapon(Weapon pickedUpWeapon)
    {
        selectedWeapon = pickedUpWeapon;
    }
}

