using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuCommands : MonoBehaviour
{
    public GameObject CreditsMenu;
    public GameObject MainMenu;
    public GameObject MenuButtons;
    public GameObject Return;
    public GameObject CreditsInterface;

    void Start() {
        ReturnToMain();
    }

    public void ReturnToMain() {
        CreditsMenu.SetActive(false);
        Return.SetActive(false);
        CreditsInterface.SetActive(false);

        MainMenu.SetActive(true);
        MenuButtons.SetActive(true);
    }

    public void GoToCredits() {
        CreditsMenu.SetActive(true);
        Return.SetActive(true);
        CreditsInterface.SetActive(true);
        
        MainMenu.SetActive(false);
        MenuButtons.SetActive(false);
    }

    public void QuitGame() {
        Application.Quit();
    }
}
