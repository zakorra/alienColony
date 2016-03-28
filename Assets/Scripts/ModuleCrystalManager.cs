using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.Events;

public class ModuleCrystalManager : MonoBehaviour {
    public Dropdown moduleDropBox;
    public DataManager dataManager;
    public Transform redSlots;

    private GameObject objRedCrystal;
    private List<GameObject> currentRedSlots;

    // Use this for initialization
    void Start () {
        currentRedSlots = new List<GameObject>();

        moduleDropBox.options.Clear();
        foreach(ModuleVO moduleVO in dataManager.listModuleVO) {
            moduleDropBox.options.Add(new Dropdown.OptionData() {
                text = moduleVO.getDropBoxText()
            });
        }

        //this swith from 1 to 0 is only to refresh the visual DdMenu
        moduleDropBox.value = 1;
        moduleDropBox.value = 0;

        moduleDropBox.onValueChanged.AddListener(valueChanged);

        // Slots for crystals
        objRedCrystal = Resources.Load("slots/slotRedCrystal") as GameObject;

        //
        valueChanged(0);
    }

    public void valueChanged(int value) {
        Debug.Log("ModuleValue changed = " + value);

        foreach(GameObject curRedSlot in currentRedSlots) {
            Destroy(curRedSlot);
        }

        currentRedSlots.Clear();
        for (int i=0;i < dataManager.listModuleVO[value].red_crystal_slots; i++) {
            currentRedSlots.Add(addSlot(objRedCrystal, redSlots));
        }
    }

    private GameObject addSlot(GameObject slot, Transform slotTransform) {
        GameObject slotNew = Instantiate(slot) as GameObject;
        slotNew.transform.SetParent(slotTransform.transform);
        slotNew.transform.position = slotTransform.transform.position;

        return slotNew;
    }


}
