using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enterexit : MonoBehaviour
{

	public GameObject CAR;
	public GameObject DEADPOOL;
	public GameObject Speedo;

	public Camera carcam;
	public Camera dpcam;

	private bool inCAR;

	mycar MCS;
	DeadPoolScript MDS;
	speedometer SPD;
	//Camera MCC;
	//Camera MBC;


	// Use this for initialization
	void Start ()
	{
		MCS = CAR.GetComponent<mycar> ();
		//MCC = CAR.GetComponent<Camera> ();
		MCS.enabled = false;

		SPD = Speedo.GetComponent<speedometer> ();
		Speedo.SetActive(false);

		SPD.enabled = false;
		//MCC.enabled = fa
		//CAR.GetComponent< CameraCar >().enabled=false;
		carcam.enabled=false;


		MDS = DEADPOOL.GetComponent<DeadPoolScript> ();
		//MBC = BOY.GetComponent<Camera> ();
		MDS.enabled = true;


		dpcam.enabled = true;
		//MBC.enabled = true;

		inCAR = false;
	}

	// Update is called once per frame

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player")
			Debug.Log ("player Enter");
	}

	void OnTriggerStay(Collider other)
	{
		if (other.tag == "Player" && inCAR == false) 
		{
			Debug.Log ("Press enter to drive");



			if ( Input.GetKey (KeyCode.M))
			{
				Debug.Log ("ready to drive");
				//BOYbackup.SetActive (true);
				DEADPOOL.transform.parent = CAR.transform;
				DEADPOOL.SetActive (false);
				MCS.enabled = true;

				Speedo.SetActive(true);
				SPD.enabled = true;
				carcam.enabled = true;
				MDS.enabled = false;
				dpcam.enabled = false;
				inCAR = true;
				//MCS. = 0;
				//MCS.driving = true;

				//CAR.GetComponent<Camera> ().enabled = true;
			}

		}


		/*
		if (other.tag == "Player" && inCAR == true )
		{
			Debug.Log ("driving -- press W to come out");
			if (Input.GetKey (KeyCode.W))
			{
				BOYbackup.SetActive (false);
				BOY.SetActive (true);
				BOY.transform.parent = null;
				MCS.enabled = false;
				MBS.enabled = true;
				inCAR = false;
			}
		}

       */


	}

	void OnTriggerExit(Collider other)
	{
		if (other.tag == "Player" && inCAR == false) 
		{
			Debug.Log ("moved back");
		}



	}


	void Update ()
	{
		if (inCAR == true && Input.GetKey (KeyCode.N))
		{

			DEADPOOL.transform.parent = null;
			DEADPOOL.SetActive (true);
			dpcam.enabled = true;
			//BOYbackup.SetActive (false);

			MCS.FreezeStop ();
			MCS.enabled = false;

			Speedo.SetActive(false);
			SPD.enabled = false;

			carcam.enabled = false;
			MDS.enabled = true;
			CAR.GetComponent<Rigidbody> ().velocity = Vector3.zero;


			//MCS.driving = false;
			inCAR = false;
		}
	}






}
