using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Mono.Data.Sqlite;
using System.Data;
using System;

public class StreamingDatabaseManager
{
    static SqliteConnection dbconn = null;
    static SqliteCommand dbcmd = null;
    static SqliteDataReader reader = null;

    /// <summary>
    /// Restores the db connection to unconnected settings
    /// </summary>
    static void RestoreConnection()
    {
        if (reader != null)
            reader.Close();
        reader = null;
        if (dbcmd != null)
            dbcmd.Dispose();
        dbcmd = null;
        if (dbconn != null)
            dbconn.Close();
        dbconn = null;
    }

    public static void UpdateLeagueTable(int leagueID, string tableString)
    {            
        string query = string.Format("UPDATE League SET Ranking = '{0}' WHERE ID = '{1}' ;", tableString,leagueID);
        MakeNonSelectionQuery(query);
    }
	
    private static void MakeNonSelectionQuery(string sqlQuery)
    {
        using (SqliteConnection c = new SqliteConnection("URI=file:" + Application.dataPath + "/StreamingAssets/db.db"))
        {
            c.Open();
            using (SqliteCommand cmd = new SqliteCommand(sqlQuery, c))
            {
                cmd.ExecuteNonQuery();
            }
        }
    }

    public static int GetPlayersCount()
    {
        string query = string.Format("SELECT COUNT(*) FROM PlayerInfo;");
        int ret = -1;
        string conn = "URI=file:" + Application.dataPath + "/StreamingAssets/UnityFirstTry.db"; //Path to database.
        using (SqliteConnection c = new SqliteConnection(conn))
        {
            c.Open();
            using (SqliteCommand cmd = new SqliteCommand(query, c))
            {
                using (SqliteDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        ret = reader.GetInt32(0);
                    }
                }
            }
        }
        return ret;
    }
 
       

    


}
