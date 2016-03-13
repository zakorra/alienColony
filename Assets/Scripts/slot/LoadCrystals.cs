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
        GameObject objBluePurple = Resources.Load("crystals/crystalPurple") as GameObject;
        GameObject objBlueRed = Resources.Load("crystals/crystalRed") as GameObject;
       

        int i = 0;
        foreach (Transform slotTransform in slots) {
            //GameObject item = slotTransform.GetComponent<Slot>().item;
            if (dataManager.listCrystalVO.Count > i) {
                if (dataManager.listCrystalVO[i].tag.Equals("crystalBlue")) {
                    addCrystal(objBlueCrystal, slotTransform);
                } else if (dataManager.listCrystalVO[i].tag.Equals("crystalPurple")) {
                    addCrystal(objBluePurple, slotTransform);
                } else if (dataManager.listCrystalVO[i].tag.Equals("crystalRed")) {
                    addCrystal(objBlueRed, slotTransform);
                } else {
                    Debug.Log("Unknown Tag in 'putAvailableCrystalsIntoSlots':" + dataManager.listCrystalVO[i].tag);
                }
            }

            i++;
        }
    }

    private void addCrystal(GameObject crystal, Transform slotTransform) {
        GameObject crystalNew = Instantiate(crystal) as GameObject;
        crystalNew.transform.SetParent(slotTransform.transform);
        crystalNew.transform.position = slotTransform.transform.position;
    }
}
