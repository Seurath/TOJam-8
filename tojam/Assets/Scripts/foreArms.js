#pragma strict

var tracker : GameObject;
function Update () {
	
	transform.localEulerAngles.x = tracker.transform.eulerAngles.z;
}