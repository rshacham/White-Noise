using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoButton : MonoBehaviour
{
    private bool active = false;
    [SerializeField] private GameObject info;
    
    public void TurnInfo()
    {
        active = !active;
        info.SetActive(active);
    }
}
