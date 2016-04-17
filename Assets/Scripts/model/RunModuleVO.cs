using UnityEngine;
using System.Text;

public class RunModuleVO : MonoBehaviour {
  public int moduleId { get; set; }
  public float scanValue { get; set; }
  public float miningValue { get; set; }
  public float engineValue { get; set; }
  public float shildValue { get; set; }
  public float costValue { get; set; }
  public float manuTimeValue { get; set; }
  public void cloneFromCrystalVO(RunModuleVO runModuleVOIn) {


    this.moduleId = runModuleVOIn.moduleId;
    this.scanValue = runModuleVOIn.scanValue;
    this.miningValue = runModuleVOIn.miningValue;
    this.engineValue = runModuleVOIn.engineValue;
    this.shildValue = runModuleVOIn.shildValue;
    this.costValue = runModuleVOIn.costValue;
    this.manuTimeValue = runModuleVOIn.manuTimeValue;
  }

  public string getToolTipText() {
    StringBuilder sb = new StringBuilder();
    int i = 0;


    addToolTipParameter(sb, i++, null);
    addToolTipParameter(sb, i++, "Produktion");
    addToolTipParameter(sb, i++, "Scan");
    addToolTipParameter(sb, i++, "Mining");
    addToolTipParameter(sb, i++, "Engine");
    addToolTipParameter(sb, i++, "Shild");

		return string.Format(sb.ToString(), "module", manuTimeValue, scanValue, miningValue, engineValue, shildValue);
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
