using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeBackground : MonoBehaviour
{
    public GameObject Roblox;
    public GameObject Smile;
    public bool isSmile = false;
    private void Start()
    {
        
    }
    private void Update()
    {
     
    }

    public void BackgroundChanger()
    {
        if (isSmile == false)
        {
            Roblox.SetActive(false);
            Smile.SetActive(true);
            isSmile = true;
        }

        else
        {
            Roblox.SetActive(true);
            Smile.SetActive(false);
            isSmile = false;
        }
       
    }
}
