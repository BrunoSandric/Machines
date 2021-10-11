using Npgsql;
using System;
using System.Collections.Generic;
using System.Text;

namespace Machines.DAL.Database
{
    //used to create open connection to POSTGRESQL server
    // connection closes in "using" statment where DatabaseUtils is used
    public static class DatabaseUtils
    {
        public static string ConnectionString { get; set; }

        public static NpgsqlConnection GetConnection()
        {
            var connection = new NpgsqlConnection(ConnectionString);
            connection.Open();
            return connection;
        }
    }
}
