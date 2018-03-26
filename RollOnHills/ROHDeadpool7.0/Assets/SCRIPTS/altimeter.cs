using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class altimeter : MonoBehaviour 
{
	public Text ALT;
	public Text SPEED;

	public float alt;
	public float speed;

	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		SPEED.text = (speed*2).ToString("f0") + " km/h";
	    ALT.text = (alt*2).ToString("f0") + " m";
	}
}
