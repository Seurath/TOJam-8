import System.Collections.Generic;

private var  plugin: RazerHydraPlugin = new RazerHydraPlugin();
var id : int;

var joystickRightX : float;
var joystickRightY  : float;

var joystickLeftX : float;
var joystickLeftY  : float;

var speed       : float;
var speedAdjust : float;

var turnSpeed : float;
var turnSpeedAdjust : float;

function Start () {
	plugin._sixenseInit();
}

function Update () {

	plugin._sixenseGetNewestData(id);

//WALKING	
	//walk forward------------------------------------------------------------------------------------------------
	if(joystickLeftY > 127){
		transform.Translate(Vector3.forward * Time.deltaTime * (speed + ((joystickLeftY - 127) * speedAdjust)));
	}

	//walk backward------------------------------------------------------------------------------------------------
	if(joystickLeftY < 127){
		transform.Translate(Vector3.forward * Time.deltaTime * (-speed + ((joystickLeftY  -127) * speedAdjust) * 1));
	}

	//strafe right------------------------------------------------------------------------------------------------	
	if(joystickLeftX > 127 && speed != 10){
		transform.Translate(Vector3.right * Time.deltaTime * (speed + ((joystickLeftX - 127) * speedAdjust)));
	}

	//strafe left------------------------------------------------------------------------------------------------	
	if(joystickLeftX < 127 && speed != 10){
		transform.Translate(Vector3.right * Time.deltaTime * (-speed + ((joystickLeftX  -127) * speedAdjust) * 1));
	}


//TURNING
	if(joystickRightX > 127){
		transform.RotateAround(transform.position, Vector3.up, (turnSpeed + ((joystickRightX - 127) * turnSpeedAdjust)));
	}
	
	if(joystickRightX < 127){
		transform.RotateAround(transform.position, Vector3.up * -1, (turnSpeed + ((127 - joystickRightX ) * turnSpeedAdjust)));
	}		
}