using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum BattleState { START, PLAYERTURN, ENEMYTURN, WON, LOST}

public class BattleSystem : MonoBehaviour
{
    Unit yondUnit;
    Unit enemyUnit;

    public LevelLoader loader;

    public BattleState state;

    public GameObject yondPrefab;
    public GameObject enemyPrefab;

    public Transform yondStation;
    public Transform enemyStation;

    public BattleHUD yondHUD;
    public BattleHUD enemyHUD;

    public static bool gameWon = true;

    private int damage;
    private int score;
    //private int money;

    private bool short_stun;
    private bool long_stun_turn_1;
    private bool long_stun_turn_2;

    private string attack;

    // Start is called before the first frame update
    void Start()
    {
        state = BattleState.START;

        long_stun_turn_1 = false; // this needs to be set up here as unlike all the others we need to check it before setting it each turn

        SetupBattle();
    }

    void SetupBattle() {
        GameObject yondGO = Instantiate(yondPrefab, yondStation);
        GameObject enemyGO = Instantiate(enemyPrefab, enemyStation);

        yondUnit = yondGO.GetComponent<Unit>();
        enemyUnit = enemyGO.GetComponent<Unit>();

        yondHUD.SetHUD(yondUnit);
        enemyHUD.SetHUD(enemyUnit);

        state = BattleState.PLAYERTURN;
        PlayerTurn();
    }

    void PlayerTurn() {
        
    }

    public void onAttackButton() {
        if (state != BattleState.PLAYERTURN) {
            return;
        }
        else {
            PlayerAttack();
        }
    }

    void PlayerAttack() {

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

        attack = "5";
        score = 35;

        if(string.Equals(attack,"1")) {
            damage = score + 1;
        }
        else if (string.Equals(attack,"2")) {
            damage = score + 2;
        }
        else if (string.Equals(attack,"3")) {
            damage = score + 3;
        }
        else if (string.Equals(attack,"4")) {
            damage = score + 4;
        }
        else if (string.Equals(attack,"5")) {
            damage = score + 5;
        }
        else if (string.Equals(attack,"6")) {
            damage = score + 6;
        }
        else if (string.Equals(attack,"4_of_a_kind")) {
            damage = score;
        }
        else if (string.Equals(attack,"short_straight")) {
            damage = score;
            short_stun = true;
        }
        else if (string.Equals(attack,"long_straight")) {
            damage = score;
            long_stun_turn_1 = true;
        }
        else if (string.Equals(attack,"full_house")) {
            damage = score;
        }
        else if (string.Equals(attack,"yacht")) {
            damage = score;
            short_stun = true;
        }
        else if (string.Equals(attack,"whiff")) {
            damage = 0;
        }
        

        bool isDead = enemyUnit.TakeDamage(damage);

        enemyHUD.SetHP(enemyUnit.currentHP);

        if(isDead) {
            state = BattleState.WON;
            gameWon = true;
            EndBattle();
        }
        else {
            if(short_stun || long_stun_turn_1 || long_stun_turn_2) {
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
            damage += Random.Range(1,7);
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
            PlayerTurn();
        }
    }

    void EndBattle() {
        //loader.GetComponent<LevelLoader>().LoadNextLevel();
        loader.LoadNextLevel();
    }
}
