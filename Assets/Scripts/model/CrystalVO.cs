
using UnityEngine;
using System.Text;

public class CrystalVO : MonoBehaviour
{

	public int tier { get; set; }
    public string crystalName { get; set; }
    public string occurrency { get; set; }
    public float occurrencyFactor { get; set; }
    public string quality { get; set; }
    public float qualityFactor { get; set; }
    public int scanValue { get; set; } 
    public int miningValue { get; set; }
    public int engineValue { get; set; }
    public int shildValue { get; set; }
    public string tag { get; set; }
    public int count { get; set; }
	public float costFactor { get ; set; }

    public void cloneFromCrystalVO(CrystalVO crystalVOIn)
    {
        tier = crystalVOIn.tier;
        crystalName = crystalVOIn.crystalName;
        occurrency = crystalVOIn.occurrency;
        occurrencyFactor = crystalVOIn.occurrencyFactor;
        quality = crystalVOIn.quality;
        qualityFactor = crystalVOIn.qualityFactor;
        scanValue = crystalVOIn.scanValue;
        miningValue = crystalVOIn.miningValue;
        engineValue = crystalVOIn.engineValue;
        shildValue = crystalVOIn.shildValue;
        tag = crystalVOIn.tag;
        count = crystalVOIn.count;
		costFactor = crystalVOIn.costFactor;
    }

    public string getToolTipText()
    {
        StringBuilder sb = new StringBuilder();
        int i = 0;


        addToolTipParameter(sb, i++, null);
        addToolTipParameter(sb, i++, "Occurrency");
        addToolTipParameter(sb, i++, "Quality");
        addToolTipParameter(sb, i++, "Scan");
        addToolTipParameter(sb, i++, "Mining");
        addToolTipParameter(sb, i++, "Engine");
        addToolTipParameter(sb, i++, "Shild");

        return string.Format(sb.ToString(), crystalName, occurrency, quality, scanValue, miningValue, engineValue, shildValue);
    }

    private void addToolTipParameter(StringBuilder sb, int index, string fieldName) {
        if (sb.Length > 0) {
            sb.Append("\n\t");
        }
        if (fieldName != null) {
            sb.Append(fieldName);
            sb.Append(":\t");
            if (fieldName.Length < 8) {
                sb.Append("\t");
            }
        }
        sb.Append("{" + index + "}");
    }
}
