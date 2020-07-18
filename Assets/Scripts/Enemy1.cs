using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : Enemy
{
    int countShoots = 3;
	// Use this for initialization
	void Start ()
    {
        base.Start();
        maxDelayShoot = 150;
    }

    protected override void Shoot()
    {
        var temp = -45f;
        for (int i = 0; i < countShoots; i++)
        {
            Instantiate(bulletPref, transform.position, transform.rotation * Quaternion.Euler(0, 0, temp));
            temp += 45;
        }
    }

}
