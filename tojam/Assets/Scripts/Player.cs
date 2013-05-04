using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player : MonoBehaviour {
	public Vector2 joystickLeft;
	public Vector2 joystickRight;
	
	public float moveSpeed = 4.0f;
	public float backwardsMultiplier = 0.5f;
	public float strafeMultiplier = 0.75f;
	
	private CharacterController cc;

	// Use this for initialization
	void Start () {
		cc = (CharacterController)GetComponent (typeof(CharacterController));
	}
	
	
	
	// Update is called once per frame
	void Update () {
		// Handle movement
		float xMovement = joystickLeft.x;
		xMovement *= moveSpeed * strafeMultiplier;
		
		float zMovement = joystickLeft.y;
		zMovement *= moveSpeed;
		if(zMovement < 0)
		{
			zMovement *= backwardsMultiplier;
		}
		
		Vector3 localMovementSpeed = new Vector3(xMovement, 0.0f, zMovement);
		cc.SimpleMove(transform.TransformDirection(localMovementSpeed));
	}
	
	/*
	//WALKING	
	//walk forward------------------------------------------------------------------------------------------------
	if(joystickLeftY > 127){
		transform.Translate(Vector3.forward * Time.deltaTime * (speed + ((joystickLeftY - 127) * speedAdjust)));
	}

	//walk backward------------------------------------------------------------------------------------------------
	if(joystickLeftY < 127){
		transform.Translate(Vector3.forward * Time.deltaTime * (-speed + ((joystickLeftY  -127) * speedAdjust) * 1));
	}

	//strafe right------------------------------------------------------------------------------------------------	
	if(joystickLeftX > 127 && speed != 10){
		transform.Translate(Vector3.right * Time.deltaTime * (speed + ((joystickLeftX - 127) * speedAdjust)));
	}

	//strafe left------------------------------------------------------------------------------------------------	
	if(joystickLeftX < 127 && speed != 10){
		transform.Translate(Vector3.right * Time.deltaTime * (-speed + ((joystickLeftX  -127) * speedAdjust) * 1));
	}


	//TURNING
	if(joystickRightX > 127){
		transform.RotateAround(transform.position, Vector3.up, (turnSpeed + ((joystickRightX - 127) * turnSpeedAdjust)));
	}
	
	if(joystickRightX < 127){
		transform.RotateAround(transform.position, Vector3.up * -1, (turnSpeed + ((127 - joystickRightX ) * turnSpeedAdjust)));
	}
	*/
	
}