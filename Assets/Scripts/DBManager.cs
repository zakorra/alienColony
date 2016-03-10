using UnityEngine;
using System.Collections;
using Mono.Data.Sqlite;
using System.Data;
using System;

public class DBManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
        string conn = "URI=file:" + Application.dataPath + "/database/aliencolony.sqlite3"; //Path to database.
        IDbConnection dbconn;
        dbconn = (IDbConnection)new SqliteConnection(conn);
        dbconn.Open(); //Open connection to the database.
        IDbCommand dbcmd = dbconn.CreateCommand();
        string sqlQuery = "select a.name, b.type from MODULE a, MODULE_TYPE b where a.type = b.id;";
        dbcmd.CommandText = sqlQuery;
        IDataReader reader = dbcmd.ExecuteReader();
        while (reader.Read()) {
            string moduleName = reader.GetString(0);
            string moduleType = reader.GetString(1);
            //int rand = reader.GetInt32(2);

            Debug.Log("moduleName= " + moduleName + "  moduleType =" + moduleType );
        }
        reader.Close();
        reader = null;
        dbcmd.Dispose();
        dbcmd = null;
        dbconn.Close();
        dbconn = null;
    }
	
	
}
