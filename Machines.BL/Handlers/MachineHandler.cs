using Dapper;
using Dapper.Contrib.Extensions;
using Machines.BL.Models;
using Machines.DAL.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace Machines.BL.Handlers
{
    public static class MachineHandler
    {
        public static List<MachineWithMalfunctionsModel> GetAllMachines()
        {
            var dbMachines = MachineDataAccess.GetAllMachines();
            var machines = new List<MachineWithMalfunctionsModel>();
            foreach (var dbItem in dbMachines)
            {
                machines.Add(new MachineWithMalfunctionsModel(dbItem));
            }

            var dbMalfunctions = MalfunctionDataAccess.GetAllMalfunctions();
            var malfunctions = new List<MalfunctionModel>();
            foreach (var dbItem in dbMalfunctions)
            {
                malfunctions.Add(new MalfunctionModel(dbItem));
            }

            foreach (var machine in machines)
            {

                machine.Malfunctions = new List<MalfunctionModel>();
                foreach(var malfunction in malfunctions)
                {
                    if (malfunction.MachineId == machine.Id)
                    {
                        machine.Malfunctions.Add(malfunction);
                    }
                }

                machine.CalculateAverageDuration();
            }

            return machines;
        }

        public static ApiResponseModel GetSingleMachine(int machineId)
        {
            var toReturn = new ApiResponseModel();
            var machine = MachineDataAccess.GetMachine(machineId);

            toReturn.Payload = machine;

            if (machine == null)
            {
                toReturn.StatusCode = HttpStatusCode.NotFound;
            }

            return toReturn;
        }
    }
}
