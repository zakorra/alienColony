using UnityEngine;
using System.Collections.Generic;
using System;

public class DataManager : MonoBehaviour {
    public DBManager dbManager;

    public List<CrystalVO> listCrystalVO { get; private set; }
    public List<ModuleVO> listModuleVO { get; private set; }

    public int credits { get; set; }
    public int food { get; set; }
    public int production { get; set; }
    public int research { get; set; }

    public void Awake() {
        // Init: read data from DB
        listCrystalVO = dbManager.dbCrystalVOs;
        listModuleVO = dbManager.dbModuleVOs;

        research = 2;
        production = 10;
        food = 100;
        credits = 432456;
    }

    // Use this for initialization
    void Start() {
        
    }

    public void store(RunModuleVO runModuleVo) {
        dbManager.store(runModuleVo);
    }

    internal void removeCrystalsFromInventory(List<CrystalVO> crystals) {
        dbManager.removeCrystalsFromInventory(crystals);
        listCrystalVO = dbManager.dbCrystalVOs;
    }
}
