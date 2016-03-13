using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class StartGame : MonoBehaviour {
    public DBManager dbManager;

    private List<CrystalVO> listCrystalVO;

	// Use this for initialization
	void Start () {
        listCrystalVO = dbManager.getCrystals();
    }
	
	
}
