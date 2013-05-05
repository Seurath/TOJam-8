using UnityEngine;
using System.Collections;

public class Drone : MonoBehaviour {
	
	public GameObject target;
	public float rotationRate;
	public float speed;
	
	
	// Use this for initialization
	void Start () {
		target = GameObject.Find("Airplane");
	}
	
	// Update is called once per frame
	void Update () {
		
		Vector3 targetDirection =  this.target.transform.position - this.transform.position;
		Quaternion targetAngle = Quaternion.LookRotation(targetDirection);
		
		Quaternion resultDirection = Quaternion.RotateTowards(this.transform.rotation, targetAngle, Time.deltaTime * rotationRate);
		this.transform.rotation = resultDirection;
		this.rigidbody.AddRelativeForce(Vector3.forward * speed * Time.deltaTime);
	}
}
