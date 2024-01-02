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
            CreateMap<TrainingPlanCreateDto, TrainingPlanEntity>();

            CreateMap<ExerciseDto, ExerciseEntity>().ForMember(dest => dest.IdExercise, opt => opt.Ignore());

            CreateMap<ExerciseEntity, ExerciseDto>();

            CreateMap<ExerciseEntity, ExerciseNameDto>();

            CreateMap<TrainingPlanEntity, TrainingPlanNameDto>();
            CreateMap<MealEntity, MealDomainModel>();
            CreateMap<MealDomainModel, MealDto>();
            
            CreateMap<UserEntity, PupilDto>();

            CreateMap<TrainingPlanEntity, TrainingPlanDetailsDto>();

            CreateMap<UserEntity, MentorDto>()
                .ForMember(dest => dest.OpinionNumber, opt => opt.MapFrom(src => src.MentorOpinions.Count))
                .ForMember(dest => dest.RoleName, opt => opt.MapFrom(src => src.RoleEntity.Name))
                .ForMember(dest => dest.Rate,
                    opt => opt.MapFrom(src =>
                        src.MentorOpinions.Any() ? src.MentorOpinions.Average(o => o.Rate) : 0m));
            CreateMap<GymEntity, GymDto>().ForMember(dest => dest.CityName, opt => opt.MapFrom(src => src.AddressEntity.City))
                .ForMember(dest => dest.Street, opt => opt.MapFrom(src => src.AddressEntity.Street));

            CreateMap<MealEntity, MealDto>();

            CreateMap<MealDto, MealEntity>();








        }
    }
}