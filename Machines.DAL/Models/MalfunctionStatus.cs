using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Machines.DAL.Models
{

    [Table("\"MalfunctionStatuses\"")]
    public class MalfunctionStatus
    {
        [Key]
        public int id { get; set; }
        public string name { get; set; }

    }
}
