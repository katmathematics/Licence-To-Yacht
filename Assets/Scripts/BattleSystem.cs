using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum BattleState { START, PLAYERTURN, ENEMYTURN, WON, LOST}

public class BattleSystem : MonoBehaviour
{
    Unit yondUnit;
    Unit enemyUnit;

    public BattleState state;

    public GameObject yondPrefab;
    public GameObject enemyPrefab;

    public Transform yondStation;
    public Transform enemyStation;

    public BattleHUD yondHUD;
    public BattleHUD enemyHUD;

    // Start is called before the first frame update
    void Start()
    {
        state = BattleState.START;
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
        bool isDead = enemyUnit.TakeDamage(yondUnit.damage);

        enemyHUD.SetHP(enemyUnit.currentHP);

        if(isDead) {
            state = BattleState.WON;
            EndBattle();
        }
        else {
            state = BattleState.ENEMYTURN;
            EnemyTurn();
        }
    }

    void EnemyTurn() {
        bool isDead = yondUnit.TakeDamage(enemyUnit.damage);

        yondHUD.SetHP(yondUnit.currentHP);

        if(isDead) {
            state = BattleState.LOST;
            EndBattle();
        }
        else {
            state = BattleState.PLAYERTURN;
            PlayerTurn();
        }
    }

    void EndBattle() {
        if(state == BattleState.LOST) {

        }
        else {

        }
    }
}
