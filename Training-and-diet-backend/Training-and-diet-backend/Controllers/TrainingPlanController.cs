using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Numerics;
using Training_and_diet_backend.DTOs.TraineeExercise;
using Training_and_diet_backend.DTOs.TrainingPlan;
using Training_and_diet_backend.Models;
using Training_and_diet_backend.Services;
using TrainingAndDietApp.Application.Commands.TrainingPlan;
using TrainingAndDietApp.Application.Queries.Meal;
using TrainingAndDietApp.Application.Queries.TrainingPlan;
using TrainingAndDietApp.BLL.EntityModels;
using TrainingAndDietApp.BLL.Models;
using TrainingAndDietApp.BLL.Services;
using TrainingAndDietApp.Common.DTOs.TrainingPlan;
using TrainingAndDietApp.DAL.Models;
using TrainingAndDietApp.Domain.Entities;

namespace Training_and_diet_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrainingPlanController : ControllerBase
    {
        private readonly IMediator _mediator;
        public TrainingPlanController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet("{planId}")]
        public async Task<IActionResult> GetTrainingPlanById(int planId)
        {
            var query = new GetTrainingPlanQuery(planId);

            var result = await _mediator.Send(query);
            return Ok(result);

        }
        [HttpGet("{idTrainer}/trainingPlans")]
        public async Task<IActionResult> GetTrainerTrainingPlans(int idTrainer)
        {
            var query = new GetTrainerTrainingPlansQuery(idTrainer);
            var result = await _mediator.Send(query);

            return Ok(result);

        }

        [HttpPost] 
        public async Task<IActionResult> PostTrainingPlan(CreateTrainingPlanCommand trainingPlan)
        {
            var result = await _mediator.Send(trainingPlan);
            var locationUri = $"api/trainingPlan/{result.IdTrainingPlan}";

            return Created(locationUri, trainingPlan);
        }


        
    }
}
