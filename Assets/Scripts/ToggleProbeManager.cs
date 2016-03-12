using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ToggleProbeManager : MonoBehaviour {


	// Use this for initialization
	void Start () {
	
	}
	
	public void toggleCanvas() {
        if (!gameObject.activeSelf) {
            gameObject.SetActive(true);
        } else {
            gameObject.SetActive(false);
        }
    }
}
