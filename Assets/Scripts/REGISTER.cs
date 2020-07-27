using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System; 
using System.Text.RegularExpressions;
public class REGISTER : MonoBehaviour
{
	public GameObject username;
	private string Username;
	private string form; //tine toate variabilele
	private bool usernamevalid = false;

	//public GameObject email;

    public void RegisterButton() {
    	bool UN = false;

    	if (Username != "") {
	    	if (!System.IO.File.Exists(@"F:/Unity-files/" + Username + ".txt"))
	    	{
	    		UN = true;
	    	}
	    	else {
	    		Debug.LogWarning("Username taken");
	    	}
	    } else {
	    	Debug.LogWarning("Username field empty");
	    }
    	print("Registration Successful!");

    	if (UN == true) {
    		bool Clear = true;
    		int i = 1;
    		form = (Username + "\n");
    		System.IO.File.WriteAllText(@"F:/Unity-files/" + Username + ".txt", form);
    		username.GetComponent<InputField>().text = "";
    		print("Registration Complete!");
    	}
    }
    // Update is called once per frame
    void Update()
    {
    	/*if (Input.GetKeyDown(KeyCode.Tab)) {
    		if (username.GetComponent<inputField>().isFocused) {

    		}

    	}*/
    	if (Input.GetKeyDown(KeyCode.Return)) {
    		if (Username != "") {
    			RegisterButton();    		
    		}
    	}
        Username = username.GetComponent<InputField>().text;
    }
}
