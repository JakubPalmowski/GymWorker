using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Training_and_diet_backend.DTOs.Opinion;
using Training_and_diet_backend.DTOs.TrainingPlan;
using Training_and_diet_backend.DTOs.User;
using TrainingAndDietApp.BLL.Utils;
using TrainingAndDietApp.Common.DTOs.Exercise;
using TrainingAndDietApp.Common.DTOs.Gym;
using TrainingAndDietApp.Common.DTOs.User;
using TrainingAndDietApp.Common.Exceptions;
using TrainingAndDietApp.DAL.Context;
using TrainingAndDietApp.DAL.EntityModels;
using TrainingAndDietApp.DAL.Enums;
using TrainingAndDietApp.DAL.Repositories;

namespace TrainingAndDietApp.BLL.Services
{
    public interface IUserService
    {
        // zmienione na dto
        public Task<List<MentorDto>> GetPupilsByTrainerId(int id_trainer);
       
        public Task<List<TrainingPlanNameDto>> GetTrainerTrainingPlans(int id_trainer);

        Task<List<ExerciseNameDto>> GetExercisesByTrainerId(int id_trainer);
        Task<PageResult<MentorDto>> GetMentors(string roleName, UserQuery? query);
        public Task<MentorWithOpinionDto> GetMentorWithOpinionsById(string roleName, int id);
        public Task<PupilDto> GetPupilById(int id);
    }
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _context;
        private readonly IUserRepository _repository;
        private readonly IMapper _mapper;

        public UserService(ApplicationDbContext context, IMapper mapper, IUserRepository repository)
        {
            _context = context;
            _mapper = mapper;
            _repository = repository;
        }

        // zmienione na dto
        public async Task<List<MentorDto>> GetPupilsByTrainerId(int id_trainer)
        {
            if (!await CheckRole("Trainer", id_trainer))
                throw new BadRequestException("User with given id is not a trainer!");

            var pupils = await _repository.GetPupilsByTrainerIdAsync(id_trainer);

            if (!pupils.Any())
                throw new NotFoundException("Trainer with given id does not have any pupils");

            

            return _mapper.Map<List<MentorDto>>(pupils);

        }

        private async Task<bool> CheckRole(string roleName, int id)
        {
            var user = await _repository.GetUserByIdAsync(id);
                          
            return user != null && user.Role.Name.Equals(roleName);

        }

       

        // Tu skonczyłem, filip
        public async Task<List<TrainingPlanNameDto>> GetTrainerTrainingPlans(int id_trainer)
        {
            var trainingPlans = await _context.Training_plans.Where(e => e.IdTrainer == id_trainer).ToListAsync();

            if (trainingPlans.Count == 0) throw new NotFoundException("There are no trainingPlans with given trainer_id");

            return _mapper.Map<List<TrainingPlanNameDto>>(trainingPlans);

        }
        public async Task<List<ExerciseNameDto>> GetExercisesByTrainerId(int id_trainer)
        {
            var exercises = await _context.Exercises.Where(e => e.IdTrainer == id_trainer).ToListAsync();

            if (exercises.Count == 0) throw new NotFoundException("There are no exercises with given trainer_id");

            return _mapper.Map<List<ExerciseNameDto>>(exercises);
        }

         public async Task<PageResult<MentorDto>> GetMentors(string roleName, UserQuery query)
        {

            if (roleName != "Trainer" && roleName != "Dietician")
                throw new BadRequestException("Role name must be Trainer, Dietician");

            var baseQuery = _context.Users
                .Include(u => u.MentorOpinions)
                .Include(u=>u.Role)
                .Include(u=>u.TrainerGyms)
                .ThenInclude(tg=>tg.Gym)
                .ThenInclude(g=>g.Address)
                .Where(u => (u.Role.Name == roleName || u.Role.Name == "Dietician-Trainer") &&

                            (query.SearchPhrase == null ||
                             u.Name.ToLower().Contains(query.SearchPhrase.ToLower()) ||
                             u.LastName.ToLower().Contains(query.SearchPhrase.ToLower())));



           if (!string.IsNullOrEmpty(query.GymCityPhrase))
                {
                    baseQuery = baseQuery.Where(u => u.TrainerGyms.Any(g => g.Gym.Address.City.ToLower().Contains(query.GymCityPhrase.ToLower())));
                }

                if (!string.IsNullOrEmpty(query.GymNamePhrase))
                {
                    baseQuery = baseQuery.Where(u => u.TrainerGyms.Any(g => g.Gym.Name.ToLower().Contains(query.GymNamePhrase.ToLower())));
                }

if (!string.IsNullOrEmpty(query.SortBy))
{
    switch (query.SortBy)
    {
        case "Mentor_Opinions":
            if (query.SortDirection == SortDirection.ASC)
            {
                baseQuery = baseQuery
                    .OrderBy(u => u.MentorOpinions.Any()
                        ? u.MentorOpinions.Average(mo => mo.Rate)
                        : 0);
            }
            else
            {
                baseQuery = baseQuery
                    .OrderByDescending(u => u.MentorOpinions.Any()
                        ? u.MentorOpinions.Average(mo => mo.Rate)
                        : 0);
            }
            break;

        case "Plan_Price":
            if(query.SortDirection == SortDirection.ASC){
                baseQuery = baseQuery.OrderBy(u => u.TrainingPlanPriceFrom == null)
                             .ThenBy(u => u.TrainingPlanPriceFrom ?? 0);
            } else {
                baseQuery = baseQuery
                             .OrderByDescending(u => u.TrainingPlanPriceTo ?? 0);
            }
            break;


        case "Training_Price":
            if(query.SortDirection == SortDirection.ASC){
                baseQuery = baseQuery.OrderBy(u => u.PersonalTrainingPriceFrom == null)
                             .ThenBy(u => u.PersonalTrainingPriceFrom ?? 0);
            }else{
                baseQuery = baseQuery
                             .OrderByDescending(u => u.PersonalTrainingPriceTo ?? 0);
            }
            break;

        case "Diet_Price":
            if(query.SortDirection == SortDirection.ASC){
                baseQuery = baseQuery.OrderBy(u => u.DietPriceFrom == null)
                            .ThenBy(u => u.DietPriceFrom ?? 0);
            }else{
                baseQuery = baseQuery.OrderByDescending(u => u.DietPriceTo ?? 0);
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




            var users = await _context.Users.Where(u => u.IdUser == id && (u.Role.Name == roleName || "Dietician-Trainer" == u.Role.Name)).Select(

                trainer =>
                    new MentorWithOpinionDto
                    {
                        Id=trainer.IdUser,
                        Name=trainer.Name,
                        LastName = trainer.LastName,
                        Role = trainer.Role.Name,
                        Email = trainer.Email,
                        PhoneNumber = trainer.PhoneNumber,
                        Bio = trainer.Bio,
                        OpinionNumber = trainer.MentorOpinions.Count(),
                        TotalRate = trainer.MentorOpinions.Any() == true
                            ? trainer.MentorOpinions.Average(o => o.Rate) : 0m,
                        TrainingPlanPriceFrom = trainer.TrainingPlanPriceFrom,
                        TrainingPlanPriceTo = trainer.TrainingPlanPriceTo,
                        DietPriceFrom = trainer.DietPriceFrom,
                        DietPriceTo = trainer.DietPriceTo,
                        PersonalTrainingPriceFrom = trainer.PersonalTrainingPriceFrom,
                        PersonalTrainingPriceTo = trainer.PersonalTrainingPriceTo,
                        Opinions = trainer.MentorOpinions.Select(opinion=>
                            new OpinionDto
                            {
                                PupilName = opinion.Pupil.Name,
                                Rate = opinion.Rate,
                                Content = opinion.Content,
                                OpinionDate = opinion.OpinionDate.ToString("dd-MM-yyyy")
                            }
                        ).ToList(),
                        TrainerGyms = trainer.TrainerGyms.Select(gym => 
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
         var pupil = await _context.Users.Where(u=>u.IdUser==id && u.Role.Name=="Pupil").FirstOrDefaultAsync();
         if(pupil==null){
            throw new NotFoundException("Pupil with given id was not found in database");
         }
         var pupilDto = _mapper.Map<PupilDto>(pupil);
         return pupilDto;
        }
    }
}
