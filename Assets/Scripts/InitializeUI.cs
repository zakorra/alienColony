using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class InitializeUI : MonoBehaviour {
    public Canvas canvasModuleManager;
    public Canvas canvasProbeManager;


	// Use this for initialization
	void Start () {
        canvasModuleManager.gameObject.SetActive(false);
        canvasProbeManager.gameObject.SetActive(false);
    }
	
	
}
