using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AntialiasingControl : MonoBehaviour {

    public Text text;
    private int[] PossibleLevels = { 0, 2, 4, 8 };
    private int CurrentLevel = 0;
    private string[] DisplayNames = { "Disabled", "MSAA x2", "MSAA x4", "MSAA x8" };

    void Start() {
        for(int i = 0; i < PossibleLevels.Length; i++) {
            if(PossibleLevels[i] == QualitySettings.antiAliasing) {
                CurrentLevel = i;
            }
        }
        text.text = DisplayNames[CurrentLevel];
    }

    public void Increment() {
        CurrentLevel++;
        if (CurrentLevel >= PossibleLevels.Length) CurrentLevel = 0;
        QualitySettings.antiAliasing = PossibleLevels[CurrentLevel];
        text.text = DisplayNames[CurrentLevel];
    }
    public void Deincrement() {
        CurrentLevel--;
        if (CurrentLevel < 0) CurrentLevel = PossibleLevels.Length - 1;
        QualitySettings.antiAliasing = PossibleLevels[CurrentLevel];
        text.text = DisplayNames[CurrentLevel];
    }
}
