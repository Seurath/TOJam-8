using UnityEngine;
using System.Collections;

public class Drone : MonoBehaviour
{
	
	public GameObject target;
	public float rotationRate;
	public float speed;
	public float distanceCutoffNear;
	public float distanceCutoffFar;
	public GameObject[] bulletSpawns;
	public GameObject bullet;
	public float distance;
	// Use this for initialization
	void Start ()
	{
		target = GameObject.Find ("fighter");
	}
	
	private float timeUntilNextShot = 0.25f;
	private int currentBulletSpawn = 0;
	
	// Update is called once per frame
	void Update ()
	{
		
		timeUntilNextShot -= Time.deltaTime;
		if (distance < distanceCutoffFar) {
			if (timeUntilNextShot < 0f) {
				timeUntilNextShot = Random.Range (2f, 2.5f);
				GameObject.Instantiate (bullet, bulletSpawns [currentBulletSpawn].transform.position, bulletSpawns [currentBulletSpawn].transform.rotation);
				currentBulletSpawn ++;
				currentBulletSpawn = currentBulletSpawn % bulletSpawns.Length;
			}
		}
		
		if (target == null) {
			return;	
		}
		
		distance = Vector3.Distance (this.transform.position, target.transform.position);
	
		Vector3 targetDirection = this.target.transform.position - this.transform.position;
		Quaternion targetAngle = Quaternion.LookRotation (targetDirection);
		
		Quaternion resultDirection = Quaternion.RotateTowards (this.transform.rotation, targetAngle, Time.deltaTime * rotationRate);
		
		
		
		this.transform.rotation = resultDirection;
		
		
		if (distance > distanceCutoffNear && distance < distanceCutoffFar) {
			
				
			this.rigidbody.AddRelativeForce (Vector3.forward * speed * Time.deltaTime);
		}
		
		
	}
}
