using UnityEngine;
using System.Collections;

public class PlaneController : MonoBehaviour
{
	public float Thrust = 10f;
	public float liftStrength = 1f;
	public float rollRate = 1.0f;
	public float pitchRate = 1.0f;
	public float turnTorque = 1.0f;
	// Use this for initialization
	void Start ()
	{
	}

	private Vector3 lift;
	// Update is called once per frame
	void FixedUpdate ()
	{
		float angleOfAttack = -Mathf.Deg2Rad * Vector3.Dot (rigidbody.velocity, transform.up);
		Vector3 LiftVector = this.transform.up * angleOfAttack * liftStrength;
		Debug.DrawLine (this.transform.position, this.transform.position + LiftVector, Color.red);
		this.rigidbody.AddRelativeForce (Vector3.forward * Thrust);
		this.rigidbody.AddRelativeTorque (new Vector3 (Input.GetAxis ("Vertical") * pitchRate, 0, Input.GetAxis ("Horizontal") * -rollRate));
		rigidbody.AddForce (LiftVector, ForceMode.Force);
		
		// determine the local roll.
		float zRot = this.transform.localRotation.eulerAngles.z;
		float currentRoll = 180f - Mathf.Abs (180f - zRot);
		if (zRot <= 180f) {
			currentRoll *= -1;
		}
		this.rigidbody.AddTorque (new Vector3 (0, currentRoll * turnTorque, 0));
	}
}