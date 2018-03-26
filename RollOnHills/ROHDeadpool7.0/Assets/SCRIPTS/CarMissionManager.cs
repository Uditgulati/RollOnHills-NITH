using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CarMissionManager : MonoBehaviour {

	public int count =0;
	public Text text;
	public Text time;
	private float timetaken = 0f;
	// Use this for initialization
	void Start () {
		SceneManager.LoadSceneAsync ("HILLSNITH", LoadSceneMode.Additive);
	}
	
	// Update is called once per frame
	void Update () {
		timetaken += Time.deltaTime;
		text.text = "" + count;
		time.text = "" + timetaken;
		if (count > 4) {
			SceneManager.LoadSceneAsync ("Score");
		}
	}
}
