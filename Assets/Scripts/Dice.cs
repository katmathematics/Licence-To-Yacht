using System.Collections;
using UnityEngine;

public class Dice : MonoBehaviour {

    private Sprite[] sides;
    private SpriteRenderer renderer;
    public bool active{get;set;} = true;



    private void Start(){
        renderer = GetComponent<SpriteRenderer>();
        string path = Application.dataPath;
        path+= "/Dice/";
        sides = Resources.LoadAll<Sprite>(path);
    }

    public void UpdateHelper(int value)
    {
        renderer.sprite = sides[value];
    }
    

}

