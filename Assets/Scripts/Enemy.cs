using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : TemplateShips
{
    [SerializeField]private List<GameObject> bonuses;
    public GameObject bulletPref;
    public float attackTime = 1;
    protected int maxDelayShoot = 100;
    float startPos;
    int model;
    int amplitude;

    protected void Start()
    {
        speed = 3;
        startPos = transform.position.x;
    }
    private void Update()
    {
        Move();
        if (attackTime > 0)
        {
            attackTime -= Time.deltaTime;
        }
        else
        {
            Shoot();
            attackTime = (float)(Random.Range(10, maxDelayShoot) * 0.01);
        }
    }

    protected override void Move()
    {
        Vector2 pos = transform.position;
        

        if (pos.y < -5.5f)
        {
            Destroy(gameObject);
        }
        pos.y = pos.y - Time.deltaTime * speed;
        pos.x = ChoiceMove(model,pos.y) * amplitude+ startPos;
        transform.position = pos;
    }
    protected override void Die()
    {
        PlayerManager.Instance.PlayerScore+=Random.Range(10,50);
        Instantiate(explore, transform.position, transform.rotation);
        if(Random.Range(0,100)<=20)
            Instantiate(bonuses[Random.Range(0, bonuses.Count)], transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
    public void SetModel(int model, int amplitude)
    {
        this.model = model;
        this.amplitude = amplitude;
    }

    private float ChoiceMove(int direction,float y)
    {
        float temp;
        if (direction == 1) temp = Mathf.Cos(y);
        else if (direction == 2) temp = Mathf.Sin(y);
        else temp = Mathf.Exp(y)-2;
       return temp;
    }
}
