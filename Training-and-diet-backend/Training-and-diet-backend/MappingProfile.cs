﻿using AutoMapper;
using Training_and_diet_backend.DTOs.Exercise;
using Training_and_diet_backend.DTOs.Gym;
using Training_and_diet_backend.DTOs.MealDto;
using Training_and_diet_backend.DTOs.TrainingPlan;
using Training_and_diet_backend.DTOs.User;
using Training_and_diet_backend.Models;

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


            CreateMap<Training_plan, TrainingPlanDetailsDto>();

            CreateMap<User, UserDto>()
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