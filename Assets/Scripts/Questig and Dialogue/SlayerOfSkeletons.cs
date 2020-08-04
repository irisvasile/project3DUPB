using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlayerOfSkeletons : Quest
{
    // Start is called before the first frame update
    void Start()
    {
        QuestName = "Slayer of skeletons";
        Description = "Get rid of those nasty creatures";
        //ItemReward= 
        //Aici va fi setat itemul oferit drept reward 
        GoldReward = 15;

         
        Goals.Add(new KillGoal(this,1, "Kill 15 skeletons", true, 0, 1));

        Goals.ForEach(g => g.Init());
    }

    
    
}
