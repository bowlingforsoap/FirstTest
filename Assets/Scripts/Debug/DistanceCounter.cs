using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceCounter : MonoBehaviour {

	public static Vector3 differenceBetweenPivotAndOutterWall;

	public Transform objectOne;
	public Transform objectTwo;

	void Start() {
		differenceBetweenPivotAndOutterWall = FindDifferenceVector();
		differenceBetweenPivotAndOutterWall.y = 0f;

		print("Difference between pivot and the outter wall: " + differenceBetweenPivotAndOutterWall);
	}

	public float CountDistanceNoY() {
		Vector3 objectOnePosition, objectTwoPosition;
		objectOnePosition = objectOne.position;
		objectTwoPosition = objectTwo.position;
		objectOnePosition.y = 0f;
		objectTwoPosition.y = 0f;
		return Vector3.Distance(objectOnePosition, objectTwoPosition);
	}

	public Vector3 FindDifferenceVector() {
		return objectOne.position - objectTwo.position;
	}
}
