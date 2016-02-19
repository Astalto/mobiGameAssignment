using UnityEngine;
using System;
using System.Collections;

public class PlayerInput : MonoBehaviour {
	public struct SimpleTouch
	{
		public Vector2 StartTouchLocation;
		public Vector2 CurrentTouchLocation;
		public DateTime StartTime;
		public TouchPhase Phase;
	}
	public PlayerClass GameCharacter;
	public float SwipeTime;
	public float SwipeDistance;
	private SimpleTouch ActiveTouch;
	private Touch DeviceTouch;

		private void CalculateTouchInput(SimpleTouch CurrentTouch)
	{
		Vector2 touchDirection = (CurrentTouch.CurrentTouchLocation - CurrentTouch.StartTouchLocation);
		float touchDistance = (CurrentTouch.StartTouchLocation - CurrentTouch.CurrentTouchLocation).magnitude;

		if (GameCharacter != null) {
			RaycastHit2D hitInfo = Physics2D.Raycast (Camera.main.ScreenToWorldPoint (
			CurrentTouch.StartTouchLocation), Vector2.zero);
			if (hitInfo && hitInfo.transform.CompareTag("Player")) {
				GameCharacter.ReceiveInput (touchDirection, touchDistance);
			}
		}
	}
	// Use this for initialization
	void Start () {
		ActiveTouch.Phase = TouchPhase.Canceled;
	}
	// Update is called once per frame
	void Update () {
		if (Application.isEditor) {
			if (Input.GetMouseButton (0)) {
				if (ActiveTouch.Phase == TouchPhase.Canceled) {
					ActiveTouch.CurrentTouchLocation = Input.mousePosition;
					ActiveTouch.StartTouchLocation = Input.mousePosition;
					ActiveTouch.StartTime = System.DateTime.Now;
					ActiveTouch.Phase = TouchPhase.Began;
				} else {
					ActiveTouch.CurrentTouchLocation = Input.mousePosition;
				}
			} else {
				if (ActiveTouch.Phase == TouchPhase.Began) {
					CalculateTouchInput (ActiveTouch);
					ActiveTouch.Phase = TouchPhase.Canceled;
				}
			}
		} else {
			if (Input.touchCount >= 1) {
				DeviceTouch = Input.GetTouch (0);
				if (ActiveTouch.Phase == TouchPhase.Canceled) {
					ActiveTouch.Phase = DeviceTouch.phase;
					ActiveTouch.StartTime = System.DateTime.Now;
					ActiveTouch.StartTouchLocation = DeviceTouch.position;
					ActiveTouch.CurrentTouchLocation = DeviceTouch.position;
				} else {
					ActiveTouch.CurrentTouchLocation = DeviceTouch.position;
				}
			} else {
				if (ActiveTouch.Phase == TouchPhase.Began) {
					CalculateTouchInput (ActiveTouch);
					ActiveTouch.Phase = TouchPhase.Canceled;
				}
			}
		}
	}
}