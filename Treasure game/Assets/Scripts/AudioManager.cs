using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
   [SerializeField] Image soundOnIcon;
   [SerializeField] Image soundOffIcon;
   
   private bool muted = false;

   private void Start()
   {
      if (!PlayerPrefs.HasKey("muted"))
      {
         PlayerPrefs.SetInt("muted", 0);
         Load();
      }
      else
      {
         Load();
      }
      UpdateButtonIcon();
      AudioListener.pause = muted;
   }

   public void ButtonPressed()
   {
      if (muted == false)
      {
         muted = true;
         AudioListener.pause = true;
      }
      else
      {
         muted = false;
         AudioListener.pause = false;
      }
      Save();
      UpdateButtonIcon();
   }

   private void UpdateButtonIcon()
   {
      if (muted == false)
      {
         soundOnIcon.enabled = true;
         soundOffIcon.enabled = false;
      }
      else
      {
         soundOnIcon.enabled = false;
         soundOffIcon.enabled = true;
      }
   }
<<<<<<< Updated upstream

=======
>>>>>>> Stashed changes
   private void Load()
   {
      muted = PlayerPrefs.GetInt("muted") == 1;
      
   }

   private void Save()
   {
      PlayerPrefs.SetInt("muted", muted ? 1 : 0);
   }
}
