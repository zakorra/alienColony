using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;


public class InitializeModuleSchemas : MonoBehaviour {
    public Dropdown moduleDropBox;
    public DataManager dataManager;

    // Use this for initialization
    void Start () {
        moduleDropBox.options.Clear();
        foreach(ModuleVO moduleVO in dataManager.listModuleVO) {
            moduleDropBox.options.Add(new Dropdown.OptionData() {
                text = moduleVO.getDropBoxText()
            });
        }

        //this swith from 1 to 0 is only to refresh the visual DdMenu
        moduleDropBox.value = 1;
        moduleDropBox.value = 0;
    }
	
	
}
