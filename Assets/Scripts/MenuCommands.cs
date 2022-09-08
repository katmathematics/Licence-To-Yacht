using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuCommands : MonoBehaviour
{
    public GameObject CreditsMenu;
    public GameObject MainMenu;

    void Start() {
        CreditsMenu.SetActive(false);
    }

    public void ReturnToMain() {
        CreditsMenu.SetActive(false);
        MainMenu.SetActive(true);
    }

    public void GoToCredits() {
        CreditsMenu.SetActive(true);
        MainMenu.SetActive(false);
    }

    public void QuitGame() {
        Application.Quit();
    }
}
