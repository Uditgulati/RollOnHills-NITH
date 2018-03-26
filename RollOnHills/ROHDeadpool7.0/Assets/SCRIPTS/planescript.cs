using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class planescript : MonoBehaviour
{

	public float A;
	public Rigidbody R;
	public float thrust;


	// Use this for initialization
	void Start () 
	{
		R = this.GetComponent<Rigidbody> ();
		SceneManager.LoadScene ("HILLSNITH", LoadSceneMode.Additive);


	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetKey (KeyCode.Z))
			thrust=thrust+0.1f;
		if (Input.GetKey (KeyCode.X))
			thrust=thrust-0.1f;

		//if (Input.GetKey (KeyCode.UpArrow))
		//	R.AddForce (Vector3.up*1000);

		//if (Input.GetKey (KeyCode.DownArrow))
		//	A-=2;

		if (Input.GetKey (KeyCode.LeftArrow)) 
		{
			
			this.transform.Rotate (Vector3.up, -1);
			this.transform.Rotate (this.transform.forward, -1);

		}

		if (Input.GetKey (KeyCode.RightArrow)) 
		{
			
			this.transform.Rotate (Vector3.up, 1);
			this.transform.Rotate (this.transform.forward, 1);

		}

		if (Input.GetKey (KeyCode.UpArrow)) 
		{
			this.transform.Rotate (Vector3.left, -1);

		}

		if (Input.GetKey (KeyCode.DownArrow)) 
		{
			this.transform.Rotate (Vector3.left, 1);

		}

	//	Debug.Log (A);

	//	this.transform.Rotate (Vector3.left, A);



	}

	void FixedUpdate()
	{
		

	/*	if (A > 0) 
		{
			while (A != 0) 
			{
				this.transform.Rotate (Vector3.left, -1);
				A=A-0.1f;
			}
		}

		if (A < 0) 
		{
			while (A != 0) 
			{
				this.transform.Rotate (Vector3.left, 1);
				A=A+0.1f;
			}
		}
		*/

		/*if (A > 0) 
		{
			this.transform.Rotate (Vector3.left,-10);
			A--;
			Debug.Log ("decreasing"+A);
		}

		if (A < 0) 
		{
			this.transform.Rotate (Vector3.left,10);
			A++;
			Debug.Log ("increasing"+A);
		}
		*/


		//R.AddForce (R.transform.forward * thrust);


		this.transform.Translate (Vector3.forward *thrust);
	}
}
