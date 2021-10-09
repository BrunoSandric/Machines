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

        public MalfunctionModel()
        {
            CalculateDuration();
        }
        public MalfunctionModel(Malfunction dbEntity)
        {
            this.Id = dbEntity.Id;
            this.MachineId = dbEntity.MachineId;
            this.StatusId = dbEntity.StatusId;
            this.Priority = dbEntity.Priority;
            this.StartTime = dbEntity.StartTime;
            this.EndTime = dbEntity.EndTime;
            this.Description = dbEntity.Description;

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
