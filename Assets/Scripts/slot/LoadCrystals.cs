using UnityEngine;
using System.Collections;

public class LoadCrystals : MonoBehaviour {
    public DataManager dataManager;
    [SerializeField] Transform slots;

    // Use this for initialization
    void Start () {
        putAvailableCrystalsIntoSlots();
    }

    private void putAvailableCrystalsIntoSlots() {
        //Object prefab = AssetDatabase.LoadAssetAtPath("Assets/something.prefab", typeof(GameObject));
        //GameObject clone = Instantiate(prefab, Vector3.zero, Quaternion.identity) as GameObject;

        GameObject objBlueCrystal = Resources.Load("crystals/crystalBlue") as GameObject;
        GameObject objPurpleCrystal = Resources.Load("crystals/crystalPurple") as GameObject;
        GameObject objRedCrystal = Resources.Load("crystals/crystalRed") as GameObject;
        GameObject objGreenCrystal = Resources.Load("crystals/crystalGreen") as GameObject;
        GameObject objYellowCrystal = Resources.Load("crystals/crystalYellow") as GameObject;
        GameObject objTurqouiseCrystal = Resources.Load("crystals/crystalTurqouise") as GameObject;

        GameObject objSlotAvailableCrystal = Resources.Load("slots/slotAvailableCrystal") as GameObject;

        foreach (CrystalVO crystalVO in dataManager.listCrystalVO) {

            GameObject curCrystal = null;
            if (crystalVO.tag.Equals(TagConstants.CRYSTAL_BLUE)) {
                curCrystal = objBlueCrystal;
            } else if (crystalVO.tag.Equals(TagConstants.CRYSTAL_PURPLE)) {
                curCrystal = objPurpleCrystal;
            } else if (crystalVO.tag.Equals(TagConstants.CRYSTAL_RED)) {
                curCrystal = objRedCrystal;
            } else if (crystalVO.tag.Equals(TagConstants.CRYSTAL_GREEN)) {
                curCrystal = objGreenCrystal;
            } else if (crystalVO.tag.Equals(TagConstants.CRYSTAL_YELLOW)) {
                curCrystal = objYellowCrystal;
            } else if (crystalVO.tag.Equals(TagConstants.CRYSTAL_TURQOUISE)) {
                curCrystal = objTurqouiseCrystal;
            }

            if (curCrystal != null) {
                for (int i = 0; i < crystalVO.count; i++) {
                    GameObject newCrystalSlot = Instantiate(objSlotAvailableCrystal) as GameObject;
                    newCrystalSlot.transform.SetParent(slots.transform);
                    addCrystal(curCrystal, newCrystalSlot.transform);
                }
            } else {
                Debug.Log("Unknown Tag" + crystalVO.tag);
            }
        }

        

        /*
        int i = 0;
        foreach (Transform slotTransform in slots) {
            //GameObject item = slotTransform.GetComponent<Slot>().item;
            if (dataManager.listCrystalVO.Count > i) {
                if (dataManager.listCrystalVO[i].tag.Equals(TagConstants.CRYSTAL_BLUE)) {
                    addCrystal(objBlueCrystal, slotTransform);
                } else if (dataManager.listCrystalVO[i].tag.Equals(TagConstants.CRYSTAL_PURPLE)) {
                    addCrystal(objPurpleCrystal, slotTransform);
                } else if (dataManager.listCrystalVO[i].tag.Equals(TagConstants.CRYSTAL_GREEN)) {
                    addCrystal(objGreenCrystal, slotTransform);
                } else if (dataManager.listCrystalVO[i].tag.Equals(TagConstants.CRYSTAL_RED)) {
                    addCrystal(objRedCrystal, slotTransform);
                } else if (dataManager.listCrystalVO[i].tag.Equals(TagConstants.CRYSTAL_YELLOW)) {
                    addCrystal(objYellowCrystal, slotTransform);
                } else if (dataManager.listCrystalVO[i].tag.Equals(TagConstants.CRYSTAL_TURQOUISE)) {
                    addCrystal(objTurqouiseCrystal, slotTransform);
                } else {
                    Debug.Log("Unknown Tag in 'putAvailableCrystalsIntoSlots':" + dataManager.listCrystalVO[i].tag);
                }
            }

            i++;
        }
        */
    }

    private void addCrystal(GameObject crystal, Transform slotTransform) {
        GameObject crystalNew = Instantiate(crystal) as GameObject;
        crystalNew.transform.SetParent(slotTransform.transform);
        crystalNew.transform.position = slotTransform.transform.position;
    }
}
