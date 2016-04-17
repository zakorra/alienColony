using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InfoUpdater : Singleton<InfoUpdater>, IPlayerResourcesChanged {
  public DataManager dataManager;

  public Text credits;
  public Text food;
  public Text production;
  public Text research;

	protected InfoUpdater () {} // guarantee this will be always a singleton only - can't use the constructor!

  // Use this for initialization
  void Start() {
    credits.text = dataManager.credits.ToString();
    food.text = dataManager.food.ToString();
    research.text = dataManager.research.ToString();
    production.text = dataManager.production.ToString();
  }

  public void PlayerResourcesChanged() {
    credits.text = dataManager.credits.ToString();
    food.text = dataManager.food.ToString();
    research.text = dataManager.research.ToString();
    production.text = dataManager.production.ToString();
  }
}

namespace UnityEngine.EventSystems {
  public interface IPlayerResourcesChanged : IEventSystemHandler {
    void PlayerResourcesChanged();
  }
}
