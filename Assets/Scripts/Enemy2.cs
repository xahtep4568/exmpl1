using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2 : Enemy
{

    // Use this for initialization
    void Start()
    {
        base.Start();
    }

    protected override void Shoot()
    {
        Instantiate(bulletPref, transform.position, Quaternion.identity);
    }
}
