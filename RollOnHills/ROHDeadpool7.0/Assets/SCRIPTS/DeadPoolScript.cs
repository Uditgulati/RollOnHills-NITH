using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadPoolScript : MonoBehaviour {
	private Animator anim;
	private CharacterController controller;

	public float speed = 6.0f;
	public float turnSpeed = 60.0f;
	private Vector3 moveDirection = Vector3.zero;
	public float gravity = 20.0f;
	public Rigidbody r;
	public Transform cog;


	void Start () {
		controller = GetComponent <CharacterController>();
		anim = gameObject.GetComponentInChildren<Animator>();
		this.GetComponent<Rigidbody> ().centerOfMass = cog.localPosition;
	}

	void Update (){
		if (Input.GetKey ("up")) {
			anim.SetInteger ("AnimationPar", 1);
		}  else {
			anim.SetInteger ("AnimationPar", 0);
		}

		if(controller.isGrounded){
			moveDirection = transform.forward * Input.GetAxis("Vertical") * speed;
		}

		float turn = Input.GetAxis("Horizontal");
		transform.Rotate(0, turn * turnSpeed * Time.deltaTime, 0);
		controller.Move(moveDirection * Time.deltaTime);
		moveDirection.y -= gravity * Time.deltaTime;
	}
}
