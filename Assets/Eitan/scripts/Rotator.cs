using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 0.1f;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, 0, -1 * rotationSpeed * Time.deltaTime), Space.Self);
    }
}
