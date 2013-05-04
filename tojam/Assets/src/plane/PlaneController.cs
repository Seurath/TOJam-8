using UnityEngine;
using System.Collections;

public class PlaneController : MonoBehaviour
{
	public float Thrust = 10f;
	public float liftStrength = 1f;
	public float rollRate = 1.0f;
	public float pitchRate = 1.0f;
	public float turnTorque = 1.0f;
	public float yawRate = 10f;
	
	public float horizontalAxis;
	public float verticalAxis;
	public float yawAxis;
	
	public float leftY;
	public float rightY;
	
	
	public float pitchLowerLimit = -15f;
	public float pitchUpperLimit = 15f;
	public float rollLowerLimit;
	public float rollUpperLimit;
	
	// Use this for initialization
	void Start ()
	{
	}

	private Vector3 lift;
	// Update is called once per frame
	void FixedUpdate ()
	{
		horizontalAxis = SixenseInput.Controllers[0].Rotation.z;
		verticalAxis = SixenseInput.Controllers[0].Rotation.x;
		
		yawAxis = SixenseInput.Controllers[0].Rotation.y;
		
		
		
		leftY = SixenseInput.Controllers[0].Position.y;
		rightY = SixenseInput.Controllers[1].Position.y;
		
		
		float angleOfAttack = -Mathf.Deg2Rad * Vector3.Dot (rigidbody.velocity, transform.up);
		Vector3 LiftVector = this.transform.up * angleOfAttack * liftStrength;
		Debug.DrawLine (this.transform.position, this.transform.position + LiftVector, Color.red);
		this.rigidbody.AddRelativeForce (Vector3.forward * Thrust);
		this.rigidbody.AddRelativeTorque (new Vector3 (verticalAxis * pitchRate, yawAxis * yawRate, horizontalAxis * -rollRate));
		rigidbody.AddForce (LiftVector, ForceMode.Force);
		
		// determine the local roll.
		float zRot = this.transform.localRotation.eulerAngles.z;
		float currentRoll = 180f - Mathf.Abs (180f - zRot);
		if (zRot <= 180f) {
			currentRoll *= -1;
		}
		this.rigidbody.AddTorque (new Vector3 (0, currentRoll * turnTorque, 0));
		
		float xAngle = this.transform.localRotation.eulerAngles.x;
		if (xAngle > 180f)
		{
			xAngle -= 360f;	
		}
		
		/*if (xAngle > pitchUpperLimit)
		{
			this.transform.localRotation = Quaternion.Euler(new Vector3(pitchUpperLimit, this.transform.localRotation.y, this.transform.localRotation.z));
		}
		
		
		if (xAngle < pitchLowerLimit)
		{
			this.transform.localRotation = Quaternion.Euler(new Vector3(pitchLowerLimit, this.transform.localRotation.y, this.transform.localRotation.z));
		}*/
		
		// clamp rotations.
		//if (this.transform.rotation.z > pitchUpperLimit)
		//{
		//	this.transform.rotation = Quaternion.Euler(new Vector3(this.transform.rotation.x, this.transform.rotation.y, pitchUpperLimit));	
		//}
		
		//if (this.transform.rotation.z < pitchLowerLimit)
		////{
		//	this.transform.rotation = Quaternion.Euler(new Vector3(this.transform.rotation.x, this.transform.rotation.y, pitchLowerLimit));	
		//}
	}
}