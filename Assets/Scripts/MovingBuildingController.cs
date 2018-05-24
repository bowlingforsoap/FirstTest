using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingBuildingController : MonoBehaviour {
	public Transform playerTransform;
	public Transform buildingTransform;
	public float speed;
	// Debug
	public Transform headTransform;
	
	// Where we are moving to
	private Vector3 targetPosition;
	private Vector3 TargetPosition {
		get {return targetPosition - DistanceCounter.differenceBetweenPivotAndOutterWall;}
		set {targetPosition = value;}
	}
	private Vector3 buildingInitialPosition;

	void Start() {
		buildingInitialPosition = buildingTransform.position;
	}

	void Update() {
		if (ThisGameManager.moveBuilding) {
			MoveBuildingOntoPlayer(TargetPosition, buildingTransform, speed);
		}
	}

	public void StartMovingBuilding() {
		Vector3 playerPositionZeroY = playerTransform.position;
		playerPositionZeroY.y = 0f;
		TargetPosition = playerPositionZeroY;
		ThisGameManager.moveBuilding = true;
	}

	public void StopMovingBuilding() {
		ThisGameManager.moveBuilding = false;
	}

	public void ResetBuilding() {
		buildingTransform.position = buildingInitialPosition;
	}

	private static void MoveBuildingOntoPlayer(Vector3 playerPosition, Transform buildingTransform, float speed) {
		if (playerPosition == buildingTransform.position) {
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
