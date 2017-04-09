using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using Leap.Unity.Interaction.CApi;

public class PickableObject : MonoBehaviour {

	public static Object prefab;
	public Canvas canvas;

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

	public Tween DoFade(GameObject target, float finalValue, float duration)
	{
		Tween tween = null;

		if (target.GetComponentInChildren<CanvasGroup> ()) {
			float a = target.GetComponentInChildren<CanvasGroup> ().alpha;
			tween = DOTween.To(() => a, x => a = x, finalValue, duration).OnUpdate(() => {
				target.GetComponentInChildren<CanvasGroup> ().alpha = a;
			});
		} else {
			Color color = target.GetComponent<Renderer> ().material.color;
			float a = target.GetComponent<Renderer>().material.color.a;
			tween = DOTween.To(() => a, x => a = x, finalValue, duration).OnUpdate(() => {
				color = new Color(color.r, color.g, color.b, a);
				target.GetComponent<Renderer>().material.color = color;
			});
		}

		return tween;
	}

	void OnCollisionEnter(Collision collision) {
		if (collision.gameObject.GetComponent<Leap.Unity.Interaction.InteractionBrushHand> ()) {
			Sequence mySequence = DOTween.Sequence();
			mySequence.Append(DoFade(this.gameObject, 0, 0.5f));
		}
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
