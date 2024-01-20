using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingAndDietApp.Application.CQRS.Responses.TrainingPlan
{
    public class TrainingPlanResponse
    {
        public int IdTrainingPlan { get; set; }
        public int IdPupil { get; set; }
        public string PupilName { get; set; }
        public string PupilLastName { get; set; }
        public int IdTrainer { get; set; }
        public string Name { get; set; }
        public string CustomName { get; set; }
        public string Type { get; set; }
        public DateTime StartDate { get; set; }
        public int NumberOfWeeks { get; set; }

    }
}
