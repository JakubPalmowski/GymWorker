using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Training_and_diet_backend.DTOs.MealDto;
using Training_and_diet_backend.DTOs.TraineeExercise;
using Training_and_diet_backend.DTOs.TrainingPlan;
using Training_and_diet_backend.DTOs.User;
using Training_and_diet_backend.Models;
using TrainingAndDietApp.Application.Commands.Exercise;
using TrainingAndDietApp.Application.Commands.Meal;
using TrainingAndDietApp.Application.Commands.TraineeExercises;
using TrainingAndDietApp.Application.Commands.TrainingPlan;
using TrainingAndDietApp.Application.Handlers.TrainingPlan;
using TrainingAndDietApp.Application.Queries.TrainingPlan;
using TrainingAndDietApp.Application.Queries.User;
using TrainingAndDietApp.Application.Responses;
using TrainingAndDietApp.Application.Responses.Diet;
using TrainingAndDietApp.Application.Responses.Exercise;
using TrainingAndDietApp.Application.Responses.Meal;
using TrainingAndDietApp.Application.Responses.Pupil;
using TrainingAndDietApp.Application.Responses.TrainingPlan;
using TrainingAndDietApp.BLL.EntityModels;
using TrainingAndDietApp.BLL.Models;
using TrainingAndDietApp.Common.DTOs.Diet;
using TrainingAndDietApp.Common.DTOs.Exercise;
using TrainingAndDietApp.Common.DTOs.Gym;
using TrainingAndDietApp.Common.DTOs.TrainingPlan;
using TrainingAndDietApp.Common.DTOs.User;
using TrainingAndDietApp.DAL.EntityModels;
using TrainingAndDietApp.DAL.Models;
using TrainingAndDietApp.Domain.Entities;
using Gym = Training_and_diet_backend.Models.Gym;
using GymResponse = TrainingAndDietApp.Application.Responses.Gym.GymResponse;
using TrainingPlan = TrainingAndDietApp.Domain.Entities.TrainingPlan;


namespace Training_and_diet_backend
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<TrainingPlanEntity, TrainingPlan>();

            CreateMap<Diet, DietEntity>();
            CreateMap<DietEntity, DietDto>();

            CreateMap<Gym, GymEntity>().ForMember(dest => dest.CityName, opt => opt.MapFrom(src => src.Address.City))
                .ForMember(dest => dest.Street, opt => opt.MapFrom(src => src.Address.Street));


            CreateMap<GymEntity, GymDto>();


            CreateMap<MealDto, MealEntity>().ForMember(dest => dest.IdMeal, opt => opt.Ignore());
            CreateMap<MealEntity, Meal>().ForMember(dest => dest.IdMeal, opt => opt.Ignore());



            CreateMap<ExerciseDto, TrainingAndDietApp.Domain.Entities.Exercise>().ForMember(dest => dest.IdExercise, opt => opt.Ignore());
            CreateMap<Exercise, ExerciseEntity>();
            CreateMap<ExerciseEntity, ExerciseNameDto>();

            //post
            CreateMap<ExerciseDto, ExerciseEntity>().ForMember(dest => dest.IdExercise, opt => opt.Ignore());
            CreateMap<ExerciseEntity, TrainingAndDietApp.Domain.Entities.Exercise>().ForMember(dest => dest.IdExercise, opt => opt.Ignore());



            CreateMap<Exercise, ExerciseNameDto>();

            CreateMap<TrainingPlan, TrainingPlanNameDto>();
            CreateMap<Meal, MealEntity>();
            CreateMap<MealEntity, MealDto>();

            CreateMap<User, PupilDto>();

            CreateMap<TrainingPlan, TrainingPlanDetailsDto>();

            CreateMap<User, MentorDto>()
                .ForMember(dest => dest.OpinionNumber, opt => opt.MapFrom(src => src.MentorOpinions.Count))
                .ForMember(dest => dest.RoleName, opt => opt.MapFrom(src => src.Role.Name))
                .ForMember(dest => dest.Rate,
                    opt => opt.MapFrom(src =>
                        src.MentorOpinions.Any() ? src.MentorOpinions.Average(o => o.Rate) : 0m));
            CreateMap<Gym, GymDto>().ForMember(dest => dest.CityName, opt => opt.MapFrom(src => src.Address.City))
                .ForMember(dest => dest.Street, opt => opt.MapFrom(src => src.Address.Street));

            CreateMap<Meal, MealDto>();

            CreateMap<MealDto, Meal>();


            CreateMap<TraineeExerciseDto, TraineeExerciseEntity>();
            CreateMap<TraineeExerciseEntity, TraineeExercise>();

            CreateMap<CreateTrainingPlanDto, TrainingPlanEntity>();
            CreateMap<TrainingPlanEntity, TrainingPlan>();

            CreateMap<TrainingPlan, TrainingPlanEntity>();
            CreateMap<TrainingPlanEntity, TrainingPlanDetailsDto>();


            CreateMap<Meal, MealResponse>();
            CreateMap<MealResponse, Meal>();

            CreateMap<CreateMealCommand, Meal>();
            CreateMap<UpdateMealInternalCommand, Meal>();

            CreateMap<Diet, DietResponse>();

            CreateMap<Exercise, ExerciseResponse>();

            CreateMap<UpdateExerciseInternalCommand, Exercise>();


            CreateMap<CreateTraineeExerciseCommand, TraineeExercise>();

            CreateMap<TrainingPlan, TrainingPlanResponse>();

            CreateMap<CreateTrainingPlanCommand, TrainingPlan>();

            CreateMap<TrainingPlan, GetTrainerTrainingPlansResponse>();
            CreateMap<User, UserResponse<User>>();

            CreateMap<User, MentorList>();

            CreateMap<User, MentorWithOpinionResponse>()
                .ForMember(dest => dest.Opinions, opt => opt.MapFrom(src => src.MentorOpinions))
                .ForMember(dest => dest.TrainerGyms, opt => opt.MapFrom(src => src.TrainerGyms));

            CreateMap<Opinion, OpinionResponse>()
                .ForMember(dest => dest.PupilName, opt => opt.MapFrom(src => src.Pupil.Name));

            CreateMap<Gym, MentorGymResponse>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.CityName, opt => opt.MapFrom(src => src.Address.City))
                .ForMember(dest => dest.Street, opt => opt.MapFrom(src => src.Address.Street));

            CreateMap<TrainerGym, MentorGymResponse>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Gym.Name))
                .ForMember(dest => dest.CityName, opt => opt.MapFrom(src => src.Gym.Address.City))
                .ForMember(dest => dest.Street, opt => opt.MapFrom(src => src.Gym.Address.Street));

            CreateMap<User, PupilResponse>();

            CreateMap<Gym, GymResponse>()
                .ForMember(dest => dest.CityName, opt => opt.MapFrom(src => src.Address.City))
                .ForMember(dest => dest.Street, opt => opt.MapFrom(src => src.Address.Street));









        }
    }
}