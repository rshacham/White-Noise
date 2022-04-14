using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Speed : MonoBehaviour
{
    public static float theSpeed = 10; 
    public static float initSpeed = 10;

    private bool add = true;

    public float speedTime;
    
    public float speedUp;

    // Update is called once per frame
    void Update()
    {
        // print(theSpeed);
        
        if (add)
        {
            theSpeed += speedUp;
            add = false;
            // print(theSpeed);
            Invoke("EnableAdd", speedTime);
        }
    }
    
    private void EnableAdd()
    {
        add = true;
    }
}
