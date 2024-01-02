using AutoMapper;
using Training_and_diet_backend.DTOs.MealDto;
using Training_and_diet_backend.DTOs.TrainingPlan;
using Training_and_diet_backend.DTOs.User;
using Training_and_diet_backend.Models;
using TrainingAndDietApp.BLL.Models;
using TrainingAndDietApp.Common.DTOs.Exercise;
using TrainingAndDietApp.Common.DTOs.Gym;
using TrainingAndDietApp.Common.DTOs.User;

namespace Training_and_diet_backend
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<TrainingPlanCreateDto, TrainingPlan>();

            CreateMap<ExerciseDto, Exercise>().ForMember(dest => dest.IdExercise, opt => opt.Ignore());

            CreateMap<Exercise, ExerciseDto>();

            CreateMap<Exercise, ExerciseNameDto>();

            CreateMap<TrainingPlan, TrainingPlanNameDto>();
            CreateMap<Meal, MealDomainModel>();
            CreateMap<MealDomainModel, MealDto>();
            
            CreateMap<User, PupilDto>();

            CreateMap<TrainingPlan, TrainingPlanDetailsDto>();

            CreateMap<User, MentorDto>()
                .ForMember(dest => dest.Opinion_number, opt => opt.MapFrom(src => src.MentorOpinions.Count))
                .ForMember(dest => dest.Role_name, opt => opt.MapFrom(src => src.Role.Name))
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