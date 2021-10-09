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
        public int Id { get; set; }
        public string Name { get; set; }

    }
}
