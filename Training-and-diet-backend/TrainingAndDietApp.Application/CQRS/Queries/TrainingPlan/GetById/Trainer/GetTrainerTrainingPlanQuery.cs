using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using TrainingAndDietApp.Application.CQRS.Responses.TrainingPlan;

namespace TrainingAndDietApp.Application.CQRS.Queries.TrainingPlan.GetById.Trainer
{
    public class GetTrainerTrainingPlanQuery : IRequest<TrainerTrainingPlanResponse>
    {
        public int IdTrainingPlan { get; set; }
        public int LoggedUser { get; set; }

        public GetTrainerTrainingPlanQuery(int idTrainingPlan, int loggedUser)
        {
            IdTrainingPlan = idTrainingPlan;
            LoggedUser = loggedUser;
        }

    }

}
