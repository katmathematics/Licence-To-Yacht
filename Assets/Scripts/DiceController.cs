using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceController : MonoBehaviour
{
    private int DiceVal = 1;
    private int DiceID = 1;

    //private static readonly Random getrandom = new Random();
    
    // Start is called before the first frame update
    void Start()
    {
        //Random rnd = new Random();
        DiceVal = Random.Range(1,6);
        Debug.Log(DiceVal);
        Debug.Log(DiceID);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseDown(){
       
        Debug.Log(DiceVal);
    }

    
}
