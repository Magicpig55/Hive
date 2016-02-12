using UnityEngine;
using System.Collections;

public class SunController : MonoBehaviour {

    public TimeControl TimeController;

	// Update is called once per frame
	void Update () {
        transform.Rotate(TimeController.Delta, 0f, 0f);
	}
}
