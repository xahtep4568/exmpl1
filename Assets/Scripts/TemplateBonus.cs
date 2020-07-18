using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TemplateBonus : MonoBehaviour
{

    private int speed = 5;

    protected void FixedUpdate()
    {
        transform.Translate(-transform.up * speed * Time.deltaTime, Space.World);
        if (transform.position.y < -5.5f)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag == "Player")
        {
            TakeBonus();
            Destroy(gameObject);
        }

    }
    protected abstract void TakeBonus();
}
