using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boyscript : MonoBehaviour 
{
	public float speed;
	public float turnspeed;
	public float jump;
	public Transform COG;




	void Start ()
	{
		this.GetComponent<Rigidbody> ().centerOfMass = COG.localPosition;
	}


	void FixedUpdate()
	{
		if (Input.GetKey (KeyCode.UpArrow))
			transform.Translate (Vector3.forward * speed * Time.deltaTime);

		if (Input.GetKey (KeyCode.DownArrow))
			transform.Translate (Vector3.back * speed * Time.deltaTime);

		if (Input.GetKey (KeyCode.LeftArrow))
			transform.Rotate(Vector3.up*turnspeed);

		if (Input.GetKey (KeyCode.RightArrow))
			transform.Rotate(-Vector3.up*turnspeed);
		

	
		if (Input.GetKey (KeyCode.Space))
			this.GetComponent<Rigidbody> ().AddForce (Vector3.up * jump);
		
			
	}
}
