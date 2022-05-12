using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;

public class Audio : MonoBehaviour
{
    private static Audio BackgroundMusic;
    
    // Start is called before the first frame update
    private void Awake()
    {
        if (BackgroundMusic == null)
        {
            BackgroundMusic = this;
            DontDestroyOnLoad(BackgroundMusic);
        }
        else
        {
            Destroy(gameObject);
        }
        // GameObject[] musicObj = GameObject.FindGameObjectsWithTag("GameMusic");
        // if (musicObj.Length > 1)
        // {
        //     Destroy(this.gameObject);
        // }
        // DontDestroyOnLoad(this.gameObject);
    }
}
