using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ModuleChangeListener : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	public void valueChanged(float a) {
        Debug.Log("ModuleValue changed = " + a);
    }
}
