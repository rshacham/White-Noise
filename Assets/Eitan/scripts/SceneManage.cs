using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneManage : MonoBehaviour
{
    [SerializeField] private string thirdScenName;
    
    private string otherSceneName = "voicy bird";
    
    private Scene scene2;

    private bool isScene2Active = false;

    public Sprite toggleOffSprite;
    public Sprite toggleOnSprite;

    public GameObject toggleObj;
    private Image toggleImage;

    private void Awake()
    {
        // toggleImage = toggleObj.GetComponent<Image>();
        toggleImage = toggleObj.transform.Find("toggle image").gameObject.GetComponent<Image>();
    }

    public void SceneToggle()
    {
        if (!SoundManager._shared.OneClipLoaded())
        {
            return;
        }
        if (isScene2Active)
        {
            SceneManager.UnloadSceneAsync(otherSceneName);
            isScene2Active = false;
            toggleImage.sprite = toggleOffSprite;
        }
        
        else
        {
            SceneManager.LoadSceneAsync(otherSceneName, LoadSceneMode.Additive);
            isScene2Active = true;
            toggleImage.sprite = toggleOnSprite;
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene("New Main Scene 1");
    }
}
