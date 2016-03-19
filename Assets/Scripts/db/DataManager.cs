using UnityEngine;
using System.Collections.Generic;

public class DataManager : MonoBehaviour {
    public DBManager dbManager;

    public List<CrystalVO> listCrystalVO { get; private set; }
    public List<ModuleVO> listModuleVO { get; private set; }

    public int credits { get; set; }

    public void Awake() {
        // Init: read data from DB
        listCrystalVO = dbManager.dbCrystalVOs;
        listModuleVO = dbManager.dbModuleVOs;

        credits = 432456;
    }

    // Use this for initialization
    void Start() {
        
    }

    
}
