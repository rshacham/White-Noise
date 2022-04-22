using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class Bird : MonoBehaviour
{
    public GameObject gameManager;
    
    public float upVelocity;

    private Rigidbody2D rb;

    public GameObject woodCreator;

    public float gravityScale;

    public GameObject pressSpaceTxt;

    private bool isDead = false;

    private Vector3 initPos;
    
    public AudioSource audioSourceFruit;
    public AudioClip audioClipFruit;

    public GameObject inputSound;

    [SerializeField] private UnityEvent scoreAnim;
    
    
    // bird rotate

    public float maxAngle = 30;
    public float maxHeight = 5;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        transform.eulerAngles = new Vector3(0, 0, 90);
        initPos = transform.position;
        // audioClipFruit = inputSound.GetComponent<SoundButton>().mySound;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            // if (isDead) { SceneManager.LoadScene(0); }
            // if (pressSpaceTxt.activeSelf) {pressSpaceTxt.SetActive(false);}
            
            // woodCreator.SetActive(true);
            // rb.gravityScale = gravityScale;
            // Jump();
        }

        // update rotation 
        transform.eulerAngles = new Vector3(0, 0, transform.position.y * maxAngle / maxHeight);
    }

    private void Jump()
    {
        rb.velocity = Vector2.up * upVelocity;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // take sound
        // audioClipFruit = inputSound.GetComponent<SoundButton>().mySound;

        if (other.gameObject.name == "fruit(Clone)")
        {
            GameObject.Find("fruitSound").GetComponent<AudioSource>().Play();
            // SoundManager._shared.PlayOuterSoundOneTime(audioSourceFruit, audioClipFruit);
            return;
        }

        isDead = true;
        // lose sound
        GetComponent<AudioSource>().Play();
        Score.score = 0;
        scoreAnim.Invoke(); // score anim
        transform.position = initPos;
        Speed.theSpeed = Speed.initSpeed;
        // game over display
        // gameManager.GetComponent<GameManager>().GameOver();
        // Invoke("ReStart", 1);
        // Time.timeScale = 0;
        // then back
        // move
    }

    public void ReStart()
    {
        Time.timeScale = 1;
    }
}
