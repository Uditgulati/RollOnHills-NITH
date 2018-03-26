using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainuiscript : MonoBehaviour
{

	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}

	public void ChangeScene(string name)
	{
		SceneManager.LoadSceneAsync (name);
		
	}

	public void Quit()
	{
		Application.Quit ();
	}
}
