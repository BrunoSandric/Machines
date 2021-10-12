using Machines.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Machines.BL.Models
{
    public class MalfunctionStatusModel
    {
        public int id { get; set; } //atm 1 or 2 - check class MalfunctionStatuses
        public string name { get; set; } //atm Active or Finished - check class MalfunctionStatuses

        //overloading constructor in case of future implementation
        public MalfunctionStatusModel() { }
        public MalfunctionStatusModel(MalfunctionStatus dbEntity)
        {
            this.id = dbEntity.id;
            this.name = dbEntity.name;

        }
    }
    //changed on frontend
    public static class MalfunctionStatuses
    {
        public const int Active = 1;
        public const int Finished = 2;
    }

}
