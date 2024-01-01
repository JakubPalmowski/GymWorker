using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Training_and_diet_backend.Context;
using Training_and_diet_backend.DTOs;
using Training_and_diet_backend.DTOs.Exercise;
using Training_and_diet_backend.DTOs.Gym;
using Training_and_diet_backend.DTOs.Opinion;
using Training_and_diet_backend.DTOs.TrainingPlan;
using Training_and_diet_backend.DTOs.User;
using Training_and_diet_backend.Exceptions;
using Training_and_diet_backend.Models;

namespace Training_and_diet_backend.Services
{
    public interface IUserService
    {
        public Task<List<User>> GetPupilsByTrainerId(int id_trainer);
        Task<List<Exercise>> GetTrainerExercises(int TrainderId);
        public Task<List<TrainingPlanNameDto>> GetTrainerTrainingPlans(int id_trainer);

        Task<List<ExerciseNameDto>> GetExercisesByTrainerId(int id_trainer);
        Task<PageResult<MentorDto>> GetMentors(string roleName, UserQuery? query);
        public Task<MentorWithOpinionDto> GetMentorWithOpinionsById(string roleName, int id);
        public Task<PupilDto> GetPupilById(int id);

    }
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
        public async Task<List<TrainingPlanNameDto>> GetTrainerTrainingPlans(int id_trainer)
        {
            var trainingPlans = await _context.Training_plans.Where(e => e.Id_Trainer == id_trainer).ToListAsync();

           if(trainingPlans.Count == 0) throw new NotFoundException("There are no trainingPlans with given trainer_id");  

           return _mapper.Map<List<TrainingPlanNameDto>>(trainingPlans);

        }
        public async Task<List<ExerciseNameDto>> GetExercisesByTrainerId(int id_trainer)
        {
            var exercises = await _context.Exercises.Where(e => e.Id_Trainer == id_trainer).ToListAsync();

            if(exercises.Count == 0) throw new NotFoundException("There are no exercises with given trainer_id");

            return _mapper.Map<List<ExerciseNameDto>>(exercises);
        }

        public async Task<PageResult<MentorDto>> GetMentors(string roleName, UserQuery query)
        {

            if (roleName != "Trainer" && roleName != "Dietician")
                throw new BadRequestException("Role name must be Trainer, Dietician");

            var baseQuery = _context.Users
                .Include(u => u.Mentor_Opinions)
                .Include(u=>u.Role)
                .Include(u=>u.Trainer_Gyms)
                .ThenInclude(tg=>tg.Gym)
                .ThenInclude(g=>g.Address)
                .Where(u => (u.Role.Name == roleName || u.Role.Name == "Dietician-Trainer") &&

                            (query.SearchPhrase == null ||
                             u.Name.ToLower().Contains(query.SearchPhrase.ToLower()) ||
                             u.Last_name.ToLower().Contains(query.SearchPhrase.ToLower())));



           if (!string.IsNullOrEmpty(query.GymCityPhrase))
                {
                    baseQuery = baseQuery.Where(u => u.Trainer_Gyms.Any(g => g.Gym.Address.City.ToLower().Contains(query.GymCityPhrase.ToLower())));
                }

                if (!string.IsNullOrEmpty(query.GymNamePhrase))
                {
                    baseQuery = baseQuery.Where(u => u.Trainer_Gyms.Any(g => g.Gym.Name.ToLower().Contains(query.GymNamePhrase.ToLower())));
                }

if (!string.IsNullOrEmpty(query.SortBy))
{
    switch (query.SortBy)
    {
        case "Mentor_Opinions":
            if (query.SortDirection == SortDirection.ASC)
            {
                baseQuery = baseQuery
                    .OrderBy(u => u.Mentor_Opinions.Any()
                        ? u.Mentor_Opinions.Average(mo => mo.Rate)
                        : 0);
            }
            else
            {
                baseQuery = baseQuery
                    .OrderByDescending(u => u.Mentor_Opinions.Any()
                        ? u.Mentor_Opinions.Average(mo => mo.Rate)
                        : 0);
            }
            break;

        case "Plan_Price":
            if(query.SortDirection == SortDirection.ASC){
                baseQuery = baseQuery.OrderBy(u => u.Training_plan_price_from == null)
                             .ThenBy(u => u.Training_plan_price_from ?? 0);
            } else {
                baseQuery = baseQuery
                             .OrderByDescending(u => u.Training_plan_price_to ?? 0);
            }
            break;


        case "Training_Price":
            if(query.SortDirection == SortDirection.ASC){
                baseQuery = baseQuery.OrderBy(u => u.Personal_training_price_from == null)
                             .ThenBy(u => u.Personal_training_price_from ?? 0);
            }else{
                baseQuery = baseQuery
                             .OrderByDescending(u => u.Personal_training_price_to ?? 0);
            }
            break;

        case "Diet_Price":
            if(query.SortDirection == SortDirection.ASC){
                baseQuery = baseQuery.OrderBy(u => u.Diet_price_from == null)
                            .ThenBy(u => u.Diet_price_from ?? 0);
            }else{
                baseQuery = baseQuery.OrderByDescending(u => u.Diet_price_to ?? 0);
            }
            break;
    }
}






            var list = await baseQuery
                .Skip(9 * (query.PageNumber-1))
                .Take(9)
                .ToListAsync();

           var totalItemsCount =  baseQuery.Count();

           var usersDtos = _mapper.Map<List<MentorDto>>(list);

           var result = new PageResult<MentorDto>(usersDtos, totalItemsCount,query.PageNumber);


            if (list.Count == 0) throw new NotFoundException($"There are no {roleName} in database");

            return result;


        }


        public async Task<MentorWithOpinionDto> GetMentorWithOpinionsById(string roleName, int id)
        {

            if (roleName != "Trainer" && roleName != "Dietician")
                throw new BadRequestException("Role name must be Trainer, Dietician");




            var users = await _context.Users.Where(u => u.Id_User == id && (u.Role.Name == roleName || "Dietician-Trainer" == u.Role.Name)).Select(

                trainer =>
                    new MentorWithOpinionDto
                    {
                        Id=trainer.Id_User,
                        Name=trainer.Name,
                        LastName = trainer.Last_name,
                        Role = trainer.Role.Name,
                        Email = trainer.Email,
                        PhoneNumber = trainer.Phone_number,
                        Bio = trainer.Bio,
                        Opinion_number = trainer.Mentor_Opinions.Count(),
                        TotalRate = trainer.Mentor_Opinions.Any() == true
                            ? trainer.Mentor_Opinions.Average(o => o.Rate) : 0m,
                        Training_plan_price_from = trainer.Training_plan_price_from,
                        Training_plan_price_to = trainer.Training_plan_price_to,
                        Diet_price_from = trainer.Diet_price_from,
                        Diet_price_to = trainer.Diet_price_to,
                        Personal_training_price_from = trainer.Personal_training_price_from,
                        Personal_training_price_to = trainer.Personal_training_price_to,
                        Opinions = trainer.Mentor_Opinions.Select(opinion=>
                            new OpinionDto
                            {
                                PupilName = opinion.Pupil.Name,
                                Rate = opinion.Rate,
                                Content = opinion.Content,
                                Opinion_date = opinion.Opinion_date.ToString("dd-MM-yyyy")
                            }
                        ).ToList(),
                        TrainerGyms = trainer.Trainer_Gyms.Select(gym => 
                        new GymDto
                        {
                            Name = gym.Gym.Name,
                            CityName = gym.Gym.Address.City,
                            Street = gym.Gym.Address.Street
                        }
                        ).ToList()




                    }).FirstOrDefaultAsync();
            if (users==null)
                throw new NotFoundException("User with given id was not found in database");

            return users;
        }

        public async Task<PupilDto> GetPupilById(int id){
         var pupil = await _context.Users.Where(u=>u.Id_User==id && u.Role.Name=="Pupil").FirstOrDefaultAsync();
         if(pupil==null){
            throw new NotFoundException("Pupil with given id was not found in database");
         }
         var pupilDto = _mapper.Map<PupilDto>(pupil);
         return pupilDto;
        }
    }
}
