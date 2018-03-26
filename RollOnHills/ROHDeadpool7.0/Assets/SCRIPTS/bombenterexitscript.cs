using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class bombenterexitscript : MonoBehaviour
{
	public float timeleft = 10;
	public Text text;
	public GameObject temp;
	public GameObject self;
	public GameObject main;
	bombenterexitscript script;
	bombgamescript bgs;

	void Start () 
	{
		script = temp.GetComponent<bombenterexitscript> ();
		self.GetComponent<Light> ().enabled = true;
		bgs = main.GetComponent<bombgamescript> ();
	}
	

	void Update () 
	{
		timeleft -= Time.deltaTime;
		text.text = ""+timeleft;
		if (timeleft < 0) {
			SceneManager.LoadSceneAsync ("Gameover");
		}
	}

	void OnTriggerStay(Collider other){
		if (other.CompareTag ("Player")) {
			if (Input.GetKey (KeyCode.T)) {
				bgs.score += (int)(timeleft);
				bgs.count -= 1;
				if (bgs.count == 0) {
					SceneManager.LoadScene ("Score");
				} 
				else {
					script.enabled = true;
					self.SetActive (false);
				}
			}
		}
	}
}
