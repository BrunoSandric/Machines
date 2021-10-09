using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Machines.DAL.Models
{
    [Table("\"Malfunctions\"")]
    public class Malfunction
    {
        [Key]
        public int Id { get; set; }
        public int MachineId { get; set; }
        public int StatusId { get; set; }
        public int Priority { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public string Description { get; set; }

           
    }
}
