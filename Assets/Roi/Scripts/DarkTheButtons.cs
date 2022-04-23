using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using Slider = UnityEngine.UI.Slider;


public class DarkTheButtons : MonoBehaviour
{
    private Image[] childImages;

    [SerializeField] private SoundButton soundScript;

    [SerializeField] private List<Color> myColors;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        print(childImages.Length);
        foreach (var image in childImages)
        {
            if (soundScript.soundSource.clip == null)
            {
                image.tintColor = myColors[0];
            }

            else
            {
                image.tintColor = myColors[1];
            }
        }
    }
}
