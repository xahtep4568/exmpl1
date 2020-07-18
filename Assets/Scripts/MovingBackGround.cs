using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingBackGround : MonoBehaviour
{
    // Update is called once per frame
    void Update ()
    {
        transform.Translate(-Vector3.up *3* Time.deltaTime, Space.World);
        if (transform.position.y <= -12) transform.position = new Vector3(0,12,0);
	}
}
