using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestGiver : NPC
{
    public bool AssignedQuest { get; set; }
    public bool Helped { get; set; }

    [SerializeField]
    private GameObject quests;

    private Quest Quest { get; set; }

    [SerializeField]
    private string questType;

    public override void Interact()
    {
        
        if(!AssignedQuest && !Helped)
        {
            base.Interact();
            AssignQuest();
        }
        else if(AssignedQuest && !Helped)
        {
            CheckQuest();
           
        }
        else
        {
            DialogueSystem.Instance.AddNewDialogue(new string[] { "I`ll be forever grateful" }, name);
        }
       
    }
    // Start is called before the first frame update
    void AssignQuest()
    {
        AssignedQuest = true;
        Quest = (Quest)quests.AddComponent(System.Type.GetType(questType));

    }
    void CheckQuest()
    {
        Debug.Log("quest is "+Quest.Completed);
        if(Quest.Completed)
        {
            Quest.GiveReward();
            Helped = true;
            AssignedQuest = false;
            DialogueSystem.Instance.AddNewDialogue(new string[] { "Thank you for that" }, name);
        }
        else
        {
            DialogueSystem.Instance.AddNewDialogue(new string[] { "Get on with it" }, name);
        }
    }
    
}
