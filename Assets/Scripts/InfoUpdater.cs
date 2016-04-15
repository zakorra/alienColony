using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class InfoUpdater : MonoBehaviour {
    public DataManager dataManager;
   
    public Text credits;
    public Text food;
    public Text production;
    public Text research;

    // Use this for initialization
    void Start() {
        credits.text = dataManager.credits.ToString();
        food.text = dataManager.food.ToString();
        production.text = dataManager.production.ToString();
        research.text = dataManager.research.ToString();
    }
}
