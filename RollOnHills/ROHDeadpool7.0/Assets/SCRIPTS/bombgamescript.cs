using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class bombgamescript : MonoBehaviour 
{

	public int count=10;
	public Text bombleft;
	public int score = 0;
	// Use this for initialization
	void Start () 
	{
		SceneManager.LoadScene ("HILLSNITH", LoadSceneMode.Additive);
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (count < 0)
			count = 0;
		bombleft.text = ""+count;
	}
}
