using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    public string unitName; //Name of the unit the script represents

    public int damage; //The unit's attack damage 
    public int maxHP; //The unit's maximum hit points
    public int currentHP; //The unit's current hit points
    public int money; //The unit's current money

    //Function for taking damage
    public bool TakeDamage(int dmg) {
        currentHP -= dmg;

        if (currentHP <= 0) {
            return true; //Return true if the unit died
        }
        else {
            return false;
        }
    }

    public void AddMoney(int new_money) {
        money += new_money;
    }

    public void RemoveMoney(int lost_money) {
        money -= lost_money;
    }

    public void UpdateName(string new_name) {
        unitName = new_name;
    }

    public void UpdateMaxHP(int new_max_hp) {
        maxHP = new_max_hp;
    }
}
