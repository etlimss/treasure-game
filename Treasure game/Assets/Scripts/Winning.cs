using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Winning : MonoBehaviour
{
    public GameObject WinningPanel;
    public GameObject TestingPanel;
    
    public PlayerInventory PlayerInventory;
    
    private void OnTriggerEnter(Collider other)
    {
        if ((other.tag == "Player") && (PlayerInventory.NumberOfFlowers == 10))
        {
            WinningPanel.SetActive(true);
            Time.timeScale = 0f;
            DisablePanel();
        }
        else
        {
            TestingPanel.SetActive(true);
            Invoke("DisablePanel", 3.0f);
        }
        
    }

    void DisablePanel()
    {
        TestingPanel.SetActive(false);
    }
   
}