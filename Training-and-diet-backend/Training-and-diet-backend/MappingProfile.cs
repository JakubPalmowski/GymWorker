using AutoMapper;
using Training_and_diet_backend.DTOs;
using Training_and_diet_backend.Models;

namespace Training_and_diet_backend
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<PostTrainingPlanDTO, Training_plan>();

            CreateMap<ExerciseDTO, Exercise>().ForMember(dest => dest.Id_Exercise, opt => opt.Ignore());

            CreateMap<Exercise,ExerciseDTO>();

            CreateMap<Exercise, GetExerciseGeneralInfoDTO>();

            CreateMap<Exercise, GetAllExercisesDTO>();

            CreateMap<Training_plan, GetTrainingPlanGeneralInfoDTO>();

            CreateMap<Exercise, GetExercisesByTrainerIdDTO>();

            CreateMap<Training_plan, GetTrainingPlanByIdDTO>();

            CreateMap<User, GetUsersDTO>()
                .ForMember(dest => dest.Opinion_number, opt => opt.MapFrom(src => src.Mentor_Opinions.Count))
                .ForMember(dest=>dest.Role_name, opt=>opt.MapFrom(src=>src.Role.Name))
                .ForMember(dest => dest.Rate,
                    opt => opt.MapFrom(src =>
                        src.Mentor_Opinions.Any() ? src.Mentor_Opinions.Average(o => o.Rate) : 0m));
            CreateMap<Gym,GymDto>().ForMember(dest => dest.CityName, opt => opt.MapFrom(src => src.Address.City))
                .ForMember(dest => dest.Street, opt => opt.MapFrom(src => src.Address.Street));







        }
    }
}
