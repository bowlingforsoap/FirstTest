using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Debug functionality to initiate moving buildings with controller buttons
public class MovingBuildingControllerInput : MonoBehaviour {
	public MovingBuildingController movingBuildingController;

	private SteamVR_TrackedObject trackedObj;
	private SteamVR_Controller.Device Controller {
		get { return SteamVR_Controller.Input((int)trackedObj.index); }
	}

	void Awake() {
		trackedObj = GetComponent<SteamVR_TrackedObject>();
	}
	
	// Update is called once per frame
	void Update () {
		HandleInput();
	}

	public void HandleInput() {
		if (Controller.GetPressDown(Valve.VR.EVRButtonId.k_EButton_A)) {
			if (gameObject.name.Equals("Controller (right)")) {
				// Debug.Log("A got pressed");
				movingBuildingController.StartMovingBuilding();
			}
			else 
			{
				// Debug.Log("X got pressed");	
			}
		}

		if (Controller.GetPressDown(Valve.VR.EVRButtonId.k_EButton_ApplicationMenu)) {	
			if (gameObject.name.Equals("Controller (right)")) {
				Debug.Log("B got pressed");
				movingBuildingController.StopMovingBuilding();
			}
			else
			{
				Debug.Log("Y got pressed");
				movingBuildingController.ResetBuilding();
			}
		}
	}
}
