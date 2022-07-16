using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    public string unitName;

    public int damage;
    public int maxHP;
    public int currentHP;
    public int money;

    public bool TakeDamage(int dmg) {
        currentHP -= dmg;

        if (currentHP <= 0) {
            return true; //Return true if the unit died
        }
        else {
            return false;
        }
    }
}
