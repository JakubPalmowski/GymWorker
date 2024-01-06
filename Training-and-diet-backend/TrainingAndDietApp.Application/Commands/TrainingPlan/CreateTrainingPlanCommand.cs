using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace TrainingAndDietApp.Application.Commands.TrainingPlan
{
    public class CreateTrainingPlanCommand : IRequest<CreateTrainingPlanResponse>
    {
        public string Name { get; set; }
        public string CustomName { get; set; }
        public string Type { get; set; }

        public DateTime StartDate { get; set; }

        public int NumberOfWeeks { get; set; }

        public int IdTrainer { get; set; }
    }

    public class CreateTrainingPlanResponse
    {
        public int IdTrainingPlan { get; set;}
    }
}
