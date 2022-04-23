using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayButton : MonoBehaviour
{
    private Image buttonImage;

    [SerializeField] private List<Sprite> buttonSprites;
    [SerializeField] private SoundButton soundScript;
    // Start is called before the first frame update
    void Start()
    {
        buttonImage = gameObject.GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if (soundScript.soundSource.clip == null)
        {
            buttonImage.sprite = buttonSprites[0];
        }
        else if (soundScript.soundSource.isPlaying)
        {
            buttonImage.sprite = buttonSprites[2];
        }

        else
        {
            buttonImage.sprite = buttonSprites[1];
        }
    }
}
