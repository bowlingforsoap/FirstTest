using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputTester : MonoBehaviour {
	private SteamVR_TrackedObject trackedObj;
	private SteamVR_Controller.Device Controller 
	{
		get { return SteamVR_Controller.Input((int) trackedObj.index); }
	}

	void Awake() {
		trackedObj = GetComponent<SteamVR_TrackedObject>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Controller.GetPressDown(SteamVR_Controller.ButtonMask.Axis0)) { // Joystick press
                Debug.Log("SteamVR_Controller.ButtonMask.Axis0 pressed");
		}
		if (Controller.GetPressDown(SteamVR_Controller.ButtonMask.Axis1)) { // Trigger press
			Debug.Log("SteamVR_Controller.ButtonMask.Axis1 pressed");
		}
		if (Controller.GetPressDown(SteamVR_Controller.ButtonMask.Axis2)) { // Grip press
			Debug.Log("SteamVR_Controller.ButtonMask.Axis2 pressed");
		}
		if (Controller.GetPressDown(SteamVR_Controller.ButtonMask.Axis3)) {
			Debug.Log("SteamVR_Controller.ButtonMask.Axis3 pressed");
		}
		if (Controller.GetPressDown(SteamVR_Controller.ButtonMask.Axis4)) {
			Debug.Log("SteamVR_Controller.ButtonMask.Axis4 pressed");
		}
		if (Controller.GetPressDown(Valve.VR.EVRButtonId.k_EButton_A)) {
			if (gameObject.name.Equals("Controller (right)")) {
				Debug.Log("A got pressed");
			}
			else 
			{
				Debug.Log("X got pressed");
			}
		}
		if (Controller.GetPressDown(Valve.VR.EVRButtonId.k_EButton_ApplicationMenu)) {
			if (gameObject.name.Equals("Controller (right)")) {
				Debug.Log("B got pressed");
			}
			else
			{
				Debug.Log("Y got pressed");
			}
		}
	}
}
