using UnityEngine;
public class Dice
{
    public Dice(int num)
    {
        int[] dice_set =  new int[5];
        roll_all();
    }
    public int[] dice_set{get;}
    
    public void roll_selected_dice(int[] dice_to_roll)
    {
        foreach(int i in dice_to_roll)
        {
            
            dice_set[i] = Random.range(1, 7);
        }
    }
    public void roll_all()
    {
         
        roll_selected_dice(new int[5]{0,1,2,3,4});
    }
    public void add_die()
    {
        new_dice_set = new int[dice_set.Length+1];
        j = 0;
        foreach(int i in dice_set)
        {
            new_dice_set[j] = i;
        }
        new_dice_set[dice_set.Length+1] = 6;
        dice_set = new_dice_set;
    }
    public void sub_die(int unwanted)
    {
        new_dice_set = new int[dice_set.Length-1];
        int index = 0;
        int new_index = 0;
        foreach(int i in dice_set)
        {
            if(index!= unwanted)
            {
                new_dice_set[new_index] = i;
                new_index = new_index+1;
            }
            index+=1;
        }
        dice_set = new_dice_set;
    }



}
public class Yacht
{
    public Yacht()
    {
        dice = Dice(5);
        var choices = new Dictionary<string, bool>(){
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

    }

    public Dice dice{get;}
    public var available_choices;

    public int score_one(){
        if(!available_choices["1"]) return 0;
        score = 0;
        foreach(var die in dice)
        {
            if(die == 1)
            {
                score = score + 1;
            }
        }
        available_choices["1"] = False;
        return score;
    }
    public int score_two(){
        if(!available_choices["2"]) return 0;
        score = 0;
        foreach(var die in dice)
        {
            if(die == 2)
            {
                score = score + 2;
            }
        }
        available_choices["1"] = False;
        return score;
    }
    public int score_three(){
        if(!available_choices["3"]) return 0;
        score = 0;
        foreach(var die in dice)
        {
            if(die == 3)
            {
                score = score + 3;
            }
        }
        available_choices["3"] = False;
        return score;
    }
    public int score_four(){
        if(!available_choices["4"]) return 0;
        score = 0;
        foreach(var die in dice)
        {
            if(die == 4)
            {
                score = score + 4;
            }
        }
        available_choices["4"] = False;
        return score;
    }
    public int score_five(){
        if(!available_choices["5"]) return 0;
        score = 0;
        foreach(var die in dice)
        {
            if(die == 5)
            {
                score = score + 5;
            }
        }
        available_choices["5"] = False;
        return score;
    }
    public int score_six(){
        if(!available_choices["6"]) return 0;
        score = 0;
        foreach(var die in dice)
        {
            if(die == 6)
            {
                score = score + 6;
            }
        }
        available_choices["6"] = False;
        return score;
    }
    public int score_fhouse(){
        if(!available_choices["fhouse"]) return 0;
        available_choices["fhouse"] = false;
        int[] counts = new int[6];
        foreach(int i in dice)
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

    public int score_4kind(){
        if(!available_choices["4kind"]) return 0;
        available_choices["4kind"] = false;
        int[] counts = new int[6];
        foreach(int i in dice)
        {
            counts[i]++;
        }
        bool hasfour = false;
        index = 0;
        foreach(int i in counts)
        {
            
            if(i == 4){
                hasfour = true;
                break;
            } 


        }
        if(hasfour) 
        {
            return index * 4;
        }
        else return 0;
    }
    public int score_smstr8(){
        if(!available_choices["smstr8"]) return 0;
        available_choices["smstr8"] = false;
        int[] counts = new int[6];
        foreach(int i in dice)
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
        foreach(int i in dice)
        {
            counts[i]++;
        }
        bool hassmlgstr8 = false;
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
        foreach(int i in dice)
        {
            counts[i]++;
        }
        bool hasyacht = false;
        index = 0;
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