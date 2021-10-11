using Dapper.Contrib.Extensions;
using Machines.BL.Models;
using Machines.DAL.DataAccess;
using Machines.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Machines.BL.Handlers
{
    public static class MalfunctionStatusHandler
    {

        public static List<MalfunctionStatusModel> GetAllMalfunctionStatuses()
        {
            var dbMalfunctionStatuses = MalfunctionStatusDataAccess.GetAllMalfunctionStatuses();
            var malfunctionStatuses = new List<MalfunctionStatusModel>();
            foreach (var dbItem in dbMalfunctionStatuses)
            {
                malfunctionStatuses.Add(new MalfunctionStatusModel(dbItem));
            }

            return malfunctionStatuses;
        }
    }
    }
}
