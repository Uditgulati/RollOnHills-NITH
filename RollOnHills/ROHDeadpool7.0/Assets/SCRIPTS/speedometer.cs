using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class speedometer : MonoBehaviour
{

	public Image needle;
	public Text SPEED;
	public int S;
	private int rot;


	// Use this for initialization
	void Start () 
	{


	}

	// Update is called once per frame
	void Update ()
	{

		rot = S * 2;

		SPEED.text = "Speed: " + (S*2).ToString("f0") + " km/h";


		needle.rectTransform.eulerAngles = new Vector3 (0, 0, 0);
		needle.rectTransform.eulerAngles = new Vector3 (0, 0, -rot);

	}
}
