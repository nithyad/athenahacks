using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;
using DG.Tweening;

public class CombustableCanvas : VRTK_UICanvas {

	// Use this for initialization
	void Start () {

	}

	public Tween DoFade(GameObject target, float finalValue, float duration)
	{
		Tween tween = null;

		float a = target.GetComponent<CanvasGroup> ().alpha;
		tween = DOTween.To(() => a, x => a = x, finalValue, duration).OnUpdate(() => {
			target.GetComponent<CanvasGroup> ().alpha = a;
		});

		return tween;
	}

	protected virtual void ShowObject()
	{
		Sequence mySequence = DOTween.Sequence();
		mySequence.Append(DoFade(this.gameObject, 1, 0.5f));
	}

	protected virtual void HideObject()
	{
		Sequence mySequence = DOTween.Sequence();
		mySequence.Append(DoFade(this.gameObject, 0, 0.5f));
	}

	protected override void OnTriggerEnter(Collider other) {
		HideObject ();
		Debug.Log ("canvas hit");
	}

	// Update is called once per frame
	void Update () {

	}
}
