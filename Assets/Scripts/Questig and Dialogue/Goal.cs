using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal {
    public Quest Quest;
    public string Description { get; set; }
    public bool Completed { get; set; }
    public int CurrentAmmount { get; set; }
    public int RequiredAmount { get; set; }

    public virtual void Init(){
        //default initialization
     
    }
    public void Evaluate(){
        if (CurrentAmmount >= RequiredAmount)
            Complete();
    }
    public void Complete()  {
        this.Quest.CheckGoals();
        Completed = true;
        Debug.Log("Goal marked as completed");
    }

}
