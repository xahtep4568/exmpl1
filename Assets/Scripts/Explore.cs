using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explore : MonoBehaviour
{
    public float timeExplore = 0.25f;
    void Start()
    {
        Destroy(gameObject, timeExplore);
    }

}
