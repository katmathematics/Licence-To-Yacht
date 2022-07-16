using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinLossDisplay : MonoBehaviour
{
    public GameObject WinDisplay;
    public GameObject LossDisplay;  

    // Start is called before the first frame update
    void Start()
    {
        if(BattleSystem.gameWon) {
            LossDisplay.SetActive(false);
            WinDisplay.SetActive(true);
        }
        else {
            LossDisplay.SetActive(true);
            WinDisplay.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
