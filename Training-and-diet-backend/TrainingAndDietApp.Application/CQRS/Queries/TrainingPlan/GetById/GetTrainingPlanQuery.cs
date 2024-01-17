using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using TrainingAndDietApp.Application.CQRS.Responses.TrainingPlan;

namespace TrainingAndDietApp.Application.CQRS.Queries.TrainingPlan.GetById
{
    public class GetTrainingPlanQuery : IRequest<TrainingPlanResponse>
    {
        public int IdTrainingPlan { get; set; }

        public GetTrainingPlanQuery(int idTrainingPlan)
        {
            IdTrainingPlan = idTrainingPlan;
        }
    }
}
