using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Quest : MonoBehaviour
{
    public List<Goal> Goals { get; set; } = new List<Goal>();
    public string QuestName { get; set; }
    public string Description { get; set; }
    public int GoldReward { get; set; }
    
    public Item ItemReward{get;set;}

    public bool Completed { get; set; }

    /**
     * <summary>Checks if the goals are completed.</summary>
     */
    public void CheckGoals()
    {
        Completed = Goals.All(g => g.Completed);
        
    }
    /**
     * <summary>Gives an item as a reward.</summary>
     */
    public void GiveReward()
    {
        Debug.Log("Give reward");
        foreach (Hero h in FindObjectsOfType<Hero>())
        {
            h.inventory.AddGold(GoldReward);
        }
        if (ItemReward != null)
        {
            foreach (Hero h in FindObjectsOfType<Hero>())
            {
                h.inventory.AddItem(ItemReward);
            }
        }
        
    }
       
}
