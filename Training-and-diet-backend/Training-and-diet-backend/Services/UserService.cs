using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Training_and_diet_backend.Context;
using Training_and_diet_backend.Controllers;
using Training_and_diet_backend.DTOs;
using Training_and_diet_backend.Exceptions;
using Training_and_diet_backend.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Training_and_diet_backend.Services
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public UserService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        
        public async Task<List<User>> GetPupilsByTrainerId(int id_trainer)
        {
            var pupils =  await _context.Users
                .Where(u => _context.Pupil_mentors
                    .Where(e => e.Id_Mentor == id_trainer)
                    .Select(e => e.Id_Pupil)
                    .Contains(u.Id_User))
                .ToListAsync();

            if (pupils.Count == 0)
                throw new NotFoundException("Trainer with given id was not found in database");

            return pupils;

        }

        public async Task<List<Exercise>> GetTrainerExercises(int TrainderId)
        {
            var query = await _context.Exercises.Where(e => e.Id_Trainer == TrainderId).ToListAsync();

            if (query.Count == 0)
                throw new NotFoundException("Trainer with given id was not found in database");

            return query;

        }

        // Tu skonczyłem, filip
        public async Task<List<GetTrainingPlanGeneralInfoDTO>> GetTrainerTrainingPlans(int id_trainer)
        {
            var trainingPlans = await _context.Training_plans.Where(e => e.Id_Trainer == id_trainer).ToListAsync();

           if(trainingPlans.Count == 0) throw new NotFoundException("There are no trainingPlans with given trainer_id");  

           return _mapper.Map<List<GetTrainingPlanGeneralInfoDTO>>(trainingPlans);

        }
        public async Task<List<GetExercisesByTrainerIdDTO>> GetExercisesByTrainerId(int id_trainer)
        {
            var exercises = await _context.Exercises.Where(e => e.Id_Trainer == id_trainer).ToListAsync();

            if(exercises.Count == 0) throw new NotFoundException("There are no exercises with given trainer_id");

            return _mapper.Map<List<GetExercisesByTrainerIdDTO>>(exercises);
        }

        public async Task<List<GetUsersDTO>> GetUsers(string roleName)
        {

            if (roleName != "Trainer" && roleName != "Dietician" && roleName != "Dietician-Trainer")
                throw new BadRequestException("Role name must be Trainer, Dietician or Dietician-Trainer");






            var list = await _context.Users
                .Where(u => u.Role.Name == roleName)
                .Select(trainer =>
                    new GetUsersDTO
                    {
                        Id_user = trainer.Id_User,
                        Bio = trainer.Bio,
                        Last_name = trainer.Last_name,
                        Name = trainer.Name,
                        Phone_number = trainer.Phone_number,
                        City = trainer.Address.City,
                        Opinion_number = trainer.Mentor_Opinions.Count(),
                        Rate = trainer.Mentor_Opinions.Any() == true
                            ? trainer.Mentor_Opinions.Average(o => o.Rate) : 0m
        }).ToListAsync();

            

            if(list.Count == 0) throw new NotFoundException($"There are no {roleName} in database");

            return list;


        }


        public async Task<GetUserWithOpinionsByIdDTO> GetUsersWithOpinionsById(string roleName, int id)
        {

            if (roleName != "Trainer" && roleName != "Dietician" && roleName != "Dietician-Trainer")
                throw new BadRequestException("Role name must be Trainer, Dietician or Dietician-Trainer");




            var users = await _context.Users.Where(u => u.Id_User == id && u.Role.Name == roleName).Select(

                trainer =>
                    new GetUserWithOpinionsByIdDTO
                    {
                        Id=trainer.Id_User,
                        Name=trainer.Name,
                        LastName = trainer.Last_name,
                        Role = trainer.Role.Name,
                        Street = trainer.Address.Street,
                        City = trainer.Address.City,
                        PhoneNumber = trainer.Phone_number,
                        Bio = trainer.Bio,
                        Opinion_number = trainer.Mentor_Opinions.Count(),
                        TotalRate = trainer.Mentor_Opinions.Any() == true
                            ? trainer.Mentor_Opinions.Average(o => o.Rate) : 0m,
                        Opinions = trainer.Mentor_Opinions.Select(opinion=>
                            new OpinionDTO
                            {
                                PupilName = opinion.Pupil.Name,
                                Rate = opinion.Rate,
                                Content = opinion.Content,
                                Opinion_date = opinion.Opinion_date.ToString("dd-MM-yyyy")
                            }
                        ).ToList()

                    }).FirstOrDefaultAsync();
            if (users==null)
                throw new NotFoundException("User with given id was not found in database");

            return users;
        }
    }
}
