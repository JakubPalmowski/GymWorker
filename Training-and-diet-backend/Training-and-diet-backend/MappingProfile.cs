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
            CreateMap<TrainingPlanCreateDto, Training_plan>();

            CreateMap<ExerciseDto, Exercise>().ForMember(dest => dest.Id_Exercise, opt => opt.Ignore());

            CreateMap<Exercise, ExerciseDto>();

            CreateMap<Exercise, ExerciseNameDto>();

            CreateMap<Training_plan, TrainingPlanNameDto>();
            CreateMap<Meal, MealDomainModel>();
            CreateMap<MealDomainModel, MealDto>();
            
            CreateMap<User, PupilDto>();

            CreateMap<Training_plan, TrainingPlanDetailsDto>();

            CreateMap<User, MentorDto>()
                .ForMember(dest => dest.Opinion_number, opt => opt.MapFrom(src => src.Mentor_Opinions.Count))
                .ForMember(dest => dest.Role_name, opt => opt.MapFrom(src => src.Role.Name))
                .ForMember(dest => dest.Rate,
                    opt => opt.MapFrom(src =>
                        src.Mentor_Opinions.Any() ? src.Mentor_Opinions.Average(o => o.Rate) : 0m));
            CreateMap<Gym, GymDto>().ForMember(dest => dest.CityName, opt => opt.MapFrom(src => src.Address.City))
                .ForMember(dest => dest.Street, opt => opt.MapFrom(src => src.Address.Street));

            CreateMap<Meal, MealDto>();

            CreateMap<MealDto, Meal>();








        }
    }
}