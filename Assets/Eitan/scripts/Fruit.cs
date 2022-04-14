using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour
{
    // private float speed = 10;
    
    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.left * Speed.theSpeed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Score.score++;
        gameObject.SetActive(false);
    }
}
