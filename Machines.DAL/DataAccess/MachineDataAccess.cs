using Dapper;
using Dapper.Contrib.Extensions;
using Machines.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Machines.DAL.DataAccess
{
    //using - Provides a convenient syntax that ensures the correct use of IDisposable objects. -- closes connection channel 
    public static class MachineDataAccess
    {
        public static List<Machine> GetAllMachines()
        {
            using (var connection = Database.DatabaseUtils.GetConnection())
            {
                return connection.GetAll<Machine>().ToList();
            }
        }
        public static int InsertMachine(Machine machine)
        {
            using (var connection = Database.DatabaseUtils.GetConnection())
            {
                return (int)connection.Insert<Machine>(machine);
            }
        }
        public static Machine GetMachine(int machineId)
        {
            using (var connection = Database.DatabaseUtils.GetConnection())
            {
                return connection.Get<Machine>(machineId);
            }
        }
        public static bool UpdateMachine(Machine machineToUpdate)
        {
            using (var connection = Database.DatabaseUtils.GetConnection())
            {
                return connection.Update<Machine>(machineToUpdate);
            }
        }
        public static bool DeleteMachine(Machine machine)
        {
            using (var connection = Database.DatabaseUtils.GetConnection())
            {
                return connection.Delete<Machine>(machine);
            }
        }
        public static bool DeleteMachine(int machineId)
        {
            return DeleteMachine(new Machine() { id = machineId });
        }
        public static List<Malfunction> GetAllMachineMalfunctions(int machineId)
        {
            using (var connection = Database.DatabaseUtils.GetConnection())
            {
                var sql = "SELECT * FROM public.\"Malfunctions\" WHERE machineid = @MachineId";

                return connection.Query<Malfunction>(sql, new { MachineId = machineId }).ToList();
            }
        }
        public static int InsertMachineMalfunction(int machineId, Malfunction machineMalfuntion)
        {
            using (var connection = Database.DatabaseUtils.GetConnection())
            {
                machineMalfuntion.machineid = machineId; 

                return (int)connection.Insert<Malfunction>(machineMalfuntion);
            }
        }

    }
}
