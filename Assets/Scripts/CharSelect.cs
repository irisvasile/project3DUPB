using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharSelect : MonoBehaviour
{
    private GameObject[] charList;
    private int charIdx = 0;

    private void Start()
    {
        charIdx = PlayerPrefs.GetInt("CharacterSelected");
        charList = new GameObject[transform.childCount];

        // Fill the array with your character models
        for (int i = 0; i < transform.childCount; i++)
        {
            charList[i] = transform.GetChild(i).gameObject;
        }

        // toggle render off for all character model
        foreach (GameObject obj in charList)
        {
            obj.SetActive(false);
        }

        //toggle render on for selected character
        if (charList[charIdx])
            charList[charIdx].SetActive(true);
    }

    public void Select(int idx)
    {
        if (idx == charIdx || idx < 0 || idx >= transform.childCount)
            return;
        charList[charIdx].SetActive(false);
        charIdx = idx;
        charList[charIdx].SetActive(true);
    }

    public void Confirm()
    {
        PlayerPrefs.SetInt("CharacterSelected", charIdx);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
