using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(MovingBuildingController))]
public class MovingBuildingEditor : Editor {
	public override void OnInspectorGUI() {
		DrawDefaultInspector();

		MovingBuildingController myScript = (MovingBuildingController)target;

		if (GUILayout.Button("Start Moving the Building")) {
			myScript.StartMovingBuilding();
		}

		if (GUILayout.Button("Stop Moving")) {
			myScript.StopMovingBuilding();
		}

		if (GUILayout.Button("Reset Building")) {
			myScript.ResetBuilding();
		}
	}
}
