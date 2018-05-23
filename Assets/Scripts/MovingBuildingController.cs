using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingBuildingController : MonoBehaviour {
	public Transform playerTransform;
	public Transform buildingTransform;
	public float speed;
	
	// Where we are moving to
	private Vector3 targetPosition;
	private Vector3 buildingInitialPosition;
	void Start() {
		buildingInitialPosition = buildingTransform.position;
	}

	void Update() {
		if (ThisGameManager.moveBuilding) {
			MoveBuildingOntoPlayer(targetPosition, buildingTransform, speed);
		}
	}

	public void StartMovingBuilding() {
		Debug.Log("targetPosition: " + playerTransform.position);
		
		targetPosition = playerTransform.position;
		ThisGameManager.moveBuilding = true;
	}

	public void StopMovingBuilding() {
		ThisGameManager.moveBuilding = false;
	}

	public void ResetBuilding() {
		buildingTransform.position = buildingInitialPosition;
	}

	public static void MoveBuildingOntoPlayer(Vector3 playerPosition, Transform buildingTransform, float speed) {
		if (playerPosition == buildingTransform.position) {
			Debug.Log("playerPosition: " + playerPosition);
			Debug.Log("building.localPosition" + buildingTransform.localPosition);
			Debug.Log("building.position" + buildingTransform.position);

			ThisGameManager.moveBuilding = false;
			return;
		}

		float step = speed * Time.deltaTime;

		Vector3 newPosition;
		// Essentially, does what the Vector3.MoveTowards method does
		// Vector3 direction = playerPosition - buildingTransform.position;
		// direction.Normalize();
		// newPosition = buildingTransform.position + direction * step;
		newPosition = Vector3.MoveTowards(buildingTransform.position, playerPosition, step);

		buildingTransform.position = newPosition;
	}
}
