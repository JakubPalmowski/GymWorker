using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingAndDietApp.Common.DTOs.TrainingPlan
{
    public class CreateTrainingPlanDto
    {
        public string Name { get; set; }
        public string CustomName { get; set; }
        public string Type { get; set; }

        public DateTime StartDate { get; set; }

        public int NumberOfWeeks { get; set; }

        public int IdTrainer { get; set;}
    }
}
