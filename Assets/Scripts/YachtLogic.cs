using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YachtLogic : MonoBehaviour
{
    public YachtSteering dice;
    public Dictionary<string, bool> available_choices= new Dictionary<string, bool>(){
            {"1", false},
            {"2",false},
            {"3",false},
            {"4",false},
            {"5",false},
            {"6",false},
            {"fhouse",false},
            {"4kind",false},
            {"smstr8",false},
            {"lgstr8",false},
            {"yacht",false},
        };

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int score_one(){
        if(!available_choices["1"]) return 0;
        int score = 0;
        foreach(var die in dice.dice_values)
        {
            if(die == 1)
            {
                score = score + 1;
            }
        }
        available_choices["1"] = false;
        return score;
    }
    public int score_two(){
        if(!available_choices["2"]) return 0;
        int score = 0;
        foreach(var die in dice.dice_values)
        {
            if(die == 2)
            {
                score = score + 2;
            }
        }
        available_choices["1"] = false;
        return score;
    }
    public int score_three(){
        if(!available_choices["3"]) return 0;
        int score = 0;
        foreach(var die in dice.dice_values)
        {
            if(die == 3)
            {
                score = score + 3;
            }
        }
        available_choices["3"] = false;
        return score;
    }
    public int score_four(){
        if(!available_choices["4"]) return 0;
        int score = 0;
        foreach(var die in dice.dice_values)
        {
            if(die == 4)
            {
                score = score + 4;
            }
        }
        available_choices["4"] = false;
        return score;
    }
    public int score_five(){
        if(!available_choices["5"]) return 0;
        int score = 0;
        foreach(var die in dice.dice_values)
        {
            if(die == 5)
            {
                score = score + 5;
            }
        }
        available_choices["5"] = false;
        return score;
    }
    public int score_six(){
        if(!available_choices["6"]) return 0;
        int score = 0;
        foreach(var die in dice.dice_values)
        {
            if(die == 6)
            {
                score = score + 6;
            }
        }
        available_choices["6"] = false;
        return score;
    }
    public int score_fhouse(){
        if(!available_choices["fhouse"]) return 0;
        available_choices["fhouse"] = false;
        int[] counts = new int[6];
        foreach(int i in dice.dice_values)
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

    public int score_4kind(out int bonus){
        if(!available_choices["4kind"])
        {
            bonus = 0;
            return 0;
        }
        available_choices["4kind"] = false;
        int[] counts = new int[6];
        foreach(int i in dice.dice_values)
        {
            counts[i]++;
        }
        bool hasfour = false;
        int index = 0;
        foreach(int i in counts)
        {
            
            if(i == 4){
                hasfour = true;
                break;
            } 


        }
        if(hasfour) 
        {
            bonus = index;
            return index * 4;
        }
        
        else
        {
            bonus = 0;
            return 0;
        }
    }
    public int score_smstr8(){
        if(!available_choices["smstr8"]) return 0;
        available_choices["smstr8"] = false;
        int[] counts = new int[6];
        foreach(int i in dice.dice_values)
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
    public int score_lgstr8(){
        if(!available_choices["lgstr8"]) return 0;
        available_choices["lgstr8"] = false;
        int[] counts = new int[6];
        foreach(int i in dice.dice_values)
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

    public int score_yacht(){
        if(!available_choices["yacht"]) return 0;
        available_choices["yacht"] = false;
        int[] counts = new int[6];
        foreach(int i in dice.dice_values)
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
