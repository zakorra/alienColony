using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ToggleGameObjectActive : MonoBehaviour {


	// Use this for initialization
	void Start () {
	
	}
	
	public void toggleActive() {
        if (!gameObject.activeSelf) {
            gameObject.SetActive(true);
        } else {
            gameObject.SetActive(false);
        }
    }
}
