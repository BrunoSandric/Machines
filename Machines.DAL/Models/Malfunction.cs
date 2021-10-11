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
        public int machineid { get; set; }
        public int statusid { get; set; }
        public int priority { get; set; }
        public DateTime starttime { get; set; }
        public DateTime? endtime { get; set; }
        public string description { get; set; }

           
    }
}
