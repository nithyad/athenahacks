using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickableObjectManager : MonoBehaviour {
	
	public List<string> phrases;

	// Use this for initialization
	void Start () {
		InstantiateFlower ();
	}

	public void InstantiateFlower() {
		PickableObject flower = PickableObject.Create (phrases [0]);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
