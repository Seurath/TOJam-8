using UnityEngine;
using System.Collections;

public class SpacePlane : MonoBehaviour {
	
	public float speed = 2;
	private float currentZ;
	public float rotationMultiplicationFactor = 20f;
	private RazerHydraPlugin plugin;
	public int id = 0;
	public float rotationRate;
	public float pitchRotationRate;
	private float targetZ;
	public float yawRate = 10f;
	public float pitchRate = 10f;
	private float targetX;
	public float currentX;
	
	// Use this for initialization
	void Start () {
		plugin = new RazerHydraPlugin();
		targetZ = plugin.data.rotQuat.y;
		currentZ = targetZ;
		
		targetX = plugin.data.rotQuat.x;
		currentX = targetX;
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.Translate(Vector3.forward * Time.deltaTime * speed);
		plugin._sixenseGetNewestData(id);
	
	//rotation data		

	targetZ = plugin.data.rotQuat.y + plugin.data.rotQuat.z;
	currentZ = currentZ * rotationRate + (1 - rotationRate) * targetZ;
	
	targetX = plugin.data.rotQuat.x;
	currentX = currentX * pitchRotationRate + (1 - pitchRotationRate) * targetX;
		
	this.transform.RotateAroundLocal(Vector3.up, currentZ * Time.deltaTime * yawRate);
	//this.transform.RotateAround(Vector3.right,  * Time.deltaTime * pitchRate);	
		
	this.transform.localRotation = Quaternion.Euler(new Vector3((currentX  - 0.3f)* -rotationMultiplicationFactor,-currentZ * rotationMultiplicationFactor));
		
		
	}
}
