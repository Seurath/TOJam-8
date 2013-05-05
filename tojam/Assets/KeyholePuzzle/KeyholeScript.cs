using UnityEngine;
using System.Collections;

public class KeyholeScript : MonoBehaviour {
	public GameObject key;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnTriggerEnter(Collider other)
	{
		if(other.gameObject == key || other.gameObject.transform.parent == key)
		{
			Debug.Log ("Success!");
		}
	}
	
	void OnTriggerExit(Collider other)
	{
		Debug.Log ("SOMETHING EXITED: " + other.name);
		if(other.gameObject == key || other.gameObject.transform.parent == key)
		{
			Debug.Log ("Hey, where are you taking that?");
		}
	}
}
