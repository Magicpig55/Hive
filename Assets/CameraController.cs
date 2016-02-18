using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	public float Zoom {
		set {
			transform.position = new Vector3(transform.position.x, value, transform.position.z);
		}
		get {
			return transform.position.y;
		}
	}
	public float Sensitivity = 100;
	public bool Invert = true;

	private Vector3 mClickPos;
	private Vector3 mCamClickPos;
	private bool mMoving;

	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (1)) {
			mClickPos = Input.mousePosition;
			mCamClickPos = transform.position;
			mMoving = true;
		}
		if (Input.GetMouseButtonUp (1)) {
			mMoving = false;
		}
		if (mMoving) {
			Vector3 dPos = (mClickPos - Input.mousePosition) / Sensitivity;
			dPos = new Vector3(-dPos.x, dPos.y, dPos.z);
			dPos *= Invert ? -1 : 1;
			transform.position = mCamClickPos + Vector2Dto3D(dPos);
		}
		float a = Input.GetAxis ("Mouse ScrollWheel");
		if (a != 0) {
			Zoom += a;
		}
		if (Zoom < 1)
			a = 1;
	}
	private Vector3 Vector2Dto3D(Vector3 vec) {
		return new Vector3 (vec.y, vec.z, vec.x);
	}
}
