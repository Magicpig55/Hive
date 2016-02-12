using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ShadowProjectionControl : MonoBehaviour {

	public Text text;

	public void ToggleSetting () {
		if (QualitySettings.shadowProjection == ShadowProjection.CloseFit) {
			QualitySettings.shadowProjection = ShadowProjection.StableFit;
			text.text = "Stable Fit";
		} else {
			QualitySettings.shadowProjection = ShadowProjection.CloseFit;
			text.text = "Close Fit";
		}
	}
}
