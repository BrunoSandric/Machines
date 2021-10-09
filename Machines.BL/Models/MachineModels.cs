﻿using System;
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

        public MachineModel() { }

        public MachineModel(Machine dbEntity)
        {
            this.Id = dbEntity.Id;
            this.Name = dbEntity.Name;
        }
    }
    public class MachineWithMalfunctionsModel : MachineModel
    {
        public List<MalfunctionModel> Malfunctions { get; set; } = new List<MalfunctionModel>();

        public double? AverageDuration { get; set; }

        public MachineWithMalfunctionsModel()
        {
            CalculateAverageDuration();
        }
        public MachineWithMalfunctionsModel(Machine dbEntity)
        {
            this.Id = dbEntity.Id;
            this.Name = dbEntity.Name;

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
