using UnityEngine;
using System.Collections;

public class HitSwitch : MonoBehaviour {
	public GameObject messageRecipient;
//	public string scriptType;
	public string switchHitMessage;
	
	public bool switchEnabled = true;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnTriggerEnter(Collider other)
	{
		if(switchEnabled && messageRecipient != null)
		{
			messageRecipient.BroadcastMessage(switchHitMessage);
		}
	}
	
	void OnTriggerExit(Collider other)
	{
		if(switchEnabled && messageRecipient != null)
		{
//			messageRecipient.BroadcastMessage(switchHitMessage);
		}
	}
	
	void EnableSwitch()
	{
		switchEnabled = true;
	}
	
	void DisableSwitch()
	{
		switchEnabled = false;
	}
}
