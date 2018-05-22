using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogPosition : MonoBehaviour {

	void Awake()
    {
        Debug.Log("Position on Awake: " + transform.localPosition);
    }

    void Start()
    {
        Debug.Log("Position on Start: " + transform.localPosition);
    }
}
