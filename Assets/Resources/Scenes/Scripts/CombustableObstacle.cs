using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CombustableObstacle : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

	public Tween DoFade(GameObject target, float finalValue, float duration)
	{
		Tween tween = null;

		if (target.GetComponent<CanvasGroup> ()) {
			float a = target.GetComponent<CanvasGroup> ().alpha;
			tween = DOTween.To(() => a, x => a = x, finalValue, duration).OnUpdate(() => {
				target.GetComponent<CanvasGroup> ().alpha = a;
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

	public void OnPlayerLook() {
		HideObject ();
		Debug.Log ("canvas hit");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
