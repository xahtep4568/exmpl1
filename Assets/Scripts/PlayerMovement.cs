using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : TemplateShips
{
    public GameObject bulletPref;
    private float timeDelayShoot = 0;
    private float fireRate = 10f;
    private int countShoots = 1;
    private float minPositionShoot = -0.5f;
    private float maxPositionShoot = 0.5f;
    private float offset = 0;
    public int CountShoots
    {
        get { return countShoots; }
        set
        {
            if (countShoots < 3)
            {
                countShoots++;
                offset = (maxPositionShoot - minPositionShoot) / countShoots;
            }
        }
    }
    private void Update()
    {
        Move();
        if (Input.GetKeyDown(KeyCode.Space) && Time.time >= timeDelayShoot)
        {
            timeDelayShoot = Time.time + 1f/fireRate;
            Shoot();
        }
    }
    protected override void Die()
    {
        PlayerManager.Instance.isDead = true;
        countShoots = 1;
        offset = 0;
        Instantiate(explore, transform.position, transform.rotation);
        Destroy(gameObject);
    }
    protected override void Move()
    {
        // get origin position
        var position = gameObject.transform.position;

        // add delta, and set range
        gameObject.transform.position =
            new Vector2(Mathf.Clamp(position.x + Input.GetAxis("Horizontal") / 5, -7f, 7f), Mathf.Clamp(position.y + Input.GetAxis("Vertical") / 5, -4f, 0f));
    }
    protected override void Shoot()
    {
        var temp = minPositionShoot + 0.2f;
        if (countShoots == 1) temp = 0;
        for (int i = 0; i < countShoots; i++)
        {
            Instantiate(bulletPref, transform.position + new Vector3(temp, 0, 0), Quaternion.identity);
            temp +=offset;
        }
    }
}
