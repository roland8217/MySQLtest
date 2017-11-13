using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Login : MonoBehaviour {

	public string inputUserName;
	public string inputPassword;

	public Text userNameTextBox;
	public Text passwordTextBox;
	public Text loginStatus;

	public Button[] buttons;

	public GameObject SignUpWindow;
	public GameObject thisWindow;

	string LoginURL = "http://demonblaster.000webhostapp.com/Login.php";

	void Start ()
	{
		for (int i = 0; i < buttons.Length; i++)
		{
			int closureIndex = i; // Prevents the closure problem
			buttons[closureIndex].onClick.AddListener(() => TaskOnClick(closureIndex));
		}
	}
	

	void Update ()
	{
		inputUserName = userNameTextBox.text.ToString();
		inputPassword = passwordTextBox.text.ToString();
	}

	IEnumerator LoginToDB(string username, string password)
	{
		WWWForm form = new WWWForm();
		form.AddField("usernamePost", username);
		form.AddField("passwordPost", password);

		WWW www = new WWW(LoginURL, form);
		yield return www;
		if (www != null)
		{
			loginStatus.text = www.text.ToString();
			StartCoroutine(GetUserID());
		}
		else
		{
			loginStatus.text = "user not found";
		}
		print(www.text);
	}

	void TaskOnClick(int buttonIndex)
	{
		switch (buttonIndex)
		{
			case 0: //LOGIN
			StartCoroutine(LoginToDB(inputUserName, inputPassword));
			break;

			case 1://SIGNUP
			SignUpWindow.gameObject.SetActive(true);
			thisWindow.gameObject.SetActive(false);
			break;
		}
	}

	IEnumerator GetUserID()
	{
		WWWForm idform = new WWWForm();
		idform.AddField("usernamePost", inputUserName);

		WWW myID = new WWW("http://demonblaster.000webhostapp.com/GetUserID.php",idform);
		yield return myID;
		string myIDString = myID.text;
		print("ID: "+myIDString);
	}
}
