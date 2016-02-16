using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ShadowControl : MonoBehaviour {

	public Text text;

	private string[] qualitySettings = { "Disabled", "Low", "Medium", "High", "Very High" };

	void Start() {
		text.text = qualitySettings [QualitySettings.GetQualityLevel ()];
	}

	public void IncrementQuality () {
		int q = QualitySettings.GetQualityLevel ();
		ShadowProjection p = QualitySettings.shadowProjection;
        int a = QualitySettings.antiAliasing;
        QualitySettings.SetQualityLevel (q + 1 > qualitySettings.Length ? 0 : q + 1);
		QualitySettings.shadowProjection = p;
        QualitySettings.antiAliasing = a;
        text.text = qualitySettings [QualitySettings.GetQualityLevel ()];
	}
	public void DeincrementQuality () {
		int q = QualitySettings.GetQualityLevel ();
		ShadowProjection p = QualitySettings.shadowProjection;
        int a = QualitySettings.antiAliasing;
		QualitySettings.SetQualityLevel (q - 1 < 0 ? qualitySettings.Length : q - 1);
		QualitySettings.shadowProjection = p;
        QualitySettings.antiAliasing = a;
		text.text = qualitySettings [QualitySettings.GetQualityLevel ()];
	}
}
