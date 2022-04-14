using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    private Animator animator;  
    
    public static int score = 0; // score var that visible to all others
    
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        score = 0; // cuz static var sustains reloading scenes
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Text>().text = score.ToString();
    }

    public void AnimScore()
    {
        animator.SetTrigger("animSize");
    }
}
