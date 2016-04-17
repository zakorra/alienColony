using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections.Generic;

public class InfoUpdater : Singleton<InfoUpdater>, IPlayerResourcesChanged {
  public DataManager dataManager;

  public GameObject slotsBuildPipeline;

  public Text credits;
  public Text food;
  public Text production;
  public Text research;

  private GameObject objBuildModule;
  private List<GameObject> currentBuildObjects;

  protected InfoUpdater () {} // guarantee this will be always a singleton only - can't use the constructor!

  // Use this for initialization
  void Start() {
    // Init/Cache Resources
    objBuildModule = Resources.Load("crystals/crystalBlue") as GameObject;

    credits.text = dataManager.credits.ToString();
    food.text = dataManager.food.ToString();
    research.text = dataManager.research.ToString();
    production.text = dataManager.production.ToString();

    currentBuildObjects = new List<GameObject>();
  }

  public void PlayerResourcesChanged() {
    credits.text = dataManager.credits.ToString();
    food.text = dataManager.food.ToString();
    research.text = dataManager.research.ToString();
    production.text = dataManager.production.ToString();

    updateBuildPipeline();
  }

  private void updateBuildPipeline() {
    foreach (GameObject aGameObject in currentBuildObjects){
      Destroy(aGameObject);
    }
    foreach (RunModuleVO runModuleVO in dataManager.runModuleVOBuildPipeline) {
      GameObject newBuildSlot = Instantiate(slotsBuildPipeline) as GameObject;

      currentBuildObjects.Add(newBuildSlot);
      addBuildObject(objBuildModule, newBuildSlot.transform, runModuleVO);
    }

  }

  private void addBuildObject(GameObject buildObject, Transform slotTransform, RunModuleVO runModuleVO) {
    GameObject buildObjectNew = Instantiate(buildObject) as GameObject;
    currentBuildObjects.Add(buildObjectNew);

    buildObjectNew.transform.SetParent(slotTransform.transform);
    buildObjectNew.transform.position = slotTransform.transform.position;

    RunModuleVO newRunModuleVO = buildObjectNew.gameObject.AddComponent<RunModuleVO>();
    newRunModuleVO.cloneFromCrystalVO(runModuleVO);

  }
}

namespace UnityEngine.EventSystems {
  public interface IPlayerResourcesChanged : IEventSystemHandler {
    void PlayerResourcesChanged();
  }
}
