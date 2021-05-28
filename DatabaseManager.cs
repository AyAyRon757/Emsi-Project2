using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SQLite; //sqlite package
using System.IO; //to check if database already exists


namespace MyInterviewProject
{
    public class DatabaseManager
    {
        public SQLiteConnection myConnection;

        public object CSSQLite { get; private set; }

        public DatabaseManager(string v)
        {
            myConnection = new SQLiteConnection("Data Source = Areas.sqlite3");

            if (!File.Exists("./bin/Debug/areas.sqlite3")) //if the file didnt already exist. should not need to use this.
            {
                System.Console.WriteLine("There was a Problem, The file was re-created");
                SQLiteConnection.CreateFile("Areas.sqlite3");

            }
        }

        public DatabaseManager()//blank constructor
        {
        }

        //This method is used to test if I already have a connection to the database
        public void OpenConnection()
        {
            if (myConnection.State != System.Data.ConnectionState.Open)
            {
                myConnection.Open();
            }
        }
        //this method closes my connection to the database
        public void CloseConnection()
        {
            if (myConnection.State != System.Data.ConnectionState.Closed)
            {
                myConnection.Close();
            }

        }


        /*execute a query that can use SELECT and then return a temperary table. Could not get this to work in this project due to unfound file error
        public DatabaseManager SELECT_QUERY(String query)
        {
            //creates new query saved in statement
            SQLiteVdbe statement = new SQLiteVdbe(this, query);
            DatabaseManager table = new DatabaseManager();
            table = new DatabaseManager("myTable");//myTable is new temp database

            // reads rows
            do { } while (ReadNextRow(statement.VirtualMachine(), table) == CSSQLite.SQLITE_ROW);
            statement.Close();
            return table;
        }

       */
    }
}
