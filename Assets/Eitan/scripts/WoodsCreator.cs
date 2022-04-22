using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
using SysRandom = System.Random;

public class WoodsCreator : MonoBehaviour
{
    public int acceleratingTime; // every acceleratingTime seconds, woods will bo moving faster
    
    private float maxTime;
    public float averageTime;
    public float averageWidth;
    public float deltaTime;
    private float timer = 0;
    public float hightUp;
    public float hightDown;
    public float deltaWidth;

    public GameObject woodPrefab;
    
    // fruits

    public GameObject fruit;

    private List<Sprite> fruitList = new List<Sprite>();
    
    private float maxTimeFruit;

    private float timerFruit = 0;

    private bool fruitIsAllowed = true;

    private bool fruitFlag; // determines if fruit will appear for each wood
    
    // all fruits
    public Sprite apple;
    public Sprite strawberry;
    public Sprite bananas;
    public Sprite watermelon;
    public Sprite lemon;
    
    // random
    private SysRandom rnd = new SysRandom();


    private void Start()
    {
        maxTime = Random.Range(averageTime - deltaTime, averageTime + deltaTime);
        
        fruitFlag = rnd.Next(1, 5) > 1; // Probabilistic bias to appearance of fruits: 4/5

        FillFruitList();
        
        Invoke("AccelerateWoods", acceleratingTime);
    }

    // Update is called once per frame
    void Update()
    {
        if (timer > maxTime)
        {
            // create new wood at the right corner of the screen
            GameObject newWood = Instantiate(woodPrefab, transform);
            // randomize the wood's height and width
            newWood.transform.position = Random.Range(0f, 1f) > 0.5f
                ? transform.position + new Vector3(0, hightUp, 0)
                : transform.position + new Vector3(0, hightDown, 0);
            newWood.transform.localScale = new Vector3
                (Random.Range(averageWidth - deltaWidth, averageWidth + deltaWidth), 1, 1);
            // destroy wood after 15 sec'
            Destroy(newWood, 15);
            // reset timers
            timer = 0;
            timerFruit = 0;
            // randomize the next maxTimes
            maxTime = Random.Range(averageTime - deltaTime, averageTime + deltaTime);
            // determine if fruit will appear in the next time
            fruitFlag = rnd.Next(1, 5) > 1;
            // enable fruit generating
            fruitIsAllowed = true;
        }

        // generate fruits exactly at the middle between adjacent woods
        if (fruitFlag && timerFruit > 0.5f * maxTime && fruitIsAllowed)
        {
            // create new fruit at the right corner of the screen
            GameObject newFruit = Instantiate(fruit, transform);
            // randomize height and fruit kind
            newFruit.transform.position = transform.position + new Vector3(0, Random.Range(-hightUp * 2, hightUp * 2), 0);
            newFruit.GetComponent<SpriteRenderer>().sprite = fruitList[rnd.Next(0, 4)];
            // destroy wood fruit 15 sec'
            Destroy(newFruit, 15);
            // disable fruit generating
            fruitIsAllowed = false;
        }
        
        // update timers
        timer += Time.deltaTime;
        timerFruit += Time.deltaTime;
    }

    private void FillFruitList()
    {
        fruitList.Add(apple);
        fruitList.Add(bananas);
        fruitList.Add(watermelon);
        fruitList.Add(lemon);
        fruitList.Add(strawberry);
    }

    private void AccelerateWoods()
    {
        // woodPrefab.GetComponent<WoodMove>().WoodsMoveFaster();
        Invoke("AccelerateWoods", acceleratingTime);
    }
}
