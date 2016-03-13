using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System;
using Mono.Data.Sqlite;

public class DBManager : MonoBehaviour {

    private readonly string DB_NAME = "/database/aliencolony.sqlite3"; //Path to database.

    // Use this for initialization
    void Start () {
    }
	
    public List<CrystalVO> getCrystals() {
        List<CrystalVO> listCrystalVO = new List<CrystalVO>();

        string conn = "URI=file:" + Application.dataPath + DB_NAME;

        IDbConnection dbconn;
        dbconn = (IDbConnection)new SqliteConnection(conn);
        dbconn.Open(); //Open connection to the database.
        IDbCommand dbcmd = dbconn.CreateCommand();
        string sqlQuery = "select * from VIEW_PLAYER_CRYSTALS";
        dbcmd.CommandText = sqlQuery;
        IDataReader reader = dbcmd.ExecuteReader();
        while (reader.Read()) {
            CrystalVO crystalVO = new CrystalVO();

            int tier = reader.GetInt32(0);
            string crystalName = reader.GetString(1);
            int scanValue = reader.GetInt32(2);
            int miningValue = reader.GetInt32(3);
            int engineValue = reader.GetInt32(4);
            int shildValue = reader.GetInt32(5);
            string occurrency = reader.GetString(6);
            string quality = reader.GetString(7);
            string tag = reader.GetString(8);

            crystalVO.tier = tier;
            crystalVO.crystalName = crystalName;
            crystalVO.scanValue = scanValue;
            crystalVO.miningValue = miningValue;
            crystalVO.engineValue = engineValue;
            crystalVO.shildValue = shildValue;
            crystalVO.occurrency = occurrency;
            crystalVO.quality = quality;
            crystalVO.tag = tag;

            listCrystalVO.Add(crystalVO);

            Debug.Log("crystalName= " + crystalName);
        }
        reader.Close();
        reader = null;
        dbcmd.Dispose();
        dbcmd = null;
        dbconn.Close();
        dbconn = null;

        return listCrystalVO;
    }
	
}
