using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoopDelay : MonoBehaviour
{
    [SerializeField] Image buttonImage;
    [SerializeField] private Image markerImage;

    [SerializeField] private List<Sprite> baseSprites;
    [SerializeField] private List<Sprite> markerSprites;
    [SerializeField] private SoundButton soundScript;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (soundScript.soundSource.clip == null)
        {
            buttonImage.color = soundScript.fadeColor;
            markerImage.color = soundScript.fadeColor;
            buttonImage.sprite = baseSprites[0];
            markerImage.sprite = markerSprites[0];

        }

        else
        {
            buttonImage.color = Color.white;
            markerImage.color = Color.white;
            buttonImage.sprite = baseSprites[1];
            markerImage.sprite = markerSprites[1];
        }
    }
}
