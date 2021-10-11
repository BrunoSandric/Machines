using Machines.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Machines.BL.Models
{
    public class MalfunctionStatusModel
    {
        public int id { get; set; }
        public string name { get; set; }

        public MalfunctionStatusModel() { }
        public MalfunctionStatusModel(MalfunctionStatus dbEntity)
        {
            this.id = dbEntity.id;
            this.name = dbEntity.name;

        }
    }
}
