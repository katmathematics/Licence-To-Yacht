using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;

    public GameObject PauseMenuUI; 

    // Update is called once per frame
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

    public void ManualUpdate() {
        if (GameIsPaused){
            Resume();
        }
        else {
            Pause();
        }
    }

    void Resume() {
        GameIsPaused = false;
        PauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
    }

    void Pause() {
        GameIsPaused = true;
        PauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
    }
}
