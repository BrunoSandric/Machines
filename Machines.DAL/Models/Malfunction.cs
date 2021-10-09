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
        public int id { get; set; }
        public int machineId { get; set; }
        public int statusId { get; set; }
        public int priority { get; set; }
        public DateTime startTime { get; set; }
        public DateTime? endTime { get; set; }
        public string description { get; set; }

           
    }
}
