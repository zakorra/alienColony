using UnityEngine;
using System.Collections;
using UnityEngine.UI;

using System.Collections.Generic;
using UnityEngine.Events;

public class ModuleCrystalManager : MonoBehaviour {
  public Transform availableCrystalsSlots;

  public DataManager dataManager;
  public Dropdown moduleDropBox;
  public Transform redSlots;
  public Transform blueSlots;
  public Transform purpleSlots;

  private List<GameObject> currentAvailableCrystalsSlots;
  private List<GameObject> currentCrystals;

  private GameObject objEquippedRedCrystal;
  private GameObject objEquippedBlueCrystal;
  private GameObject objEquippedPurpleCrystal;
  private List<GameObject> currentRedSlots;
  private List<GameObject> currentBlueSlots;
  private List<GameObject> currentPurpleSlots;

  private GameObject objBlueCrystal;
  private GameObject objPurpleCrystal;
  private GameObject objRedCrystal;
  private GameObject objGreenCrystal;
  private GameObject objYellowCrystal;
  private GameObject objTurqouiseCrystal;

  private GameObject objSlotAvailableCrystal;

  // Use this for initialization
  void Start () {
    // Init/Cache Resources
    objBlueCrystal = Resources.Load("crystals/crystalBlue") as GameObject;
    objPurpleCrystal = Resources.Load("crystals/crystalPurple") as GameObject;
    objRedCrystal = Resources.Load("crystals/crystalRed") as GameObject;
    objGreenCrystal = Resources.Load("crystals/crystalGreen") as GameObject;
    objYellowCrystal = Resources.Load("crystals/crystalYellow") as GameObject;
    objTurqouiseCrystal = Resources.Load("crystals/crystalTurqouise") as GameObject;

    objSlotAvailableCrystal = Resources.Load("slots/slotAvailableCrystal") as GameObject;

    //
    currentAvailableCrystalsSlots = new List<GameObject>();
    currentCrystals = new List<GameObject>();

    //
    currentRedSlots = new List<GameObject>();
    currentBlueSlots = new List<GameObject>();
    currentPurpleSlots = new List<GameObject>();
  }

  public void init() {
    removeObjects(currentCrystals);
    removeObjects(currentAvailableCrystalsSlots);

    removeObjects(currentRedSlots);
    removeObjects(currentBlueSlots);
    removeObjects(currentPurpleSlots);

    currentAvailableCrystalsSlots.Clear();
    currentCrystals.Clear();

    currentRedSlots.Clear();
    currentBlueSlots.Clear();
    currentPurpleSlots.Clear();

    moduleDropBox.options.Clear();
    foreach (ModuleVO moduleVO in dataManager.listModuleVO) {
      moduleDropBox.options.Add(new Dropdown.OptionData() {
        text = moduleVO.getDropBoxText()
      });
    }

    //this swith from 1 to 0 is only to refresh the visual DdMenu
    moduleDropBox.value = 1;
    moduleDropBox.value = 0;

    moduleDropBox.onValueChanged.AddListener(valueChanged);

    // Slots for crystals
    objEquippedRedCrystal = Resources.Load("slots/slotRedCrystal") as GameObject;
    objEquippedBlueCrystal = Resources.Load("slots/slotBlueCrystal") as GameObject;
    objEquippedPurpleCrystal = Resources.Load("slots/slotPurpleCrystal") as GameObject;

    //
    valueChanged(0);
  }

  /*
   DropBox Changed Value: New Module
  */
  public void valueChanged(int value) {
    Debug.Log("ModuleValue changed = " + value);

    // Reset Available Crystals
    removeObjects(currentAvailableCrystalsSlots);
    currentAvailableCrystalsSlots.Clear();

    putAvailableCrystalsIntoSlots();

    // Reset Red equipped crystals
    setupEquipedSlot(currentRedSlots, dataManager.listModuleVO[value].red_crystal_slots, redSlots, objEquippedRedCrystal);

    // Reset Blue equipped crystals
    setupEquipedSlot(currentBlueSlots, dataManager.listModuleVO[value].blue_crystal_slots, blueSlots, objEquippedBlueCrystal);

    // Reset Purple equipped crystals
    setupEquipedSlot(currentPurpleSlots, dataManager.listModuleVO[value].purple_crystal_slots, purpleSlots, objEquippedPurpleCrystal);

    Equipment equipment = gameObject.GetComponent<Equipment>();
    equipment.moduleVo = dataManager.listModuleVO[value];
  }


  private void setupEquipedSlot(List<GameObject> equipedSlots, int count, Transform slot, GameObject objResourceCrystal) {
    removeObjects(equipedSlots);
    equipedSlots.Clear();
    for (int i = 0; i < count; i++) {
      equipedSlots.Add(addSlot(objResourceCrystal, slot));
    }
  }

  private GameObject addSlot(GameObject slot, Transform slotTransform) {
    GameObject slotNew = Instantiate(slot) as GameObject;
    slotNew.transform.SetParent(slotTransform.transform);
    slotNew.transform.position = slotTransform.transform.position;

    return slotNew;
  }


  private void putAvailableCrystalsIntoSlots() {
    foreach (CrystalVO crystalVO in dataManager.listCrystalVO) {

      GameObject curCrystal = null;
      if (crystalVO.tag.Equals(TagConstants.CRYSTAL_BLUE))
      {
        curCrystal = objBlueCrystal;
      }
      else if (crystalVO.tag.Equals(TagConstants.CRYSTAL_PURPLE))
      {
        curCrystal = objPurpleCrystal;
      }
      else if (crystalVO.tag.Equals(TagConstants.CRYSTAL_RED))
      {
        curCrystal = objRedCrystal;
      }
      else if (crystalVO.tag.Equals(TagConstants.CRYSTAL_GREEN))
      {
        curCrystal = objGreenCrystal;
      }
      else if (crystalVO.tag.Equals(TagConstants.CRYSTAL_YELLOW))
      {
        curCrystal = objYellowCrystal;
      }
      else if (crystalVO.tag.Equals(TagConstants.CRYSTAL_TURQOUISE))
      {
        curCrystal = objTurqouiseCrystal;
      }

      if (curCrystal != null)
      {
        for (int i = 0; i < crystalVO.count; i++) {
          GameObject newCrystalSlot = Instantiate(objSlotAvailableCrystal) as GameObject;
          newCrystalSlot.transform.SetParent(availableCrystalsSlots.transform);
          addCrystal(curCrystal, newCrystalSlot.transform, crystalVO);

          currentAvailableCrystalsSlots.Add(newCrystalSlot);
        }
      }
      else {
        Debug.Log("Unknown Tag" + crystalVO.tag);
      }
    }
  }

  private void addCrystal(GameObject crystal, Transform slotTransform, CrystalVO crystalVO) {
    GameObject crystalNew = Instantiate(crystal) as GameObject;
    crystalNew.transform.SetParent(slotTransform.transform);
    crystalNew.transform.position = slotTransform.transform.position;

    CrystalVO newCrystalVO = crystalNew.gameObject.AddComponent<CrystalVO>();
    newCrystalVO.cloneFromCrystalVO(crystalVO);

    currentCrystals.Add(crystalNew);
  }

  private void removeObjects(List<GameObject> gameObjects) {
    foreach (GameObject anObject in gameObjects) {
      Destroy(anObject);
    }
  }
}
