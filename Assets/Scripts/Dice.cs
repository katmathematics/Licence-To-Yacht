using System.Collections;
using UnityEngine;

public class Dice : MonoBehaviour {

    private Sprite[] sides;
    private SpriteRenderer rend;
    public bool active{get;set;} = true;



    private void Start(){
        rend = GetComponentInChildren<SpriteRenderer>();
        sides = Resources.LoadAll<Sprite>("DiceSides/");
    }

    public void UpdateHelper(int value)
    {
        
        rend.sprite = sides[value];
    }
    

}

