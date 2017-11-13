using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DataInserter : MonoBehaviour {

	public string inputUserName;
	public string inputPassword;
	public string reinputPassword;
	public string inputEmail;

	public Text userNameTextBox;
	public Text passwordTextBox;
	public Text repasswordTextBox;
	public Text emailTextBox;
	public Text signupStatus;

	public Button[] buttons;

	public GameObject LoginWindow;
	public GameObject thisWindow;

	string CreateUserURL = "http://demonblaster.000webhostapp.com/InsertUser.php";

	void Start()
	{
		for (int i = 0; i < buttons.Length; i++)
		{
			int closureIndex = i; // Prevents the closure problem
			buttons[closureIndex].onClick.AddListener(() => TaskOnClick(closureIndex));
		}


	}


	void Update()
	{
		inputUserName = userNameTextBox.text.ToString();
		inputPassword = passwordTextBox.text.ToString();
		reinputPassword = repasswordTextBox.text.ToString();
		inputEmail = emailTextBox.text.ToString();

		Master.control.playerHealth = 10;
	}

	public void CreateUser(string username, string password, string email)
	{
		WWWForm form = new WWWForm();
		form.AddField("usernamePost", username);
		form.AddField("passwordPost", password);
		form.AddField("emailPost", email);
		WWW www = new WWW(CreateUserURL, form);
	}

	void TaskOnClick(int buttonIndex)
	{
		switch (buttonIndex)
		{
			case 0: //SIGNUP
				if (inputUserName == "" || inputPassword == "" || reinputPassword == "" || inputEmail == "")
				{
					signupStatus.text = "Please Complete";
				}
				else
				{
					if (inputPassword != reinputPassword)
					{
						signupStatus.text = "Passwords do not match";
					}
					else
					{
						CreateUser(inputUserName, inputPassword, inputEmail);
						signupStatus.text = "User Account Created";
					}
				}
				break;

			case 1: //GO BACK
				LoginWindow.gameObject.SetActive(true);
				thisWindow.gameObject.SetActive(false);
			break;
		}
	}
}
