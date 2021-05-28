using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SQLite; //sqlite package
using System.IO; //to check if database already exists
namespace MyInterviewProject
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.Write("Enter your query: ");
            string query = Console.ReadLine();
            //CreateHostBuilder(args).Build().Run(); supplied code
            DatabaseManager databaseObj = new DatabaseManager();
            //var query = "SELECT * FROM Areas";//non-dinamic entry
            SQLiteCommand myCommand = new SQLiteCommand(query, databaseObj.myConnection);
            databaseObj.OpenConnection();//opens my connection
            var result = myCommand.ExecuteReader();//result holds the resulting data
            if (result.HasRows)
            {
                while (result.Read())
                {
                    Console.WriteLine("areas: {0} - name: {1} - abbr: {2} - display_id: {3} - child {4} - parent {5} - aggregation_path {6} - level {7}");//basic result to display table
                }
            }
            Console.ReadKey();
            databaseObj.CloseConnection();
        }

        /* public static IHostBuilder CreateHostBuilder(string[] args) =>
             Host.CreateDefaultBuilder(args)
                 .ConfigureWebHostDefaults(webBuilder =>
                 {
                     webBuilder.UseStartup<Startup>();
                 });
        */
    }
}

/*Steps I took to get here
 * I learned how to open and use sql database browser to GET/POST/DELETE/PUT using HTTP requests
 * Looked into and learned how to reverse engineer a .sqlite3 file to turn it into a .db file, which still did not fix the issue above
 * Learned how to connect with a sqlite3 file using the above code and a database class
 * I was able to, in a seperate project, create my own database, and use a custom window to enter sql queries and return tables, but I had to add my own data to the table and create database from scratch.
 *
 * 
 * 
 * 
 * 
 * Steps I would take from here if I had more time
 * 1. fix my current bug, where I cannot find my current area.sqlite3 file. Sadly, I cannot follow this bug using breakpoints or a debugger from what I have found.
 * 2. I was not able to figure out how to open a connection with an endpoint  http://localhost:5000/areas?q="my query", but I believe it would have been something like the following
 * 
using System;
using System.Data.SQLite;
using Morelinq;

public void ReturnTable()//called on object so no args
{
    DatabaseManager dataBaseObj = new DatabaseManager();
    string cs = @"URI=file:C:\Users\Aaron\Documents\Projects\areas.sqlite3";
    using var connection = new SQLiteConnection(cs);
    connection.Open();
    using var cmd = new SQLiteCommand(stm, connection);
    Console.Write("Enter in a query: ");
    String temp2 = Console.ReadLine();
    String temp1 = "http://localhost:5000/areas?q=";
    String myGetReq = temp1 + temp2;
    myDatabase = connection.GETtable(Get, myGetReq);//returns table
    tableToPrint = getDistinct(myDatabase);
    using SQLiteDataReader rdr = cmd.ExecuteReader(tableToPrint);//transelates table into readable form on console.
}

 * 
 * 
 * When I recieved duplicate rows on the file I made from scratch, where I added my own data, I used the following
 * code to remove duplicates
 * 
 * I would use the key word distinctby() using the Morelinq nuGet package
 * 
 * using Morelinq;
 * 
 * public DatabaseManager getdistinct(DatabaseManager myDatabase)//this argument is the database returned from the previous function, and gets passed through this function.
 * {
 *     myDatabase.DistinctBy(s => s.child)//this is better than the regular distinct method because this allows me to use a selector
 *     return myDatabase;
 * }
 * 
 * 
 * */
