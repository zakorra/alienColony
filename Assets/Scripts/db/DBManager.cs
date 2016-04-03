using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System;
using Mono.Data.Sqlite;

public class DBManager : MonoBehaviour {

    private static readonly string DB_NAME = "/database/aliencolony.sqlite3"; //Path to database.

    private IDbConnection dbconn;
    private string applicationPath;

    public List<CrystalVO> dbCrystalVOs { get; private set; }
    public List<ModuleVO> dbModuleVOs { get; private set; }

    public DBManager(String applicationPath) {
        this.applicationPath = applicationPath;
    }

    public void Awake() {
        string conn = "URI=file:" + Application.dataPath + DB_NAME;

        dbconn = (IDbConnection)new SqliteConnection(conn);
        dbconn.Open(); //Open connection to the database.

        dbCrystalVOs = loadPlayerCrystals();
        dbModuleVOs = loadPlayerModules();
    }

    public void OnDestroy() {
        dbconn.Close();
        dbconn = null;
    }

    private List<CrystalVO> loadPlayerCrystals() {
        List<CrystalVO> listCrystalVO = new List<CrystalVO>();

        string sqlQuery = "select * from VIEW_PLAYER_CRYSTALS";
        IDbCommand dbcmd = dbconn.CreateCommand();
        dbcmd.CommandText = sqlQuery;
        IDataReader reader = dbcmd.ExecuteReader();
        while (reader.Read()) {
            CrystalVO crystalVO = new CrystalVO();

            crystalVO.tier = reader.GetInt32(0);
            crystalVO.crystalName = reader.GetString(1);
            crystalVO.scanValue = reader.GetInt32(2);
            crystalVO.miningValue = reader.GetInt32(3);
            crystalVO.engineValue = reader.GetInt32(4);
            crystalVO.shildValue = reader.GetInt32(5);
            crystalVO.occurrency = reader.GetString(6);
            crystalVO.occurrencyFactor = reader.GetFloat(7);
            crystalVO.quality = reader.GetString(8);
            crystalVO.qualityFactor = reader.GetFloat(9);
            crystalVO.tag = reader.GetString(10);
            crystalVO.count = reader.GetInt32(11);

            listCrystalVO.Add(crystalVO);

            Debug.Log("crystalName= " + crystalVO.crystalName);
        }
        reader.Close();
        reader = null;

        dbcmd.Dispose();
        dbcmd = null;

        return listCrystalVO;
    }

    private List<ModuleVO> loadPlayerModules() {
        List<ModuleVO> listModuleVO = new List<ModuleVO>();

        string sqlQuery = "select * from VIEW_PLAYER_MODULES";
        IDbCommand dbcmd = dbconn.CreateCommand();
        dbcmd.CommandText = sqlQuery;
        IDataReader reader = dbcmd.ExecuteReader();
        while (reader.Read()) {
            ModuleVO moduleVO = new ModuleVO();

            moduleVO.name = reader.GetString(1);
            moduleVO.tier = reader.GetInt32(2);
            moduleVO.red_crystal_slots = reader.GetInt32(2);
            moduleVO.blue_crystal_slots = reader.GetInt32(2);
            moduleVO.purple_crystal_slots = reader.GetInt32(2);
            moduleVO.cost_modifier = reader.GetInt32(2);

            listModuleVO.Add(moduleVO);

            Debug.Log("moduleName= " + moduleVO);
        }

        dbcmd.Dispose();
        dbcmd = null;

        return listModuleVO;
    }



}
