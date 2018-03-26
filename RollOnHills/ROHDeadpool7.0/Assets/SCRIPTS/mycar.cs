using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[System.Serializable]
public struct Axle
{
	public WheelCollider LeftWheel;
	public WheelCollider RightWheel;
	public bool Motor;
	public bool steering;
}



public class mycar : MonoBehaviour 
{
	[SerializeField]
	public Axle[] axlelist;


	public float maxMotorTorque;
	public float maxSteeringAngle;

	public float breakspeed;

	public Rigidbody R;

	public float f;

	public Transform COG;

	public float AntiRoll;

	public speedometer SPD;

	public Vector3 visualWheelOffset=Vector3.zero;


	//-=-------------------------------------------------

	public void ControlCar()
	{
		float motor = maxMotorTorque * Input.GetAxis ("Vertical");

		float steer = maxSteeringAngle * Input.GetAxis ("Horizontal");
		//if(R.velocity.magnitude>

		SPD.S = (int)(R.velocity.magnitude);

		Debug.Log ("speed=" + R.velocity.magnitude + " torque= L=" + axlelist [0].LeftWheel.motorTorque + "  R =" + axlelist [0].RightWheel.motorTorque);

			for (int i = 0; i < axlelist.Length; i++) 
		{
				Axle A = axlelist [i];

				if (A.steering) {
					A.LeftWheel.steerAngle = steer;
					A.RightWheel.steerAngle = steer;
				}

			A.LeftWheel.brakeTorque = 0;
			A.RightWheel.brakeTorque = 0;


				if (A.Motor) {
					A.LeftWheel.motorTorque = motor;
					A.RightWheel.motorTorque = motor;

				if (A.LeftWheel.rpm > 1500)
					A.LeftWheel.motorTorque = 0;
				if (A.RightWheel.rpm > 1500)
					A.RightWheel.motorTorque = 0;


					

				}

				DoRollBar (A.LeftWheel, A.RightWheel);

				// left wheel graphic
				ApplyGraphictoWheel (A.LeftWheel); 
				//right wheel graphic
				ApplyGraphictoWheel (A.RightWheel); 


		}

		if (Input.GetKey(KeyCode.Space)) 
		{
			//brake 

			Break ();
			Debug.Log("break motortorque="+axlelist[0].LeftWheel.motorTorque);


		} 
	}

	private void Break()
	{
		for(int i=0;i<axlelist.Length;i++)
		{
			Axle A=axlelist[i];

			if(A.Motor)
			{
				A.LeftWheel.motorTorque = 0;
				A.RightWheel.motorTorque = 0;
			}

			A.LeftWheel.brakeTorque = breakspeed;
			A.RightWheel.brakeTorque = breakspeed;

			// left wheel graphic
			ApplyGraphictoWheel(A.LeftWheel);   
			//right wheel graphic
			ApplyGraphictoWheel(A.RightWheel);   
		}
	}

	void DoRollBar(WheelCollider WheelL, WheelCollider WheelR) {
		WheelHit hit;
		float travelL = 1.0f;
		float travelR = 1.0f;

		bool groundedL = WheelL.GetGroundHit(out hit);
		if (groundedL)
			travelL = (-WheelL.transform.InverseTransformPoint(hit.point).y - WheelL.radius) / WheelL.suspensionDistance;

		bool groundedR = WheelR.GetGroundHit(out hit);
		if (groundedR)
			travelR = (-WheelR.transform.InverseTransformPoint(hit.point).y - WheelR.radius) / WheelR.suspensionDistance;

		float antiRollForce = (travelL - travelR) * AntiRoll;

		if (groundedL)
			R.AddForceAtPosition(WheelL.transform.up * -antiRollForce,
				WheelL.transform.position); 
		if (groundedR)
			R.AddForceAtPosition(WheelR.transform.up * antiRollForce,
				WheelR.transform.position); 
	}



	private void ApplyGraphictoWheel(WheelCollider WC)
	{
		if(WC.transform.childCount==0)
			return;

		Transform VisW = WC.transform.GetChild (0);

		Vector3 pos;
		Quaternion rot;

		WC.GetWorldPose (out pos, out rot);

		rot.eulerAngles += visualWheelOffset;

		VisW.position=pos;
		VisW.rotation = rot;

	}

	//------------------------------------------------

	// Use this for initialization
	void Start () 
	{
		R.centerOfMass = COG.localPosition;
		//visualWheelOffset = axlelist [0].LeftWheel.transform.GetChild (0).eulerAngles;
	}

	// Update is called once per frame

	void FixedUpdate()
	{
		ControlCar ();
		//transform.Translate(visualWheelOffset * ((axlelist[0].LeftWheel.rpm)/100) * Time.deltaTime);


	}


	void Update () 
	{
		if (Input.GetKeyDown (KeyCode.LeftAlt))
			R.transform.up = Vector3.up;
	}

	public void FreezeStop()
	{
		axlelist [0].LeftWheel.brakeTorque = 100000000000;
		axlelist [0].RightWheel.brakeTorque= 10000000000;
		axlelist [1].LeftWheel.brakeTorque= 100000000000;
		axlelist [1].RightWheel.brakeTorque= 100000000000;


		//R.velocity = Vector3.zero;



	}

}
