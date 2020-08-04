using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessageManager : MonoBehaviour
{
    public GameObject MessagePanel;
    // Start is called before the first frame update
    private void Awake()
    {
        MessagePanel.SetActive(false);
    }
    public void OpenMessagePanel ( string text)
    {
        Debug.Log("set active");
        MessagePanel.SetActive(true);
    }
    public void CloseMessagePanel()
    {
        MessagePanel.SetActive(false);
    }
}
