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
            


            CreateMap<Meal, MealResponse>();
            CreateMap<MealResponse, Meal>();

            CreateMap<CreateMealCommand, Meal>();
            CreateMap<UpdateMealInternalCommand, Meal>();

            CreateMap<Diet, DietResponse>();

            CreateMap<Exercise, ExerciseNameResponse>();
            CreateMap<Exercise, ExerciseResponse>();

            CreateMap<UpdateExerciseInternalCommand, Exercise>();


            CreateMap<CreateTraineeExerciseCommand, TraineeExercise>();

            CreateMap<TrainingPlan, TrainingPlanResponse>();

            CreateMap<CreateTrainingPlanCommand, TrainingPlan>();

            CreateMap<TrainingPlan, GetTrainerTrainingPlansResponse>();
            CreateMap<User, UserResponse<User>>();

            CreateMap<UpdateTrainingPlanInternalCommand, TrainingPlan>();

            CreateMap<User, MentorList>()
                .ForMember(dest => dest.OpinionNumber, opt => opt.MapFrom(src => src.MentorOpinions.Count))
                .ForMember(dest => dest.Rate, opt => opt.MapFrom(src => src.MentorOpinions.Any() ? src.MentorOpinions.Average(o => o.Rate) : 0m));

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










        }
    }
}