using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public string gunName;
    public int clipSize;
    public int remainingBullets;
    public float reloadRate;
    public float range;

    private void Start()
    {
        remainingBullets = clipSize;
    }
}
