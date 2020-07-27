using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System; 
using System.Text.RegularExpressions;

public class LOGIN : MonoBehaviour
{
	public GameObject username;
	private string Username;
   	private String[] Lines;
   	public GameObject Main_Menu;
   	public GameObject Login_Menu;
	public GameObject playbutton;
   	public void LoginButton() {
   		bool UN = false;
   		if (Username != "") {
   			if (System.IO.File.Exists(@"F:/Unity-files/" + Username + ".txt")) {
   				UN = true;
   				Lines = System.IO.File.ReadAllLines(@"F:/Unity-files/" + Username + ".txt" );
   			} else  {
   				Debug.LogWarning("Username Invalid!");
   			}
   		} else {
   			Debug.LogWarning("Username Field Empty");
   		}
   		if (UN == true) {
   			username.GetComponent<InputField>().text = "";
   			print("Login successful!");
   			//Application.LoadLevel("copymenu");
   			Main_Menu.SetActive(true);
   			Login_Menu.SetActive(false);
			playbutton.SetActive(true);
   		}

   }

    // Update is called once per frame
    void Update()
    {
    	if (Input.GetKeyDown(KeyCode.Return)) {
    		if (Username != "") {
    			LoginButton();    		
    		}
    	}
        Username = username.GetComponent<InputField>().text;
    
    }
}
