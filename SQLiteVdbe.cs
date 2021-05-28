using System;

namespace MyInterviewProject
{
    internal class SQLiteVdbe
    {
        private DatabaseManager databaseManager;
        private string query;

        public SQLiteVdbe(DatabaseManager databaseManager, string query)
        {
            this.databaseManager = databaseManager;
            this.query = query;
        }
        /*
        internal Vdbe VirtualMachine()
        {
            throw new NotImplementedException();
        }
        */
        internal void Close()
        {
            throw new NotImplementedException();
        }
    }
}