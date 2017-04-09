using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickableObject : MonoBehaviour {

	public static Object prefab;
	public Canvas canvas;
	public string textToUse;

	// Use this for initialization
	void Start () {
		prefab = Resources.Load("Prefabs/PickableObject");
	}

	void Awake() {
		prefab = Resources.Load("Prefabs/PickableObject");
	}

	public static PickableObject Create(string newText) {
		prefab = Resources.Load("Prefabs/PickableObject");
		GameObject newObject = Instantiate (prefab) as GameObject;
		PickableObject po = newObject.GetComponent<PickableObject> ();
		po.SetText (newText);
		return po;
	}

	public void SetText(string newText) {
		canvas = GetComponentInChildren<Canvas> ();
		Text text = canvas.GetComponentInChildren<Text> ();

		text.text = newText;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
