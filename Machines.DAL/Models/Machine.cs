using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Machines.DAL.Models
{
    [Table("\"Machines\"")]
    public class Machine
    {
        [Key]
        public int id { get; set; }
        public string name { get; set; }
    }
}
