using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class HandGrab : MonoBehaviour {
	
	public List<Transform> itemsInReach = new List<Transform>();
	public List<Transform> heldItems = new List<Transform>();
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public void GrabItems()
	{
		foreach(Transform item in itemsInReach)
		{
			if(item.rigidbody != null)
			{
				FixedJoint joint = item.gameObject.AddComponent<FixedJoint>();
				if(joint != null)
				{
					joint.connectedBody = rigidbody;
					heldItems.Add (item);
				}
			}
		}
	}
	
	public void LetGoOfItems()
	{
		foreach(Transform item in heldItems)
		{
			FixedJoint joint = item.gameObject.GetComponent<FixedJoint>();
			if(joint != null)
			{
				Destroy(joint);
			}
		}
	}
	
	void OnTriggerEnter(Collider trigger)
	{
		if(trigger.CompareTag ("GrabTrigger"))
		{
			itemsInReach.Add (trigger.transform.parent);
			Debug.Log("ADDING");
		}
	}
	
	void OnTriggerExit(Collider trigger)
	{
		if(trigger.CompareTag("GrabTrigger"))
		{
			itemsInReach.Remove(trigger.transform.parent);
			Debug.Log ("REMOVING");
		}
	}
}
