using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public enum BattleState { START, PLAYERTURN, YACHTPHASE, ENEMYTURN, WON, LOST}

public class BattleSystem : MonoBehaviour
{
    Unit yondUnit;
    Unit enemyUnit;

    public LevelLoader loader;

    public static BattleState state;

    public GameObject yondPrefab;
    public GameObject enemyPrefab;

    public Button rollButton;
    public Button attackButton;
    public Button advanceButton;

    public Button[] selectors;

    public AudioClip gunfire;

    public GameObject YachtInterface; 

    public Transform yondStation;
    public Transform enemyStation;

    public BattleHUD yondHUD;
    public BattleHUD enemyHUD;

    public YachtSteering Steering;

    public static bool gameWon = true;

    public static bool noActions = false;

    public static int currentSelection;

    private int damage;
    private int score;
    //private int money;
    public YachtLogic Logic;

    private int bonus_val = 0;
    private bool short_stun;
    private bool long_stun_turn_1;
    private bool long_stun_turn_2;
    

    private string attack;
    private string[] attacks = {"1","2","3","4","5","6","4_of_a_kind","short_straight","long_straight","full_house","yacht"};


    private int counter = 0;

    // Start is called before the first frame update
    void Start()
    {
        HideYacht();
        state = BattleState.START;
        //YachtInterface.SetActive(false);

        long_stun_turn_1 = false; // this needs to be set up here as unlike all the others we need to check it before setting it each turn

        SetupBattle();
    }

    void Update() // hardcoded only one die
    {  
        
    }

    public void ShowYacht() {
        YachtInterface.transform.localPosition = new Vector3(0, 0, 0);
        advanceButton.interactable = false;
    }

    public void HideYacht() {
        YachtInterface.transform.localPosition = new Vector3(0, 840, 0);
    }

    void SetupBattle() {
        GameObject yondGO = Instantiate(yondPrefab, yondStation);
        GameObject enemyGO = Instantiate(enemyPrefab, enemyStation);

        yondUnit = yondGO.GetComponent<Unit>();
        enemyUnit = enemyGO.GetComponent<Unit>();

        yondHUD.SetHUD(yondUnit);
        enemyHUD.SetHUD(enemyUnit);

        YachtSteering.rolls_left = 2;

        state = BattleState.PLAYERTURN;

        while(counter < 3) {
            selectors[counter].interactable = true;
            counter += 1;
        }

        PlayerTurn();
    }

    void PlayerTurn() {

    }


    public void onAttackButton() {

        //yacht_board.dice.roll_all();

        //Debug.Log(yacht_board.dice.dice_set[0].ToString());
        if (state != BattleState.PLAYERTURN) {
            return;
        }
        else {
            YachtSteering.rolls_left = 2;
            state = BattleState.YACHTPHASE;
            rollButton.interactable = true;
            attackButton.interactable = false;
            ShowYacht();

            //PlayerAttack();
            
        }
    }

    public void PlayerAttack() {

        attack = attacks[currentSelection];
        score = 0;
        damage = 0;
        //money = 0;
        short_stun = false;
        long_stun_turn_2 = false;

        if (long_stun_turn_1 == true) {
            long_stun_turn_1 = false;
            long_stun_turn_2 = true;
        }

        /*
            Outcomes:
            - A base score of 1-6: Direct damage
            - 4 of a kind: Bonus die
            - Small straight: 1 turn stun
            - Large straight: 2 turn stun
            - Full House: Steal money B)
            - Yacht: Hit by a yacht (1 turn stun + extra money)
        */

        HideYacht();

        if(string.Equals(attack,"1")) {
            score = Logic.score_one();
            damage = score + 1;
        }
        else if (string.Equals(attack,"2")) {
            score = Logic.score_two();
            damage = score + 2;
        }
        else if (string.Equals(attack,"3")) {
            score = Logic.score_three();
            damage = score + 3;
        }
        else if (string.Equals(attack,"4")) {
            score = Logic.score_four();
            damage = score + 4;
        }
        else if (string.Equals(attack,"5")) {
            score = Logic.score_five();
            damage = score + 5;
        }
        else if (string.Equals(attack,"6")) {
            score = Logic.score_six();
            damage = score + 6;
        }
        else if (string.Equals(attack,"4_of_a_kind")) {
            int bonus;
            score = Logic.score_4kind(out bonus);
            bonus_val = bonus;
            damage = score;
        }
        else if (string.Equals(attack,"short_straight")) {
            score = Logic.score_smstr8();
            damage = score;
            short_stun = true;
        }
        else if (string.Equals(attack,"long_straight")) {
            score = Logic.score_lgstr8();
            damage = score;
            long_stun_turn_1 = true;
        }
        else if (string.Equals(attack,"full_house")) {
            score = Logic.score_fhouse();
            damage = score;
        }
        else if (string.Equals(attack,"yacht")) {
            score = Logic.score_yacht();
            damage = score;
            short_stun = true;
        }
        if(bonus_val != 0)
        {
            damage = damage + bonus_val;
            bonus_val = 0;
        }

        bool isDead = enemyUnit.TakeDamage(damage);

        enemyHUD.SetHP(enemyUnit.currentHP);

        if(isDead) {
            state = BattleState.WON;
            gameWon = true;
            EndBattle();
        }

        if (noActions) {
            state = BattleState.LOST;
            gameWon = false;
            EndBattle();
        }

        else {
            if(short_stun || long_stun_turn_1 || long_stun_turn_2) {
                attackButton.interactable = true;
                PlayerTurn();
            }
            else {
                state = BattleState.ENEMYTURN;
                EnemyTurn();
            } 
        }
    }

    void EnemyTurn() {

        damage = 0;

        for (int i = 0; i < 6; i++) {
            damage += Random.Range(3,7);
        }
        

        bool isDead = yondUnit.TakeDamage(damage);

        yondHUD.SetHP(yondUnit.currentHP);

        if(isDead) {
            state = BattleState.LOST;
            gameWon = false;
            EndBattle();
        }
        else {
            state = BattleState.PLAYERTURN;
            attackButton.interactable = true;
            PlayerTurn();
        }
    }

    void EndBattle() {
        //loader.GetComponent<LevelLoader>().LoadNextLevel();
        loader.LoadNextLevel();
    }
}
