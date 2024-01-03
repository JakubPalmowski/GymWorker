using AutoMapper;
using Training_and_diet_backend.DTOs.MealDto;
using Training_and_diet_backend.DTOs.TrainingPlan;
using Training_and_diet_backend.DTOs.User;
using Training_and_diet_backend.Models;
using TrainingAndDietApp.BLL.Models;
using TrainingAndDietApp.Common.DTOs.Diet;
using TrainingAndDietApp.Common.DTOs.Exercise;
using TrainingAndDietApp.Common.DTOs.Gym;
using TrainingAndDietApp.Common.DTOs.User;
using TrainingAndDietApp.DAL.EntityModels;
using TrainingAndDietApp.DAL.Models;
using Exercise = Training_and_diet_backend.Models.Exercise;
using Gym = Training_and_diet_backend.Models.Gym;
using TrainingPlan = TrainingAndDietApp.DAL.Models.TrainingPlan;

namespace Training_and_diet_backend
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<TrainingPlanCreateDto, TrainingPlan>();

            CreateMap<Diet, DietEntity>();
            CreateMap<DietEntity, DietDto>();

            CreateMap<Gym, GymEntity>().ForMember(dest => dest.CityName, opt => opt.MapFrom(src => src.Address.City))
                .ForMember(dest => dest.Street, opt => opt.MapFrom(src => src.Address.Street));


            CreateMap<GymEntity, GymDto>();

            CreateMap<Meal, MealEntity>();
            CreateMap<MealEntity, MealDto>();
            CreateMap<MealDto, MealEntity>();
            CreateMap<MealEntity, Meal>();



            CreateMap<ExerciseDto, Exercise>().ForMember(dest => dest.IdExercise, opt => opt.Ignore());

            CreateMap<Exercise, ExerciseDto>();

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








        }
    }
}