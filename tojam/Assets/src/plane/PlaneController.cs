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
	
	public float reorientRate = 10f;
	
	public float horizontalAxis;
	public float verticalAxis;
	public float yawAxis;
	
	public float leftY;
	public float rightY;
	
	
	public float pitchLowerLimit = -15f;
	public float pitchUpperLimit = 15f;
	public float rollLowerLimit;
	public float rollUpperLimit;
	
	public GameObject bulletPrefab;
	public GameObject bulletSpawn;
	public float timeSinceLastSpawn = 1f;
	
	// Use this for initialization
	void Start ()
	{
		SixenseInput.ControllerManagerEnabled = false;
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
		
		timeSinceLastSpawn += Time.deltaTime;
		
		Quaternion level = Quaternion.Euler(new Vector3(this.transform.localRotation.eulerAngles.x,this.transform.localRotation.eulerAngles.y , 0));
		this.transform.localRotation = Quaternion.RotateTowards(this.transform.localRotation, level, reorientRate * Time.deltaTime);			
		
		if (SixenseInput.Controllers[0].GetButton(SixenseButtons.TRIGGER) && timeSinceLastSpawn > 1f)
		{
			timeSinceLastSpawn = 0f;
			GameObject bullet = GameObject.Instantiate(bulletPrefab, bulletSpawn.transform.position, bulletSpawn.transform.rotation) as GameObject;

		}
		
		
		
	}
}