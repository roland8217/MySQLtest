using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Master : MonoBehaviour {

	public static Master control;
	public string playerName;
	public float playerHealth;
	public float playerScore;

	void Awake ()
	{
		if (control == null)
		{
			DontDestroyOnLoad(gameObject);
			control = this;
		}
		else
		{
			if (control != this)
			{
				Destroy(gameObject);
			}
		}
	}
}
