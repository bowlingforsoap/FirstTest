using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(BuildingSpawnController))]
public class BuildingSpawnEditor : Editor {
	public override void OnInspectorGUI() {
		DrawDefaultInspector();

		BuildingSpawnController myScript = (BuildingSpawnController)target;
		if (GUILayout.Button("Spawn a Building")) {
			myScript.PositionBuildingInFrontOfPlayer(myScript.building.transform);
			myScript.building.SetActive(true);

			ThisGameManager.canTeleport = false;
		}

		if (GUILayout.Button("Hide the Building")) {
			myScript.building.SetActive(false);
			
			ThisGameManager.canTeleport = true;
		}
	}
}
