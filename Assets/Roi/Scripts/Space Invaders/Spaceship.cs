using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spaceship : MonoBehaviour
{
    [SerializeField] private float leftBound;
    [SerializeField] private float rightBound;
    [SerializeField] [Range(0, 1)] float LerpConstant;
    [SerializeField] private float movementForce;
    private Shooter myShooter;

    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        myShooter = GetComponentInChildren<Shooter>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            myShooter.Shoot();
        }
    }

    private void FixedUpdate()
    {
        var spaceshipPosition = transform.localPosition;
        if (Input.GetKey(KeyCode.RightArrow) && transform.localPosition.x < rightBound)
        {
                transform.localPosition = new Vector3(spaceshipPosition.x + movementForce, spaceshipPosition.y,
                    spaceshipPosition.z);
        }
            
        else if (Input.GetKey(KeyCode.LeftArrow) && transform.localPosition.x > leftBound)
        {
                transform.localPosition = new Vector3(spaceshipPosition.x - movementForce, spaceshipPosition.y,
                    spaceshipPosition.z);

        }


        
    }
}
