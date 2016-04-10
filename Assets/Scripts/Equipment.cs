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


    // Use this for initialization
    void Start () {
        HasChanged();
	}
	
    public void HasChanged()
    {
        moduleText.text = "";

        if (isEquipment) {
            // get all crystals from the different colored slots
            List<CrystalVO> crystals = new List<CrystalVO>();

            foreach(Transform crystalSots in slots) {
                foreach(Transform slotTransform in crystalSots) {
                    GameObject item = slotTransform.GetComponent<Slot>().item;
                    if(item) {
                        CrystalVO crystalVO = item.GetComponent<CrystalVO>();
                        crystals.Add(crystalVO);
                    }
                }
            } // eof crystalSlots

            string moduleInfoText = calcModuleValues(crystals);
            moduleText.text = moduleInfoText;
        }
    }

    private string calcModuleValues(List<CrystalVO> crystals) {
        StringBuilder sb = new StringBuilder();

		float manufactoringCost = 0;
		float manufactoringTime = 0;

        float scanValue = 0;
        float miningValue = 0;
        float engineValue = 0;
        float shildValue = 0;

        foreach(CrystalVO crystalVO in crystals) {
			manufactoringCost += crystalVO.costFactor;
			manufactoringTime += crystalVO.costFactor * 1.5f;

            scanValue += (float)crystalVO.scanValue * (crystalVO.qualityFactor + crystalVO.occurrencyFactor);
            miningValue += (float)crystalVO.miningValue * (crystalVO.qualityFactor + crystalVO.occurrencyFactor);
            engineValue += (float)crystalVO.engineValue * (crystalVO.qualityFactor + crystalVO.occurrencyFactor);
            shildValue += (float)crystalVO.shildValue * (crystalVO.qualityFactor + crystalVO.occurrencyFactor);
        }
        float crystalCount = (float)crystals.Count;

        if(crystalCount > 1) {
            scanValue /= crystalCount / 1.5f;
            miningValue /= crystalCount / 1.5f;
            engineValue /= crystalCount / 1.5f;
            shildValue /= crystalCount / 1.5f;
        }

		float scanValueDec = (float) Math.Round((Decimal)scanValue, 3, MidpointRounding.AwayFromZero);
		float miningValueDec = (float) Math.Round((Decimal)miningValue, 3, MidpointRounding.AwayFromZero);
		float engineValueDec = (float) Math.Round((Decimal)engineValue, 3, MidpointRounding.AwayFromZero);
		float shildValueDec = (float) Math.Round((Decimal)shildValue, 3, MidpointRounding.AwayFromZero);

		float costValue = (scanValue + miningValue + engineValue + shildValue) * 100f * manufactoringCost;
		float manuTimeValue = costValue * manufactoringTime * 0.0015f;

		sb.Append ("Manu. Cost:\t{0,-150:0.00}");
		sb.Append ("\n");
		sb.Append ("Manu Time:\t{1,-150:0.00}");
		sb.Append ("\n");

        addToolTipParameter(sb, 2, "Module");
        addToolTipParameter(sb, 3, "Scan");
        addToolTipParameter(sb, 4, "Mining");
        addToolTipParameter(sb, 5, "Engine");
        addToolTipParameter(sb, 6, "Shield");



		return string.Format(sb.ToString(), costValue, manuTimeValue, null, miningValueDec, scanValueDec, miningValue, engineValueDec, shildValueDec);
    }

    private void addToolTipParameter(StringBuilder sb, int index, string fieldName) {
		if(index > 2) {
            sb.Append("\n\t");
        }
        if(fieldName != null) {
            sb.Append(fieldName);
            sb.Append(":\t");

        }
        if(index == 2) {
            sb.Append("{" + index + ",-50}");
        } else {
            sb.Append("{" + index + ",-50:0.00}");
        }
    }


}

namespace UnityEngine.EventSystems
{
    public interface IHasChanged : IEventSystemHandler
    {
        void HasChanged();
    }
}