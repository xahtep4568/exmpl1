using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootBonus : TemplateBonus
{

    protected override void TakeBonus()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>().CountShoots++;
    }
}
