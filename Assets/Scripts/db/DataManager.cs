﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DataManager : MonoBehaviour {
    public DBManager dbManager; 

    public List<CrystalVO> listCrystalVO { get; private set; }
    public List<ModuleVO> listModuleVO { get; private set; }

	// Use this for initialization
	void Start () {
        listCrystalVO = dbManager.getPlayerCrystals();
        listModuleVO = dbManager.gePlayerModules();
    }
	
	
}
