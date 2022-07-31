using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelpMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;

    public GameObject HelpMenuUI;
    public GameObject PauseMenuUI;

    //public PauseGame PauseLogic;

    // Update is called once per frame
    /*
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            if (GameIsPaused){
                Resume();
            }
            else {
                Pause();
            }
        }
    }
    */

    public void ManualUpdate() {
        if (GameIsPaused){
            Resume();
        }
        /*
        else if(PauseLogic.GameIsTransitioning) {
                //Do nothing lol
        }
        */
        else {
            Pause();
        }
    }

    void Resume() {
        GameIsPaused = false;
        HelpMenuUI.SetActive(false);
        PauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
    }

    void Pause() {
        GameIsPaused = true;
        HelpMenuUI.SetActive(true);
        PauseMenuUI.SetActive(false);
        Time.timeScale = 0f;
    }
}
