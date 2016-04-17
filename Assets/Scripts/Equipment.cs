using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System;
using System.Collections.Generic;
using System.Text;


public class Equipment : MonoBehaviour, IHasChanged {
  [SerializeField] Boolean isEquipment;
  [SerializeField] Transform slots;
  [SerializeField] Text moduleText;
  [SerializeField] Text moduleTextValues;

  public DataManager dataManager;

  private float scanValueDec;
  private float miningValueDec;
  private float engineValueDec;
  private float shildValueDec;

  private int costValue;
  private float manuTimeValue;

  private List<CrystalVO> crystals;

  public ModuleVO moduleVo { get; set; }


  // Use this for initialization
  void Start () {
    crystals = new List<CrystalVO>();
    HasChanged();
  }

  public void HasChanged() {
    moduleText.text = "";
    crystals.Clear();

    if (isEquipment) {
      // get all crystals from the different colored slots

      foreach (Transform crystalSots in slots) {
        foreach (Transform slotTransform in crystalSots) {
          GameObject item = slotTransform.GetComponent<Slot>().item;
          if (item) {
            CrystalVO crystalVO = item.GetComponent<CrystalVO>();
            crystals.Add(crystalVO);
          }
        }
      } // eof crystalSlots

      calcModuleValues(crystals);
    }
  }

  public void createModule() {
    RunModuleVO runModuleVO = new RunModuleVO();
    runModuleVO.moduleId = moduleVo.id;
    runModuleVO.scanValue = scanValueDec;
    runModuleVO.miningValue = miningValueDec;
    runModuleVO.engineValue = engineValueDec;
    runModuleVO.shildValue = shildValueDec;

    runModuleVO.costValue = costValue;
    runModuleVO.manuTimeValue = manuTimeValue;

    dataManager.removeCrystalsFromInventory(crystals);
    dataManager.credits -= costValue;

    dataManager.store(runModuleVO);

    //ExecuteEvents.ExecuteHierarchy<IPlayerResourcesChanged>(gameObject, null, (x, y) => x.PlayerResourcesChanged());
		//ExecuteEvents.Execute<IPlayerResourcesChanged>(InfoUpdater.Instance, null, (x, y) => x.PlayerResourcesChanged());
		InfoUpdater.Instance.PlayerResourcesChanged ();
  }

  private void calcModuleValues(List<CrystalVO> crystals) {
    StringBuilder sb = new StringBuilder();
    StringBuilder sbValues = new StringBuilder();

    float manufactoringCost = 0;
    float manufactoringTime = 0;

    float scanValue = 0;
    float miningValue = 0;
    float engineValue = 0;
    float shildValue = 0;

    foreach (CrystalVO crystalVO in crystals) {
      manufactoringCost += crystalVO.costFactor;
      manufactoringTime += crystalVO.costFactor * 1.5f;

      scanValue += (float)crystalVO.scanValue * (crystalVO.qualityFactor + crystalVO.occurrencyFactor);
      miningValue += (float)crystalVO.miningValue * (crystalVO.qualityFactor + crystalVO.occurrencyFactor);
      engineValue += (float)crystalVO.engineValue * (crystalVO.qualityFactor + crystalVO.occurrencyFactor);
      shildValue += (float)crystalVO.shildValue * (crystalVO.qualityFactor + crystalVO.occurrencyFactor);
    }
    float crystalCount = (float)crystals.Count;

    if (crystalCount > 1) {
      scanValue /= crystalCount / 1.5f;
      miningValue /= crystalCount / 1.5f;
      engineValue /= crystalCount / 1.5f;
      shildValue /= crystalCount / 1.5f;
    }

    scanValueDec = (float) Math.Round((Decimal)scanValue, 3, MidpointRounding.AwayFromZero);
    miningValueDec = (float) Math.Round((Decimal)miningValue, 3, MidpointRounding.AwayFromZero);
    engineValueDec = (float) Math.Round((Decimal)engineValue, 3, MidpointRounding.AwayFromZero);
    shildValueDec = (float) Math.Round((Decimal)shildValue, 3, MidpointRounding.AwayFromZero);

    costValue = (int) ((scanValue + miningValue + engineValue + shildValue) * 100f * manufactoringCost);
    manuTimeValue = costValue * manufactoringTime * 0.0015f;

    sb.Append("Manu Cost:" + "\n");
    sb.Append("Manu Time:" + "\n");

    sb.Append("Module" + "\n");
    sb.Append("\tScan" + "\n");
    sb.Append("\tMining" + "\n");
    sb.Append("\tEngine" + "\n");
    sb.Append("\tShield" + "\n");

    moduleText.text = sb.ToString();

    sbValues.Append(costValue + "\n");
    sbValues.Append(manuTimeValue + "\n");
    sbValues.Append("\n");
    sbValues.Append(miningValueDec + "\n");
    sbValues.Append(scanValueDec + "\n");
    sbValues.Append(miningValue + "\n");
    sbValues.Append(engineValueDec + "\n");
    sbValues.Append(shildValueDec);

    moduleTextValues.text = sbValues.ToString();
  }

  private void addToolTipParameter(StringBuilder sb, int index, string fieldName) {
    if (index > 2) {
      sb.Append("\n\t");
    }
    if (fieldName != null) {
      sb.Append(fieldName);
      sb.Append(":\t");

    }

    if (index == 2) {
      sb.Append("{" + index + ",-50}");
    } else {
      sb.Append("{" + index + ",-50:0.00}");
    }
  }
}

namespace UnityEngine.EventSystems {
  public interface IHasChanged : IEventSystemHandler {
    void HasChanged();
  }
}