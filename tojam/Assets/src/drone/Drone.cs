using UnityEngine;
using System.Collections;

public class Drone : MonoBehaviour {
	
	public GameObject target;
	public float rotationRate;
	public float speed;
	public float distanceCutoffNear;
	public float distanceCutoffFar;
	
	public float distance;
	// Use this for initialization
	void Start () {
		target = GameObject.Find("fighter");
	}
	
	// Update is called once per frame
	void Update () {
		
		
		
		 distance = Vector3.Distance(this.transform.position, target.transform.position);
	
		if (distance > distanceCutoffNear || distance < distanceCutoffFar )
		{
			
			Vector3 targetDirection =  this.target.transform.position - this.transform.position;
			Quaternion targetAngle = Quaternion.LookRotation(targetDirection);
		
			Quaternion resultDirection = Quaternion.RotateTowards(this.transform.rotation, targetAngle, Time.deltaTime * rotationRate);
		
		
		
			this.transform.rotation = resultDirection;
			
			//this.rigidbody.AddRelativeForce(Vector3.forward * speed * Time.deltaTime);
		}
		
		
	}
}
