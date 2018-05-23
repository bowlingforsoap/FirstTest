using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Oscilates the arrow
public class ViewingSpotArrowController : MonoBehaviour {
	public float amplitude;
	public float oscilationSpeed;
	public float rotationSpeed;

	private Vector3 positionAtStart;

	void Start() {
		positionAtStart = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		transform.position += Time.deltaTime * amplitude * transform.up * Mathf.Sin(Time.realtimeSinceStartup * oscilationSpeed);
		transform.rotation = Quaternion.AngleAxis(Time.deltaTime * rotationSpeed, transform.up) * transform.rotation;
	}
}
