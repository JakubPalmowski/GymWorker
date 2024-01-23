using AutoMapper;
using Training_and_diet_backend.Models;
using TrainingAndDietApp.Application.CQRS.Commands.Auth.Register;
using TrainingAndDietApp.Application.CQRS.Commands.Exercise.CreateExercise;
using TrainingAndDietApp.Application.CQRS.Commands.Exercise.UpdateExercise;
using TrainingAndDietApp.Application.CQRS.Commands.Meal.CreateMeal;
using TrainingAndDietApp.Application.CQRS.Commands.Meal.UpdateMeal;
using TrainingAndDietApp.Application.CQRS.Commands.TraineeExercises.CreateTraineeExercise;
using TrainingAndDietApp.Application.CQRS.Commands.TraineeExercises.UpdateTraineeExercise;
using TrainingAndDietApp.Application.CQRS.Commands.TrainingPlan.CreateTrainingPlan;
using TrainingAndDietApp.Application.CQRS.Commands.TrainingPlan.UpdateTrainingPlan;
using TrainingAndDietApp.Application.CQRS.Queries.Admin.GetGymByIdAdmin;
using TrainingAndDietApp.Application.CQRS.Queries.TraineeExercise.GetById.Pupil;
using TrainingAndDietApp.Application.CQRS.Queries.TrainingPlan.GetById.Pupil;
using TrainingAndDietApp.Application.CQRS.Queries.TrainingPlan.GetByPupilId;
using TrainingAndDietApp.Application.CQRS.Queries.TrainingPlan.GetByTrainerId;
using TrainingAndDietApp.Application.CQRS.Queries.User.User.GetAll;
using TrainingAndDietApp.Application.CQRS.Responses;
using TrainingAndDietApp.Application.CQRS.Responses.Diet;
using TrainingAndDietApp.Application.CQRS.Responses.Dietician;
using TrainingAndDietApp.Application.CQRS.Responses.Exercise;
using TrainingAndDietApp.Application.CQRS.Responses.Gym;
using TrainingAndDietApp.Application.CQRS.Responses.Meal;
using TrainingAndDietApp.Application.CQRS.Responses.Pupil;
using TrainingAndDietApp.Application.CQRS.Responses.TraineeExercise;
using TrainingAndDietApp.Application.CQRS.Responses.Trainer;
using TrainingAndDietApp.Application.CQRS.Responses.TrainingPlan;
using TrainingAndDietApp.DAL.EntityModels;
using TrainingAndDietApp.Domain.Entities;
using Gym = TrainingAndDietApp.Domain.Entities.Gym;
using TrainingPlan = TrainingAndDietApp.Domain.Entities.TrainingPlan;
using TrainingAndDietApp.Application.CQRS.Commands.Admin.CreateExercise;
using TrainingAndDietApp.Application.CQRS.Queries.Certificate.GetUserCertificates;
using TrainingAndDietApp.Application.CQRS.Responses.Admin;
using TrainingAndDietApp.Application.CQRS.Queries.Admin.GetUserInfoForVerification;
using TrainingAndDietApp.Application.CQRS.Queries.Admin.GetUserCertificatesById;
using TrainingAndDietApp.Application.CQRS.Commands.Admin.UpdateExercise;


namespace TrainingAndDietApp.Application
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

            CreateMap<TrainingPlan, TrainerTrainingPlanResponse>()
                .ForMember(dest => dest.PupilLastName, opt => opt.MapFrom(src => src.Pupil.LastName))
                .ForMember(dest => dest.PupilName, opt => opt.MapFrom(src => src.Pupil.Name));

            CreateMap<TrainingPlan, PupilTrainingPlanResponse>()
                .ForMember(dest => dest.TrainerLastName, opt => opt.MapFrom(src => src.Trainer.LastName))
                .ForMember(dest => dest.TrainerName, opt => opt.MapFrom(src => src.Trainer.Name));

            CreateMap<TraineeExercise, PupilTraineeExerciseResponse>()
                .ForMember(dest => dest.ExerciseName, opt => opt.MapFrom(src => src.Exercise.Name))
                .ForMember(dest => dest.ExerciseSteps, opt => opt.MapFrom(src => src.Exercise.ExerciseSteps))
                .ForMember(dest => dest.Details, opt => opt.MapFrom(src => src.Exercise.Details));

            CreateMap<CreateTrainingPlanCommand, TrainingPlan>();


            CreateMap<TrainingPlan, GetTrainerTrainingPlansResponse>();
            CreateMap<User, UserResponse<User>>();

            CreateMap<CreateExerciseCommand, Exercise>();

            CreateMap<RegisterUserCommand, User>();

            CreateMap<User, MentorPupilResponse>(); 


            CreateMap<Meal, UpdateMealInternalCommand>();

            CreateMap<TrainingPlan, GetPupilTrainingPlansResponse>()
                .ForMember(dest => dest.TrainerLastName, opt => opt.MapFrom(src => src.Trainer.LastName))
                .ForMember(dest => dest.TrainerName, opt => opt.MapFrom(src => src.Trainer.Name));





            CreateMap<User, MentorList>()
                .ForMember(dest => dest.OpinionNumber, opt => opt.MapFrom(src => src.MentorOpinions.Count))
                .ForMember(dest => dest.Rate, opt => opt.MapFrom(src => src.MentorOpinions.Any() ? src.MentorOpinions.Average(o => o.Rate) : 0m));

            CreateMap<User, MentorWithOpinionResponse>()
                .ForMember(dest => dest.Opinions, opt => opt.MapFrom(src => src.MentorOpinions))
                .ForMember(dest => dest.TrainerGyms, opt => opt.MapFrom(src => src.TrainerGyms))
                .ForMember(dest => dest.Role, opt => opt.MapFrom(src => src.Role.Name));

            CreateMap<Opinion, OpinionResponse>()
                .ForMember(dest => dest.PupilName, opt => opt.MapFrom(src => src.Pupil.Name))
                .ForMember(dest => dest.ImageUri, opt => opt.MapFrom(src => src.Pupil.ImageUri));

            CreateMap<Gym, MentorGymResponse>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.CityName, opt => opt.MapFrom(src => src.Address.City));

            CreateMap<Gym, GymAdminInfoResponse>()
                .ForMember(dest => dest.City, opt => opt.MapFrom(src => src.Address.City))
                .ForMember(dest => dest.Street, opt => opt.MapFrom(src => src.Address.Street));
            CreateMap<Gym, GetGymByIdAdminQuery>()
                .ForMember(dest => dest.City, opt => opt.MapFrom(src => src.Address.City))
                .ForMember(dest => dest.Street, opt => opt.MapFrom(src => src.Address.Street))
                .ForMember(dest=>dest.PostalCode, opt=>opt.MapFrom(src=>src.Address.PostalCode))
                .ForMember(dest=>dest.Status, opt=>opt.MapFrom(src=>src.Status.ToString()));


            CreateMap<TrainerGym, MentorGymResponse>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Gym.Name))
                .ForMember(dest => dest.CityName, opt => opt.MapFrom(src => src.Gym.Address.City));

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

            

            CreateMap<TraineeExercise, TrainerTraineeExerciseResponse>()
                .ForMember(dest => dest.ExerciseName, opt => opt.MapFrom(src => src.Exercise.Name));

            CreateMap<UpdateMealInternalCommand, Meal>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.MealCommand.Name))
                .ForMember(dest => dest.Ingredients, opt => opt.MapFrom(src => src.MealCommand.Ingredients))
                .ForMember(dest => dest.PrepareSteps, opt => opt.MapFrom(src => src.MealCommand.PrepareSteps))
                .ForMember(dest => dest.Kcal, opt => opt.MapFrom(src => src.MealCommand.Kcal));

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
                .ForMember(dest => dest.ExerciseSteps, opt => opt.MapFrom(src => src.ExerciseCommand.ExerciseSteps));

            CreateMap<Gym, GymsAddedByUserResponse>()
                .ForMember(dest => dest.City, opt => opt.MapFrom(src => src.Address.City))
                .ForMember(dest => dest.Street, opt => opt.MapFrom(src => src.Address.Street))
                .ForMember(dest => dest.PostalCode, opt => opt.MapFrom(src => src.Address.PostalCode))
                .ForMember(dest=>dest.Status, opt=>opt.MapFrom(src=>src.Status.ToString()));

            CreateMap<CreateInternalExerciseCommand, Exercise>()
                .ForMember(dest => dest.Details, opt => opt.MapFrom(src => src.ExerciseCommand.Details))
                .ForMember(dest => dest.ExerciseSteps, opt => opt.MapFrom(src => src.ExerciseCommand.ExerciseSteps))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.ExerciseCommand.Name))
                .ForMember(dest => dest.IdTrainer, opt => opt.MapFrom(src => src.IdTrainer));

            CreateMap<CreateInternalMealCommand, Meal>()
                .ForMember(dest => dest.Ingredients, opt => opt.MapFrom(src => src.MealCommand.Ingredients))
                .ForMember(dest => dest.Kcal, opt => opt.MapFrom(src => src.MealCommand.Kcal))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.MealCommand.Name))
                .ForMember(dest => dest.PrepareSteps, opt => opt.MapFrom(src => src.MealCommand.PrepareSteps))
                .ForMember(dest => dest.IdDietician, opt => opt.MapFrom(src => src.IdDietician));

                CreateMap<CreateExerciseAdminInternalCommand, Exercise>()
                .ForMember(dest => dest.Details, opt => opt.MapFrom(src => src.ExerciseCommand.Details))
                .ForMember(dest => dest.ExerciseSteps, opt => opt.MapFrom(src => src.ExerciseCommand.ExerciseSteps))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.ExerciseCommand.Name));

                CreateMap<Certificate, GetUserCertificatesQuery>();

                CreateMap<User, GetAllUsersWithCertificatesResponse>();

                CreateMap<User, GetUserInfoForVerificationQuery>();

                CreateMap<Certificate, GetUserCertificatesByIdQuery>();

                CreateMap<Certificate, CertificateVerificationResponse>();

                CreateMap<UpdateAdminExerciseInternalCommand , Exercise>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.ExerciseCommand.Name))
                .ForMember(dest => dest.Details, opt => opt.MapFrom(src => src.ExerciseCommand.Details))
                .ForMember(dest => dest.ExerciseSteps, opt => opt.MapFrom(src => src.ExerciseCommand.ExerciseSteps));

                
       








        }
    }
}