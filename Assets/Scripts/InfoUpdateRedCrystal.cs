using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class InfoUpdateRedCrystal : MonoBehaviour {
    public DataManager dataManager;
    public Text textRed;
    public Text textBlue;
    public Text textPurple;
    public Text textGreen;
    public Text textYellow;
    public Text textTurquoise;
    public Text credits;

    // Use this for initialization
    void Start() {
        foreach (CrystalVO crystalVO in dataManager.listCrystalVO) {
            if (crystalVO.tag.Equals(TagConstants.CRYSTAL_RED)) {
                textRed.text = crystalVO.count.ToString();
            } else if (crystalVO.tag.Equals(TagConstants.CRYSTAL_BLUE)) {
                textBlue.text = crystalVO.count.ToString();
            } else if (crystalVO.tag.Equals(TagConstants.CRYSTAL_PURPLE)) {
                textPurple.text = crystalVO.count.ToString();
            } else if (crystalVO.tag.Equals(TagConstants.CRYSTAL_GREEN)) {
                textGreen.text = crystalVO.count.ToString();
            } else if (crystalVO.tag.Equals(TagConstants.CRYSTAL_YELLOW)) {
                textYellow.text = crystalVO.count.ToString();
            } else if (crystalVO.tag.Equals(TagConstants.CRYSTAL_TURQOUISE)) {
                textTurquoise.text = crystalVO.count.ToString();
            }
        }

        credits.text = dataManager.credits.ToString();

    }



}
