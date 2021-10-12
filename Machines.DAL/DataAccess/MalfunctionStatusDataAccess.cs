using Dapper.Contrib.Extensions;
using Machines.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Machines.DAL.DataAccess
{
    //using - Provides a convenient syntax that ensures the correct use of IDisposable objects. -- closes connection channel 
    public static class MalfunctionStatusDataAccess
    {
        public static List<MalfunctionStatus> GetAllMalfunctionStatuses()
        {
            using (var connection = Database.DatabaseUtils.GetConnection())
            {
                return connection.GetAll<MalfunctionStatus>().ToList();
            }
        }
    }
}
