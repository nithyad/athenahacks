using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class MovingObstacle : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

	void OnTriggerEnter(Collider col){
		Debug.Log("reached");

		if (col.gameObject.GetComponent<VRTK_HeadsetCollision>()) {
			Debug.Log("hit");
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
