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
    public TMP_Text[] selector_display;
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

    private int[] score_values = {0,0,0,0,0,0,0,0,0,0,0};
    private bool[] active_selectors = {true,true,true,true,true,true,true,true,true,true,true};

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

        active_selectors[selectorIndex] = false;

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


        score_values[0] = st_score_one();
        score_values[1] = st_score_two();
        score_values[2] = st_score_three();
        score_values[3] = st_score_four();
        score_values[4] = st_score_five();
        score_values[5] = st_score_six();
        score_values[6] = st_score_4kind();
        score_values[7] = st_score_smstr8();
        score_values[8] = st_score_lgstr8();
        score_values[9] = st_score_fhouse();
        score_values[10] = st_score_yacht();

        for(int g = 0; g < selector_display.Length; g++) {
            if(active_selectors[g]) {
                selector_display[g].text = score_values[g].ToString();
            } 
            
        }
    }

    public void UpdateRollsLeft() {
        rollsLeftDisplayText.text = "Rolls Left: " + rolls_left;
    }

    private int st_score_one(){
        //if(!available_choices["1"]) return 0;
        int score = 0;
        foreach(var die in dice_values)
        {
            if(die == 1)
            {
                score = score + 1;
            }
        }
        return score;
    }
    private int st_score_two(){
        int score = 0;
        foreach(var die in dice_values)
        {
            if(die == 2)
            {
                score = score + 2;
            }
        }
        return score;
    }
    private int st_score_three(){
        //if(!available_choices["3"]) return 0;
        int score = 0;
        foreach(var die in dice_values)
        {
            if(die == 3)
            {
                score = score + 3;
            }
        }
        return score;
    }
    private int st_score_four(){
        //if(!available_choices["4"]) return 0;
        int score = 0;
        foreach(var die in dice_values)
        {
            if(die == 4)
            {
                score = score + 4;
            }
        }
        return score;
    }
    private int st_score_five(){
        //if(!available_choices["5"]) return 0;
        int score = 0;
        foreach(var die in dice_values)
        {
            if(die == 5)
            {
                score = score + 5;
            }
        }
        return score;
    }
    private int st_score_six(){
        //if(!available_choices["6"]) return 0;
        int score = 0;
        foreach(var die in dice_values)
        {
            if(die == 6)
            {
                score = score + 6;
            }
        }
        return score;
    }
    private int st_score_fhouse(){
        int[] counts = new int[7];
        foreach(int i in dice_values)
        {
            counts[i]++;
        }
        bool hasthree = false;
        bool hastwo = false;
        foreach(int i in counts)
        {
            if(i == 2) hastwo = true;
            else if(i == 3) hasthree = true;
        }
        if(hasthree && hastwo) 
        {
            return 25;
        }
        else return 0;
    }

    private int st_score_4kind(){
        /*
        if(!available_choices["4kind"])
        {
            bonus = 0;
            return 0;
        }
        available_choices["4kind"] = false;
        */
        int[] counts = new int[7];
        
        for(int i = 0; i < 5; i++) 
        {
            counts[dice_values[i]]++;
        }
        
        bool hasfour = false;
        int index = 0;
        foreach(int i in counts)
        {    
            if(i == 4){
                hasfour = true;
                break;
            }
            else {
                index++;
            }
        }
        if(hasfour) 
        {
            return index * 4;
        }
        else
        {
            return 0;
        }
    }
    private int st_score_smstr8(){
        //if(!available_choices["smstr8"]) return 0;
        int[] counts = new int[7];
        foreach(int i in dice_values)
        {
            counts[i]++;
        }
        bool hassmstr8 = false;
        if(counts[3] > 0 && counts[4] > 0 )
        {
            if(counts[1] > 0 && counts[2] > 0 ) hassmstr8 = true;
            else if(counts[2] > 0 && counts[5] > 0 ) hassmstr8 = true;
            else if(counts[5] > 0 && counts[6] > 0 ) hassmstr8 = true;
        }
        if(hassmstr8) 
        {
            return 30;
        }
        else return 0;
    }
    private int st_score_lgstr8(){
        //if(!available_choices["lgstr8"]) return 0;
        int[] counts = new int[7];
        foreach(int i in dice_values)
        {
            counts[i]++;
        }
        bool haslgstr8 = false;
        if(counts[3] > 0 && counts[4] > 0 && counts[5] > 0 && counts[2] > 0)
        {
            if(counts[1] > 0 || counts[6]>0){
                haslgstr8 = true;
            }
        }
        if(haslgstr8) 
        {
            return 40;
        }
        else return 0;
    }

    private int st_score_yacht(){
        //if(!available_choices["yacht"]) return 0;
        int[] counts = new int[7];
        foreach(int i in dice_values)
        {
            counts[i]++;
        }
        bool hasyacht = false;
        //int index = 0;
        foreach(int i in counts)
        {
            
            if(i == 5){
                hasyacht = true;
                break;
            } 


        }
        if(hasyacht) 
        {
            return 50;
        }
        else return 0;
    }
}
