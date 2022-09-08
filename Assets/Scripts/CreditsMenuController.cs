using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditsMenuController : MonoBehaviour
{
    public GameObject CreditsMenu;
    public GameObject MainMenu;

    void ReturnToMain() {
        CreditsMenu.SetActive(false);
        MainMenu.SetActive(true);
    }

    void GoToCredits() {
        CreditsMenu.SetActive(true);
        MainMenu.SetActive(false);
    }
}
