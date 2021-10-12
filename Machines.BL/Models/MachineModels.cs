using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Machines.DAL.Models;

namespace Machines.BL.Models
{
    public class MachineModel
    {
        public int Id { get; set; }
        public string Name { get; set; }


        //overloading constructor in case of future implementation
        public MachineModel() { }

        public MachineModel(Machine dbEntity)
        {
            this.Id = dbEntity.id;
            this.Name = dbEntity.name;
        }
    }
    public class MachineWithMalfunctionsModel : MachineModel
    {
        public List<MalfunctionModel> Malfunctions { get; set; } = new List<MalfunctionModel>();

        public double? AverageDuration { get; set; }


        //overloading constructor in case of future implementation
        public MachineWithMalfunctionsModel()
        {
            CalculateAverageDuration();
        }
        public MachineWithMalfunctionsModel(Machine dbEntity)
        {
            this.Id = dbEntity.id;
            this.Name = dbEntity.name;

            CalculateAverageDuration();
        }

        public void CalculateAverageDuration()
        {
            double count = 0, total = 0;
            foreach (var malfunction in this.Malfunctions)
            {
                if (malfunction.Duration != null)
                {
                    count++;
                    total += malfunction.Duration.Value;
                }
            }

            this.AverageDuration = null;
            if (count > 0)
            {
                this.AverageDuration = total / count;
            }
        }
    }
}
