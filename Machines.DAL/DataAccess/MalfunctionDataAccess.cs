using Dapper.Contrib.Extensions;
using Machines.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Machines.DAL.DataAccess
{
    //using - Provides a convenient syntax that ensures the correct use of IDisposable objects. -- closes connection channel 
    public static class MalfunctionDataAccess
    {
        public static List<Malfunction> GetAllMalfunctions()
        {
            using (var connection = DAL.Database.DatabaseUtils.GetConnection())
            {
                return connection.GetAll<Malfunction>().ToList();
            }
        }
        public static int InsertMalfunction(Malfunction malfunction)
        {
            using (var connection = DAL.Database.DatabaseUtils.GetConnection())
            {
                return (int)connection.Insert<Malfunction>(malfunction);
            }
        }
        public static Malfunction GetMalfunction(int malfunctionId)
        {
            using (var connection = DAL.Database.DatabaseUtils.GetConnection())
            {
                return connection.Get<Malfunction>(malfunctionId);
            }
        }
        public static bool UpdateMalfunction(Malfunction malfunctionToUpdate)
        {
            using (var connection = DAL.Database.DatabaseUtils.GetConnection())
            {
                return connection.Update<Malfunction>(malfunctionToUpdate);
            }
        }
        public static bool DeleteMalfunction(Malfunction malfunctionToDelete)
        {
            using (var connection = DAL.Database.DatabaseUtils.GetConnection())
            {
                return connection.Delete<Malfunction>(malfunctionToDelete);
            }
        }
        public static bool DeleteMalfunction(int malfunctionId)
        {
            return DeleteMalfunction(new Malfunction() { id = malfunctionId });
        }
    }
}
