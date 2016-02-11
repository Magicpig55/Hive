using UnityEngine;
using System.Collections;

public class TimeControl : MonoBehaviour {

    public float DegreeOfTime = 0;
    public float Modifier = 1;
    public float Delta = 0;
	
	// Update is called once per frame
	void Update () {
        DegreeOfTime += Time.deltaTime * Modifier;
        Delta = Time.deltaTime * Modifier;
	}
}
