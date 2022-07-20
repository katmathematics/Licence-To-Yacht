using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleHUD : MonoBehaviour
{
    //public Text nameText; //Create a unity slot for the text box to be used to render text information
    public Slider hpSlider; //Create a unity slot for the slider to be used to render health information

    //A function for establishing the initial state of the battle HUD
    public void SetHUD(Unit unit) {
        //nameText.text = unit.unitName; //Display the unit's name
        hpSlider.maxValue = unit.maxHP; //Set the slider max to the unit's max HP
        hpSlider.value = unit.currentHP; //Set the slider's value to the unit's current HP
    }

    //A function for updating the on-screen display to match the unit's hp.
    public void SetHP(int hp) {
        hpSlider.value = hp;
    }
}
