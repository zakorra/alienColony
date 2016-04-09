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

        float scanValue = 0;
        float miningValue = 0;
        float engineValue = 0;
        float shildValue = 0;

        foreach(CrystalVO crystalVO in crystals) {
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

        Decimal scanValueDec = Math.Round((Decimal)scanValue, 3, MidpointRounding.AwayFromZero);
        Decimal miningValueDec = Math.Round((Decimal)miningValue, 3, MidpointRounding.AwayFromZero);
        Decimal engineValueDec = Math.Round((Decimal)engineValue, 3, MidpointRounding.AwayFromZero);
        Decimal shildValueDec = Math.Round((Decimal)shildValue, 3, MidpointRounding.AwayFromZero);

        addToolTipParameter(sb, 0, "Module");
        addToolTipParameter(sb, 1, "Scan");
        addToolTipParameter(sb, 2, "Mining");
        addToolTipParameter(sb, 3, "Engine");
        addToolTipParameter(sb, 4, "Shield");



        return string.Format(sb.ToString(), "", scanValueDec, miningValueDec, engineValueDec, shildValue);
    }

    private void addToolTipParameter(StringBuilder sb, int index, string fieldName) {
        if(sb.Length > 0) {
            sb.Append("\n\t");
        }
        if(fieldName != null) {
            sb.Append(fieldName);
            sb.Append(":\t");

        }
        if(index == 0) {
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