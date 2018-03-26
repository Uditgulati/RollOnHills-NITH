using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class planeenterexitscript : MonoBehaviour
{

	public GameObject PLANE;
	public GameObject DEADPOOL;
	public GameObject Alto;

	public Camera planecam;
	public Camera dpcam;

	private bool inPLANE;

	planescript MPS;
	DeadPoolScript MDS;  

	altimeter ALTM;
	//Camera MCC;
	//Camera MBC;


	// Use this for initialization
	void Start ()
	{
		MPS = PLANE.GetComponent<planescript> ();
		//MCC = CAR.GetComponent<Camera> ();
		MPS.enabled = false;

		ALTM = Alto.GetComponent<altimeter> ();
		Alto.SetActive(false);

		ALTM.enabled = false;
		//MCC.enabled = fa
		//CAR.GetComponent< CameraCar >().enabled=false;
		planecam.enabled=false;


		MDS = DEADPOOL.GetComponent<DeadPoolScript> ();
		//MBC = BOY.GetComponent<Camera> ();
		MDS.enabled = true;


		dpcam.enabled = true;
		//MBC.enabled = true;

		inPLANE = false;
	}

	// Update is called once per frame

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player")
			Debug.Log ("player Enter");
	}

	void OnTriggerStay(Collider other)
	{
		if (other.tag == "Player" && inPLANE == false) 
		{
			Debug.Log ("Press enter to fly");



			if ( Input.GetKey (KeyCode.M))
			{
				Debug.Log ("ready to drive");
				//BOYbackup.SetActive (true);
				DEADPOOL.transform.parent = PLANE.transform;
				DEADPOOL.SetActive (false);
				MPS.enabled = true;

				Alto.SetActive(true);
				ALTM.enabled = true;
				planecam.enabled = true;
				MDS.enabled = false;
				dpcam.enabled = false;
				inPLANE = true;
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
				MDS.enabled = true;
				inCAR = false;
			}
		}

       */


	}

	void OnTriggerExit(Collider other)
	{
		if (other.tag == "Player" && inPLANE == false) 
		{
			Debug.Log ("moved back");
		}



	}


	void Update ()
	{
		if (inPLANE == true && Input.GetKey (KeyCode.N))
		{

			DEADPOOL.transform.parent = null;
			DEADPOOL.SetActive (true);
			dpcam.enabled = true;
			//BOYbackup.SetActive (false);

			//MPS.FreezeStop ();
			MPS.enabled = false;

			Alto.SetActive(false);
			ALTM.enabled = false;

			planecam.enabled = false;
			MDS.enabled = true;
			PLANE.GetComponent<Rigidbody> ().velocity = Vector3.zero;


			//MCS.driving = false;
			inPLANE = false;
		}
	}





}
