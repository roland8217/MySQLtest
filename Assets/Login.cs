using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Login : MonoBehaviour {

	public string inputUserName;
	public string inputPassword;

	public Text userNameTextBox;
	public Text passwordTextBox;

	public Button LoginGo;

	string LoginURL = "http://demonblaster.000webhostapp.com/Login.php";

	void Start ()
	{
		LoginGo.onClick.AddListener(TaskOnClick);
	}
	

	void Update ()
	{
		//if (Input.GetKeyDown(KeyCode.L)) StartCoroutine(LoginToDB(inputUserName, inputPassword));

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
		print(www.text);
	}

	void TaskOnClick()
	{
		StartCoroutine(LoginToDB(inputUserName, inputPassword));
		Debug.Log("You have clicked the button!");
	}
}
