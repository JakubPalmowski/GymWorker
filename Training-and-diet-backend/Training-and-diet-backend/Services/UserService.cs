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

        public UserService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<User>> GetPupilsByTrainerId(int id_trainer)
        {
            return await _context.Users.Where(u => _context.Pupil_mentors.Where(e => e.Id_Mentor == id_trainer).Select(e => e.Id_Pupil).Contains(u.Id_User)).ToListAsync();

        }

        public async Task<List<Exercise>> GetTrainerExercises(int TrainderId)
        {
            var query = await _context.Exercises.Where(e => e.Id_Trainer == TrainderId).ToListAsync();

            if (query.Count == 0)
                throw new NotFoundException("Trainer with given id was not found in database");

            return query;

        }
        public async Task<List<GetTrainingPlanGeneralInfoDTO>> GetTrainerTrainingPlans(int id_trainer)
        {
            var trainingPlans = await _context.Training_plans.Where(e => e.Id_Trainer == id_trainer).ToListAsync();
            var result = new List<GetTrainingPlanGeneralInfoDTO>();

            foreach (var trainingPlan in trainingPlans)
            {
                var dto = new GetTrainingPlanGeneralInfoDTO
                {
                    Id = trainingPlan.Id_Training_plan,
                    Name = trainingPlan.Name,
                    Duration = (int)(trainingPlan.End_date-trainingPlan.Start_date).TotalDays
                };

                result.Add(dto);
            }

            return result;

        }
        public async Task<List<GetExercisesByTrainerIdDTO>> GetExercisesByTrainerId(int id_trainer)
        {
            var exercises = await _context.Exercises.Where(e => e.Id_Trainer == id_trainer)
                .Select(exercise =>
                new GetExercisesByTrainerIdDTO
                {
                    ExerciseName = exercise.Name,
                    Id_Exercise = exercise.Id_Exercise,
                }
            
                ).ToListAsync();

            return exercises;
        }

        public async Task<List<GetTrainersDTO>> GetTrainers()
        {
            return await _context.Users
                .Where(u => u.Id_Role == 3)
                .Select(trainer =>
                    new GetTrainersDTO
                    {
                        Id_trainer = trainer.Id_User,
                        Bio = trainer.Bio,
                        Last_name = trainer.Last_name,
                        Name = trainer.Name,
                        Phone_number = trainer.Phone_number,
                        City = trainer.Address.City,
                        Opinion_number = trainer.Mentor_Opinions.Count(),
                        Rate = trainer.Mentor_Opinions.Any() == true
                            ? trainer.Mentor_Opinions.Average(o => o.Rate) : 0m
        }).ToListAsync();


        }


        public async Task<GetTrainerWithOpinionsByIdDTO> GetTrainerWithOpinionsById(int id_trainer)
        {
            var trainer = await _context.Users.Where(u => u.Id_User == id_trainer && u.Id_Role==3).Select(

                trainer =>
                    new GetTrainerWithOpinionsByIdDTO
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
            if (trainer==null)
                throw new NotFoundException("Trainer with given id was not found in database");

            return trainer;
        }
    }
}
