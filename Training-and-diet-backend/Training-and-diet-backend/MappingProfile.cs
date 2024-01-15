using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Training_and_diet_backend.Models;
using TrainingAndDietApp.Application.Commands.Exercise;
using TrainingAndDietApp.Application.Commands.Meal;
using TrainingAndDietApp.Application.Commands.TraineeExercises;
using TrainingAndDietApp.Application.Commands.TrainingPlan;
using TrainingAndDietApp.Application.Commands.User.Pupil;
using TrainingAndDietApp.Application.Queries.TrainingPlan;
using TrainingAndDietApp.Application.Queries.User;
using TrainingAndDietApp.Application.Responses;
using TrainingAndDietApp.Application.Responses.Diet;
using TrainingAndDietApp.Application.Responses.Dietician;
using TrainingAndDietApp.Application.Responses.Exercise;
using TrainingAndDietApp.Application.Responses.Meal;
using TrainingAndDietApp.Application.Responses.Pupil;
using TrainingAndDietApp.Application.Responses.Trainer;
using TrainingAndDietApp.Application.Responses.TraineeExercise;
using TrainingAndDietApp.Application.Responses.TrainingPlan;
using TrainingAndDietApp.DAL.EntityModels;
using TrainingAndDietApp.Domain.Entities;
using Gym = TrainingAndDietApp.Domain.Entities.Gym;
using ActiveGymResponse = TrainingAndDietApp.Application.Responses.Gym.ActiveGymResponse;
using TrainingPlan = TrainingAndDietApp.Domain.Entities.TrainingPlan;


namespace Training_and_diet_backend
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            


            CreateMap<Meal, MealResponse>();
            CreateMap<MealResponse, Meal>();

            CreateMap<CreateMealCommand, Meal>();
          

            CreateMap<Diet, DietResponse>();

            CreateMap<Exercise, ExerciseNameResponse>();
            CreateMap<Exercise, ExerciseResponse>();

            


            CreateMap<CreateTraineeExerciseCommand, TraineeExercise>();

            CreateMap<TrainingPlan, TrainingPlanResponse>();

            CreateMap<CreateTrainingPlanCommand, TrainingPlan>();

            CreateMap<TrainingPlan, GetTrainerTrainingPlansResponse>();
            CreateMap<User, UserResponse<User>>();

            CreateMap<CreateExerciseCommand, Exercise>();

           
            CreateMap<Meal, UpdateMealInternalCommand>();

            CreateMap<User, MentorList>()
                .ForMember(dest => dest.OpinionNumber, opt => opt.MapFrom(src => src.MentorOpinions.Count))
                .ForMember(dest => dest.Rate, opt => opt.MapFrom(src => src.MentorOpinions.Any() ? src.MentorOpinions.Average(o => o.Rate) : 0m));

            CreateMap<User, MentorWithOpinionResponse>()
                .ForMember(dest => dest.Opinions, opt => opt.MapFrom(src => src.MentorOpinions))
                .ForMember(dest => dest.TrainerGyms, opt => opt.MapFrom(src => src.TrainerGyms))
                .ForMember(dest => dest.Role, opt => opt.MapFrom(src => src.Role.Name));

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

            CreateMap<Gym, ActiveGymResponse>()
                .ForMember(dest => dest.CityName, opt => opt.MapFrom(src => src.Address.City));

            CreateMap<User, PupilPersonalInfoResponse>()
                .ForMember(dest=>dest.Role, opt=>opt.MapFrom(src=>src.Role.Name));

            CreateMap<User, TrainerPersonalInfoResponse>()
                .ForMember(dest => dest.Role, opt => opt.MapFrom(src => src.Role.Name));

            CreateMap<User, DieticianPersonalInfoResponse>()
                .ForMember(dest => dest.Role, opt => opt.MapFrom(src => src.Role.Name));

            CreateMap<User, DieticianTrainerPersonalInfoResponse>()
                .ForMember(dest => dest.Role, opt => opt.MapFrom(src => src.Role.Name));

            CreateMap<UpdateTraineeExerciseInternalCommand, TraineeExercise>()
                .ForMember(dest => dest.RepetitionsNumber, opt => opt.MapFrom(src => src.TraineeExerciseCommand.RepetitionsNumber));



            CreateMap<TraineeExercise, TraineeExerciseResponse>()
                .ForMember(dest => dest.ExerciseName, opt => opt.MapFrom(src => src.Exercise.Name));

            CreateMap<UpdateMealInternalCommand, Meal>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.MealCommand.Name))
                .ForMember(dest => dest.Ingredients, opt => opt.MapFrom(src => src.MealCommand.Ingredients))
                .ForMember(dest => dest.PrepareSteps, opt => opt.MapFrom(src => src.MealCommand.PrepareSteps))
                .ForMember(dest => dest.Kcal, opt => opt.MapFrom(src => src.MealCommand.Kcal))
                .ForMember(dest => dest.Image, opt => opt.MapFrom(src => src.MealCommand.Image));

            CreateMap<UpdateTrainingPlanInternalCommand, TrainingPlan>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.UpdateTrainingPlanCommand.Name))
                .ForMember(dest => dest.CustomName, opt => opt.MapFrom(src => src.UpdateTrainingPlanCommand.CustomName))
                .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.UpdateTrainingPlanCommand.Type))
                .ForMember(dest => dest.StartDate, opt => opt.MapFrom(src => src.UpdateTrainingPlanCommand.StartDate))
                .ForMember(dest => dest.NumberOfWeeks, opt => opt.MapFrom(src => src.UpdateTrainingPlanCommand.NumberOfWeeks));

            CreateMap<UpdateTraineeExerciseInternalCommand, TraineeExercise>()
                .ForMember(dest => dest.SeriesNumber, opt => opt.MapFrom(src => src.TraineeExerciseCommand.SeriesNumber))
                .ForMember(dest => dest.RepetitionsNumber, opt => opt.MapFrom(src => src.TraineeExerciseCommand.RepetitionsNumber))
                .ForMember(dest => dest.Comments, opt => opt.MapFrom(src => src.TraineeExerciseCommand.Comments))
                .ForMember(dest => dest.DayOfWeek, opt => opt.MapFrom(src => src.TraineeExerciseCommand.DayOfWeek));

            CreateMap<UpdateExerciseInternalCommand, Exercise>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.ExerciseCommand.Name))
                .ForMember(dest => dest.Details, opt => opt.MapFrom(src => src.ExerciseCommand.Details))
                .ForMember(dest => dest.ExerciseSteps, opt => opt.MapFrom(src => src.ExerciseCommand.ExerciseSteps))
                .ForMember(dest => dest.Image, opt => opt.MapFrom(src => src.ExerciseCommand.Image));












        }
    }
}