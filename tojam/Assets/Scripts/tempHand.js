
import System.Collections.Generic;

private var  plugin: RazerHydraPlugin = new RazerHydraPlugin();

var id : int;
var player : GameObject;
var hand   : GameObject;

var zOffset : float;
var yOffset : float;

//button states
var trigger : boolean;
var bumper : boolean;

//ik setup variables
var ikSetup     : boolean;
var shoulderSet : boolean;
var wristSet    : boolean;

var shoulder : GameObject;
var wrist    : GameObject;

//posMarkers
var posMarker : GameObject;

var playerScript : Component;

/////////////////////////////////////////////////////////////////////////////////////////////////////////////////

function Start(){
	playerScript = player.GetComponent("player");
}

function Update () {
	
	//get latest data from tracker
	plugin._sixenseGetNewestData(id);
	
//tracker data=======================================================================================	
	
	//position data
	transform.localPosition.x = plugin.data.pos.x * .005;
	transform.localPosition.y = (plugin.data.pos.y * .005) + yOffset;
	transform.localPosition.z = (plugin.data.pos.z * -.005) + zOffset;
	//rotation data		
	transform.localRotation.x = plugin.data.rotQuat.x *-1;
	transform.localRotation.y = plugin.data.rotQuat.y *-1;
	transform.localRotation.z = plugin.data.rotQuat.z;
	
//IF THE TRIGGER IS PRESSED

	if(plugin.data.trigger >= 254 && !trigger){
		trigger = true;
		
		if(!shoulderSet){
			zOffset = plugin.data.pos.z * .005;
			shoulderSet = true;
		}
		
		if(shoulderSet){
			hand.animation.Play("fist");
		}
		//if the ik IS NOT setup yet--------------------------------------------------------------------
		/*if(!ikSetup){
			
			//if the shoulder pos has been set, set the wrist position next
			if(shoulderSet){// && !wristSet){
				
				/*thisPos = Instantiate(posMarker, transform.position, transform.rotation);
				
				if(id == 0){
					thisPos.transform.name = "WristPosLeft";
				}
				
				if(id == 1){
					thisPos.transform.name = "wristPosRight";
				}
				
				wristSet = true;
				wrist = thisPos.transform.gameObject;
				ikSetup = true;
				BuildArm();
			}
			
			//if the shoulder position isn't set yet
			if(!shoulderSet){
				thisPos = Instantiate(posMarker, transform.position, transform.rotation);
				
				if(id == 0){
					thisPos.transform.name = "shoulderPosLeft";
				}
				
				if(id == 1){
					thisPos.transform.name = "shoulderPosRight";
				}
				
				shoulderSet = true;
				shoulder = thisPos.transform.gameObject;
			}
		}*/
	}
	
//IF THE TRIGGER IS RELEASED
	
	if(trigger && plugin.data.trigger < 10 && shoulderSet){
		trigger = false;
		hand.animation.Play("unfist");
	}


//IF THE BUMPER IS PRESSED
	
	if((plugin.data.buttons & 128) && !bumper){
		bumper = true;
	}

//pass analog stick data to teh playerScript	
	if(id == 0){
		playerScript.joystickLeftX = plugin.data.joystick_x;
		playerScript.joystickLeftY = plugin.data.joystick_y;
	}
	
	if(id == 1){
		playerScript.joystickRightX = plugin.data.joystick_x;
		playerScript.joystickRightY = plugin.data.joystick_y;
	}
}

////////////////////////////////////////////////////////////////////////////////////////////////////////////
