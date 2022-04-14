using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodMove : MonoBehaviour
{
    // private float speed = 10;

    public float acceleratingAmount;

    // private bool add = true;

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.left * Speed.theSpeed * Time.deltaTime;
    }

    // public void WoodsMoveFaster()
    // {
    //     speed += acceleratingAmount;
    // }
}
