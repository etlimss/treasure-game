using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScript : MonoBehaviour
{
    public PlayerInventory PlayerInventory;
    public GameObject GameOverPanel;
    public GameObject TestingPanel;
    private PauseMenu _pauseMenu;
    private MainMenu _mainMenu;
    public GirlMovement GirlMovement;
    public void Home(int sceneID)
    {
        SceneManager.LoadScene(sceneID);
    }
    // changing after health bar implemented.
    private void OnTriggerEnter(Collider other)
    {
        if ((other.tag == "Player") && (PlayerInventory.NumberOfFlowers == 0))
        {
            GameOverPanel.SetActive(true);
            Time.timeScale = 0f;
           // MainMenu mainMenu = GameObject.Find("MainMenu").GetComponent<"MainMenu">();
        }
       
        else
        { 
            TestingPanel.SetActive(true);
            Invoke("DisablePanel", 3.0f);
        }
    }
    public void OnReloadButton()
    {
        // _mainMenu.StartGame();
        Time.timeScale = 1f;
        SceneManager.LoadScene(1);
    }
}
