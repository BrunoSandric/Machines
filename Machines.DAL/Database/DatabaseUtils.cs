using Npgsql;
using System;
using System.Collections.Generic;
using System.Text;

namespace Machines.DAL.Database
{
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
