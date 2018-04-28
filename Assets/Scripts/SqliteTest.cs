using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Data;
using Mono.Data.Sqlite;

// This script gives an example of how to access a sqlite db in a unity script
public class SqliteTest : MonoBehaviour {

	private string connectionString;

	// Use this for initialization
	void Start () {
		connectionString = "URI=file:" + Application.dataPath + "/highscore.db";
		//InsertScore ("tim", 3405);
		GetScores ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	// add data to the DB using a insert statement
	private void InsertScore(string name, int score){
		using (IDbConnection dbConnection = new SqliteConnection(connectionString)){
			dbConnection.Open ();

			using (IDbCommand dbCommand = dbConnection.CreateCommand ()) {

				string sqlQuery = "Insert into highscores(Name, Score) values(@name, @score)";


				dbCommand.Parameters.Add (new SqliteParameter("@name", name));
				dbCommand.Parameters.Add (new SqliteParameter("@score", score));
				dbCommand.CommandText = sqlQuery;
				dbCommand.ExecuteScalar();

				dbConnection.Close ();
			
			}

		}
	}

	// retreive data from the DB using a select statement
	private void GetScores(){
		using (IDbConnection dbConnection = new SqliteConnection(connectionString)){
			dbConnection.Open ();

			using (IDbCommand dbCommand = dbConnection.CreateCommand ()) {

				string sqlQuery = "SELECT * FROM HIGHSCORES";

				dbCommand.CommandText = sqlQuery;

				using (IDataReader reader = dbCommand.ExecuteReader()){

					while(reader.Read()){
						Debug.Log(reader.GetString(1) + " - " + reader.GetInt32(2));
					}
					dbConnection.Close ();
					reader.Close ();
				}
			}

		}
	}
}
 