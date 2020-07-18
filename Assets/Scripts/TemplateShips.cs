using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TemplateShips : MonoBehaviour
{
    [SerializeField] protected int speed = 1;
    [SerializeField] protected GameObject explore;

    protected abstract void Move();
    protected abstract void Shoot();
    protected abstract void Die();
}
