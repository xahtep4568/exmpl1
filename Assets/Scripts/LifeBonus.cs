﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeBonus : TemplateBonus
{

    protected override void TakeBonus()
    {
        PlayerManager.Instance.Life++;
    }
}
