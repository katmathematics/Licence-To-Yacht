using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class YachtSteering : MonoBehaviour
{
    //public GameObject[] dice;
    //public Image[] faces;

    public Image[] dice_display;
    public Sprite[] faces;
    public Color[] colors;

    public TMP_Text rollsLeftDisplayText; 

    public Button rollButton;
    public Button attackButton;
    public Button advanceButton;

    public Button[] selectors;

    public BattleSystem SystemControls;

    public GameObject YachtInterface; 

    public static bool[] activeDice = {true,true,true,true,true};

    public Yacht yacht_logic;

    public static int rolls_left;

    public static int[] dice_values = {1, 1, 1, 1, 1};
    private int diceValue;
    private int i;
    private int index;

    private Image imageRenderer;

    // Start is called before the first frame update
    void Start()
    {
        roll_selected(activeDice);
        UpdateDice();
    }

    public void initalizeYachtPhase() {
        foreach (var selectorButton in selectors) {
            selectorButton.enabled = true;
        }
        roll_selected(activeDice);
        UpdateDice();
        rolls_left = 2;
        UpdateRollsLeft();
    }


    public void onRollClick()
    {
        foreach (var selectorButton in selectors) {
            selectorButton.enabled = true;
        }
        if(BattleSystem.state == BattleState.YACHTPHASE && rolls_left > 0){
            rolls_left -= 1;
            UpdateRollsLeft();
            roll_selected(activeDice);
            UpdateDice();

            if(rolls_left <= 0) {
                rollButton.interactable = false;
            }
        }
        else
        {
            return;
        }
    }

    public void roll_selected(bool[] dice_to_roll)
    {
        int index = 0;
        foreach(bool i in dice_to_roll)
        {
            if(i)
            {
                dice_values[index] = Random.Range(1, 7);
            }
            index++;
            
        }
    }

    public void onDiceClick(int diceIndex)
    {
        if (activeDice[diceIndex]) {
             activeDice[diceIndex] = false;
        }
        else {
             activeDice[diceIndex] = true;
        }
        UpdateDice();
    }

    public void onScoreSelection(int selectorIndex) {
        rolls_left = 0;
        UpdateRollsLeft();
        foreach (var selectorButton in selectors) {
            if (selectorButton.interactable && selectorButton != selectors[selectorIndex]) {
                selectorButton.enabled = false;
            }
            else if (selectorButton == selectors[selectorIndex]) {
                selectorButton.interactable = false;
            }
        }
        rollButton.interactable = false;

        selectors[selectorIndex].interactable = false;
        advanceButton.interactable = true;
        BattleSystem.currentSelection = selectorIndex;
    }

    public void onAdvance() {

        BattleSystem.noActions = true;
        foreach(Button i in selectors)
        {
            if (i.interactable) {
                BattleSystem.noActions = false;
            }
            i.enabled = true;
        }

        rollButton.interactable = true;
        SystemControls.PlayerAttack();
        YachtInterface.transform.localPosition = new Vector3(0, 840, 0);
        activeDice[0] = true;
        activeDice[1] = true;
        activeDice[2] = true;
        activeDice[3] = true;
        activeDice[4] = true;

        rolls_left = 2;
        UpdateRollsLeft();
        BattleSystem.state = BattleState.PLAYERTURN;
        roll_selected(activeDice);
        UpdateDice();
    }

    public void selectScore()
    {
        // If its not a valid time to roll the dice, exit the function- else run the function for rolling the dice
        if(BattleSystem.state == BattleState.PLAYERTURN && rolls_left > 0){
            yacht_logic.dice.roll_selected_dice(activeDice);
        }
        else
        {
            return;
        }
    }

    public void UpdateDice() {
        i = 0;

        while (i < 5) {
            
            //diceValue = //yacht_logic.dice.dice_set[i];
            dice_display[i].sprite = faces[dice_values[i]-1];
            //dice_display[i].sprite
            if(activeDice[i]) {
                dice_display[i].color = colors[0];
            }
            else {
                dice_display[i].color = colors[1];
            }
            

            i += 1;
        }
    }

    public void UpdateRollsLeft() {
        rollsLeftDisplayText.text = "Rolls Left: " + rolls_left;
    }
}
