using Machines.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Machines.BL.Models
{
    public class MalfunctionModel
    {
        public int Id { get; set; }
        public int MachineId { get; set; }
        public int StatusId { get; set; }
        public int Priority { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public string Description { get; set; }
        public double? Duration { get; set; }


        //overloading constructor in case of future implementation
        public MalfunctionModel()
        {
            CalculateDuration();
        }
        public MalfunctionModel(Malfunction dbEntity)
        {
            this.Id = dbEntity.id;
            this.MachineId = dbEntity.machineid;
            this.StatusId = dbEntity.statusid;
            this.Priority = dbEntity.priority;
            this.StartTime = dbEntity.starttime;
            this.EndTime = dbEntity.endtime;
            this.Description = dbEntity.description;

            CalculateDuration();
        }

        public void CalculateDuration()
        {
            if (EndTime.HasValue)
            {
                Duration = (EndTime - StartTime).Value.TotalMinutes;
            }
            else
            {
                Duration = null;
            }


        }
    }
}
