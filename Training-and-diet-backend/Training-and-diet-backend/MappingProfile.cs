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

            CreateMap<PostExerciseDTO, Exercise>();

            CreateMap<Exercise, GetExerciseGeneralInfoDTO>();

            CreateMap<Training_plan, GetTrainingPlanGeneralInfoDTO>();

            CreateMap<Exercise, GetExercisesByTrainerIdDTO>();

            CreateMap<Training_plan, GetTrainingPlanByIdDTO>();

            CreateMap<User, GetUsersDTO>().ForMember(dest => dest.City, opt => opt.MapFrom(src => src.Address.City))
                .ForMember(dest => dest.Opinion_number, opt => opt.MapFrom(src => src.Mentor_Opinions.Count))
                .ForMember(dest => dest.Rate,
                    opt => opt.MapFrom(src =>
                        src.Mentor_Opinions.Any() ? src.Mentor_Opinions.Average(o => o.Rate) : 0m));









        }
    }
}
