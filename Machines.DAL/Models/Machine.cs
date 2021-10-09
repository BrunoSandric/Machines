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
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
