using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotate : MonoBehaviour {

	public GameObject obj;
	public GameObject temp;
	CarMissionManager script;


	void Start(){
		script = temp.GetComponent<CarMissionManager> ();
	}
	void Update () {
		transform.Rotate (new Vector3 (15, 30, 45) * Time.deltaTime);
	}
	void OnTriggerEnter(Collider other){
		if (other.CompareTag ("Player")) {
			Debug.Log ("aksh");
			script.count += 1;
			Destroy (obj);
		}
	}
}
