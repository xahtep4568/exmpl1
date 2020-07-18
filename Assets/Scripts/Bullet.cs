using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private int speedBullet = 9;
    public bool isPlayer = true;
    public int dir = 1;
    private void FixedUpdate()
    {
        transform.Translate(transform.up*dir* speedBullet * Time.deltaTime, Space.World);
        if (transform.position.y > 4.5f || transform.position.y < -5.5) Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy" && isPlayer)
        {
            collision.SendMessage("Die");
            Destroy(gameObject);
        }
        if (collision.tag == "Player" && !isPlayer)
        {
            collision.SendMessage("Die");
            Destroy(gameObject);
        }
    }
}
