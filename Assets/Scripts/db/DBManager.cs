using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System;
using Mono.Data.Sqlite;
using System.Text;

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
    if (dbconn != null) {
      dbconn.Close();
      dbconn = null;
    }
  }

  public void removeCrystalsFromInventory(List<CrystalVO> crystals) {
    List<CrystalVO> crystalsToDelete = new List<CrystalVO>();
    foreach (CrystalVO dbCrystal in dbCrystalVOs) {
      foreach (CrystalVO crystal in crystals) {
        if (dbCrystal.id == crystal.id) {
          dbCrystal.count -= 1;
        }
      }
    }

  }

  private List<CrystalVO> loadPlayerCrystals() {
    List<CrystalVO> listCrystalVO = new List<CrystalVO>();

    string sqlQuery = "select * from VIEW_PLAYER_CRYSTALS";
    IDbCommand dbcmd = dbconn.CreateCommand();
    dbcmd.CommandText = sqlQuery;
    IDataReader reader = dbcmd.ExecuteReader();
    while (reader.Read()) {
      CrystalVO crystalVO = new CrystalVO();

      crystalVO.id = reader.GetInt32(0);
      crystalVO.tier = reader.GetInt32(1);
      crystalVO.crystalName = reader.GetString(2);
      crystalVO.scanValue = reader.GetInt32(3);
      crystalVO.miningValue = reader.GetInt32(4);
      crystalVO.engineValue = reader.GetInt32(5);
      crystalVO.shildValue = reader.GetInt32(6);
      crystalVO.occurrency = reader.GetString(7);
      crystalVO.occurrencyFactor = reader.GetFloat(8);
      crystalVO.quality = reader.GetString(9);
      crystalVO.qualityFactor = reader.GetFloat(10);
      crystalVO.tag = reader.GetString(11);
      crystalVO.count = reader.GetInt32(12);
      crystalVO.costFactor = reader.GetFloat(13);

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

      moduleVO.id = reader.GetInt32(0);
      moduleVO.name = reader.GetString(1);
      moduleVO.tier = reader.GetInt32(2);
      moduleVO.red_crystal_slots = reader.GetInt32(3);
      moduleVO.blue_crystal_slots = reader.GetInt32(4);
      moduleVO.purple_crystal_slots = reader.GetInt32(5);
      moduleVO.cost_modifier = reader.GetFloat(6);

      listModuleVO.Add(moduleVO);

      Debug.Log("moduleName= " + moduleVO);
    }

    dbcmd.Dispose();
    dbcmd = null;

    return listModuleVO;
  }

  public void store(RunModuleVO runModuleVo) {
    StringBuilder sb = new StringBuilder();

    sb.Append("insert into RUN_MODULE (fkey_module, SCAN_VALUE, MINING_VALUE, EINGINE_VALUE, SHILD_VALUE, COST_VALUE, MANU_TIME_VALUE) values ({0}, '{1}', '{2}', '{3}', '{4}', '{5}', '{6}');");
    string sql = string.Format(sb.ToString(), runModuleVo.moduleId, runModuleVo.scanValue, runModuleVo.miningValue, runModuleVo.engineValue, runModuleVo.shildValue, runModuleVo.costValue, runModuleVo.manuTimeValue);

    IDbCommand dbcmd = dbconn.CreateCommand();
    dbcmd.CommandText = sql;
    dbcmd.ExecuteNonQuery();
  }

}
