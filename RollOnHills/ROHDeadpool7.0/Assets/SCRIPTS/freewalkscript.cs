using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class freewalkscript : MonoBehaviour 
{
	void Start () 
	{
		SceneManager.LoadScene ("HILLSNITH",LoadSceneMode.Additive);
	}
	

	void Update () 
	{
	 /*	if (Input.GetKey (KeyCode.Escape)) 
		{  
			
			SceneManager.LoadScene ("mainUI");
			SceneManager.UnloadScene ("HILLS");
		}
		*/

	}
}
