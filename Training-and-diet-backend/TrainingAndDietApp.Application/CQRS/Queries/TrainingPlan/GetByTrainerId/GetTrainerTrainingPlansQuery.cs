﻿using MediatR;

namespace TrainingAndDietApp.Application.CQRS.Queries.TrainingPlan.GetByTrainerId;

public record GetTrainerTrainingPlansQuery(int IdTrainer) : IRequest<IEnumerable<GetTrainerTrainingPlansResponse>>
{
}

public class GetTrainerTrainingPlansResponse
{
    public int IdTrainingPlan { get; set; }
    public string Name { get; set; }
    public string CustomName { get; set; }
    public DateTime EndDate { get; set;}
}