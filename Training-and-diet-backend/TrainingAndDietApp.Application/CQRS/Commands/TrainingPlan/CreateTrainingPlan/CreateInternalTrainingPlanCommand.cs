using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace TrainingAndDietApp.Application.CQRS.Commands.TrainingPlan.CreateTrainingPlan
{
    public class CreateInternalTrainingPlanCommand : IRequest<CreateTrainingPlanResponse>
    {
        public CreateInternalTrainingPlanCommand(int idTrainer, CreateTrainingPlanCommand createTrainingPlanCommand)
        {
            IdTrainer = idTrainer;
            CreateTrainingPlanCommand = createTrainingPlanCommand;
        }

        public int IdTrainer { get; set; }
        public CreateTrainingPlanCommand CreateTrainingPlanCommand { get; set; }
    }

    public class CreateTrainingPlanCommand
    {
        public string Name { get; set; }
        public string CustomName { get; set; }
        public string Type { get; set; }
        public DateTime StartDate { get; set; }
        public int NumberOfWeeks { get; set; }
    }




    public class CreateTrainingPlanResponse
    {
        public int IdTrainingPlan { get; set; }
    }
}
