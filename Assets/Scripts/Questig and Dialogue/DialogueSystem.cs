using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using UnityEditor;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Net;

public class DialogueSystem : MonoBehaviour
{
    public static DialogueSystem Instance { get; set; }
    public List<string> dialogueLines = new List<string>();
    public GameObject MessagePanel;
    //Variabile pentru panels 
    public GameObject DialoguePanel;
    // public GameObject buttonsPanel;
    // Variabile pentru text
    private TMP_Text nameText;
    private TMP_Text dialogueLine;
    private Button nextPage;
    // private Button Accept;
    //  private Button Decline;

    private int dialogueIndex;

    // Initialization
    void Awake()
    {

        nextPage = DialoguePanel.transform.Find("Continue").GetComponent<Button>();
        dialogueLine = DialoguePanel.transform.Find("Text").GetChild(0).GetComponent<TMP_Text>();
        nameText = DialoguePanel.transform.Find("Name").GetChild(0).GetComponent<TMP_Text>();
        //buttonsPanel.SetActive(false);

        nextPage.onClick.AddListener(delegate { ContinueDialogue(); });
        DialoguePanel.SetActive(false);
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    public void AddNewDialogue(string[] lines, string name)
    {
        dialogueIndex = 0;
        dialogueLines = new List<string>();
        this.name = name;
        foreach (string line in lines)
        {
            dialogueLines.Add(line);
        }
        Debug.Log(dialogueLines.Count);
        CreateDialogue();
    }

    public void CreateDialogue()
    {
        dialogueLine.text = dialogueLines[dialogueIndex];
        nameText.text = name;
        DialoguePanel.SetActive(true);
    }
    public void ContinueDialogue()
    {

        if (dialogueIndex < dialogueLines.Count - 1)
        {
            dialogueIndex++;
            dialogueLine.text = dialogueLines[dialogueIndex];
        }
        else
        {
            // buttonsPanel.SetActive(true);
            DialoguePanel.SetActive(false);

        }
    }
}
  
