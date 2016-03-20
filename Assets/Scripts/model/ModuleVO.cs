using System.Collections;

public class ModuleVO  {
    public string name { get; set; }
    public int tier { get; set; }
    public int red_crystal_slots { get; set; }
    public int blue_crystal_slots { get; set; }
    public int purple_crystal_slots { get; set; }
    public float cost_modifier { get; set; }

    public string getDropBoxText() {
        string optionText = System.String.Format("{0} - T[{1}], R[{2}], B[{3}], P[{4}]", name, tier, red_crystal_slots, blue_crystal_slots, purple_crystal_slots);
        return optionText;
    }
}
