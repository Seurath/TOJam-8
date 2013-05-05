using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour {
	private RazerHydraPlugin plugin = null;
	
	public bool useHydra = true;
	
	public int id;
	public PunchPlayer player;
	
	public float zOffset;
	public float yOffset;
	
	private bool triggerDown = false;
	
	public Vector2 leftStick;
	public Vector2 rightStick;
	
	/////////////////////////////////////////////////////////////////////////////////////////////////////////////////
	
	void Start(){
		if(useHydra)
		{
			plugin = new RazerHydraPlugin();
		}
		else
		{
			zOffset = 1.0f;
		}
		
		if(player == null)
		{
			Debug.LogError ("Hand needs a PunchPlayer");
		}
	}
	
	void Update () {
		// For use with hydra controller
		if(useHydra)
		{
			//get latest data from tracker
			plugin._sixenseGetNewestData(id);
		
			//tracker data=======================================================================================	
		
			//position data
			transform.localPosition = new Vector3(
												plugin.data.pos.x * .005f,
												(plugin.data.pos.y * .005f) + yOffset,
												(plugin.data.pos.z * -.005f) + zOffset);
			//rotation data
			transform.localRotation = new Quaternion(
												plugin.data.rotQuat.x *-1,
												plugin.data.rotQuat.y *-1,
												plugin.data.rotQuat.z,
												plugin.data.rotQuat.w);
			
			if(plugin.data.trigger >= 254 && !triggerDown){
				triggerDown = true;
				
				// Allow the user to set the base position by pressing the trigger
				zOffset = plugin.data.pos.z * .005f;
			}
			else if(triggerDown && plugin.data.trigger < 10){
				triggerDown = false;
			}
			
			// Send analog stick values to the player, for movement purposes
			if(id == 0) {
				leftStick = new Vector2((plugin.data.joystick_x - 127) / 127.0f, (plugin.data.joystick_y - 127) / 127.0f);
			}
			else if(id == 1) {
				rightStick = new Vector2((plugin.data.joystick_x - 127) / 127.0f, (plugin.data.joystick_y - 127) / 127.0f);
			}
		}
		else // For use with an xbox controller
		{
			float triggerValue = Input.GetAxis ("Triggers");

			if(id == 0)
			{
				if(triggerValue > 0.8f)
				{
					leftStick = new Vector2();
					transform.localPosition = new Vector3(
												(Mathf.Clamp (Input.GetAxis ("HorizontalL"), -0.75f, 0.75f) - 0.25f) * 2.0f,
												Mathf.Clamp (Input.GetAxis ("VerticalR"), -0.75f, 0.75f) * -2.0f,
												Mathf.Clamp (Input.GetAxis ("VerticalL"), -0.75f, 0.75f) + 0.25f) +
											  new Vector3(0.0f, 0.0f, zOffset);
				}
				else
				{
					leftStick = new Vector2(Input.GetAxis ("HorizontalL"), Input.GetAxis ("VerticalL"));
				}
			}
			else if(id == 1)
			{
				if(triggerValue < -0.8f)
				{
					rightStick = new Vector2();
					transform.localPosition = new Vector3(
												(Mathf.Clamp (Input.GetAxis ("HorizontalL"), -0.75f, 0.75f) + 0.25f) * 2.0f,
												Mathf.Clamp (Input.GetAxis ("VerticalR"), -0.75f, 0.75f) * -2.0f,
												Mathf.Clamp (Input.GetAxis ("VerticalL"), -0.75f, 0.75f) + 0.25f) +
											  new Vector3(0.0f, 0.0f, zOffset);
				}
				else
				{
					rightStick = new Vector2(Input.GetAxis ("HorizontalR"), Input.GetAxis("VerticalR"));
				}
			}
		}
		
		if(id == 0)
		{
			player.joystickLeft = leftStick;
		}
		else if(id == 1)
		{
			player.joystickRight = rightStick;
		}
	}
}

////////////////////////////////////////////////////////////////////////////////////////////////////////////