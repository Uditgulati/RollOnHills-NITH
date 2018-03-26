using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class score : MonoBehaviour {

	public Text result;
	bombgamescript script;
	public GameObject[] array;
	// Use this for initialization
	void Start () {
		array = SceneManager.GetSceneByName("BombMission").GetRootGameObjects();
		if (array.Length > 0) {
			GameObject temp;
			for (int i = 0; i < array.Length; i++) {
				temp = array [i];
				if (temp.GetComponent<bombgamescript> () != null) {
					script = temp.GetComponent<bombgamescript> ();
					break;
				}
			}

		}
	}
	
	// Update is called once per frame
	void Update () {
		result.text = "" + script.score;
	}
}
