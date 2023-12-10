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

            CreateMap<Exercise, GetExerciseGeneralInfoDTO>();

            CreateMap<Training_plan, GetTrainingPlanGeneralInfoDTO>();

            CreateMap<Exercise, GetExercisesByTrainerIdDTO>();







        }
    }
}
