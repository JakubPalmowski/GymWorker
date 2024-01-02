using Microsoft.EntityFrameworkCore;
using Training_and_diet_backend.Models;
using TrainingAndDietApp.DAL.EntityModels;

namespace TrainingAndDietApp.DAL.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
        {

        }

        public DbSet<ExerciseEntity> Exercises { get; set; }
        public DbSet<TraineeExerciseEntity> Trainee_exercises { get; set; }
        public DbSet<TrainingPlanEntity> Training_plans { get; set; }
        public DbSet<PupilMentorEntity> Pupil_mentors { get; set; }
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<MealEntity> Meals { get; set; }
        public DbSet<MealDietEntity> Meal_Diets { get; set; }
        public DbSet<DietEntity> Diets { get; set; }
        public DbSet<AddressEntity> Addresses { get; set; }
        public DbSet<OpinionEntity> Opinions { get; set; }
        public DbSet<RoleEntity> Roles { get; set; }
        public virtual DbSet<GymEntity> Gyms { get; set; }
        public DbSet<TrainerGymEntity> Trainer_Gyms { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var roles = new List<RoleEntity>()
             {
                 new RoleEntity()
                 {
                     Id = 1,
                     Name = "Admin"
                 },
                 new RoleEntity()
                 {
                     Id = 2,
                     Name = "Pupil"
                 },
                 new RoleEntity()
                 {
                     Id = 3,
                     Name = "Trainer"
                 },
                 new RoleEntity()
                 {
                     Id = 4,
                     Name = "Dietician"
                 },
                 new RoleEntity()
                 {
                     Id = 5,
                     Name = "Dietician-Trainer"
                 }
             };

            var address = new AddressEntity { IdAddress = 1, City = "Warszawa", PostalCode = "02-222", Street = "Zlota" };
            var address2 = new AddressEntity { IdAddress = 2, City = "Białystok", PostalCode = "02-324", Street = "Kryształowa" };
            var address3 = new AddressEntity { IdAddress = 3, City = "Kraków", PostalCode = "02-421", Street = "Mendelejewa" };

            var user = new UserEntity { IdUser = 1, IdRole = 1, Name = "Michał", LastName = "Emczyk", Email = "michal@gmail.com", PhoneNumber = "48777888777", EmailValidated = true, Sex = "Male", Bio = "Cześć jestem Kuba i dużo trenuje. Zapraszam na treningi indywidualne"};
            var user1 = new UserEntity { IdUser = 2, IdRole = 2, Name = "Anna", LastName = "Kowalska", Email = "anna@gmail.com", PhoneNumber = "48666778888", EmailValidated = true, Sex = "Female", Bio = "Cześć jestem Kuba i dużo trenuje. Zapraszam na treningi indywidualne"};
            var user2 = new UserEntity { IdUser = 3, IdRole = 3, Name = "John", LastName = "Doe", Email = "john@gmail.com", PhoneNumber = "48555667777", EmailValidated = true, Sex = "Male", Bio = "Cześć jestem Kuba i dużo trenuje. Zapraszam na treningi indywidualne"};
            var user3 = new UserEntity { IdUser = 4, IdRole = 3, Name = "Charlie", LastName = "Brown", Email = "charlie@gmail.com", PhoneNumber = "48554567890", EmailValidated = true, Sex = "Male", Bio = "Hi, I'm Charlie. Let's stay active and have fun!"};
            var user4 = new UserEntity { IdUser = 5, IdRole = 3, Name = "Diana", LastName = "Miller", Email = "diana@gmail.com", PhoneNumber = "48555678901", EmailValidated = true, Sex = "Female", Bio = "Hello, I'm Diana. Fitness is my passion!"};
            var user5 = new UserEntity { IdUser = 6, IdRole = 3, Name = "Frank", LastName = "Davis", Email = "frank@gmail.com", PhoneNumber = "48556789012", EmailValidated = true, Sex = "Male", Bio = "Hi, I'm Frank. Let's achieve our fitness goals together!"};
            var user6 = new UserEntity { IdUser = 7, IdRole = 3, Name = "Grace", LastName = "Anderson", Email = "grace@gmail.com", PhoneNumber = "48557890123", EmailValidated = true, Sex = "Female", Bio = "Hello, I'm Grace. Fitness is my lifestyle!"};
            var user7=new UserEntity { IdUser = 8, IdRole = 3, Name = "Harry", LastName = "Moore", Email = "harry@gmail.com", PhoneNumber = "48558901234", EmailValidated = true, Sex = "Male", Bio = "Hey, I'm Harry. Let's push our limits in every workout!"};
            var user8 = new UserEntity { IdUser = 9, IdRole = 3, Name = "Ivy", LastName = "Turner", Email = "ivy@gmail.com", PhoneNumber = "48559012345", EmailValidated = true, Sex = "Female", Bio = "Hi, I'm Ivy. Fitness is my passion and I'm here to inspire!"};
            var user9 = new UserEntity { IdUser = 10, IdRole = 3, Name = "Jack", LastName = "White", Email = "jack@gmail.com", PhoneNumber = "48550123456", EmailValidated = true, Sex = "Male", Bio = "Hello, I'm Jack. Let's make every workout count!"};
            var user10 = new UserEntity { IdUser = 11, IdRole = 3, Name = "Kelly", LastName = "Martin", Email = "kelly@gmail.com", PhoneNumber = "48551234567", EmailValidated = true, Sex = "Female", Bio = "Hi, I'm Kelly. Fitness is the key to a healthy life!"};
            var user11 = new UserEntity { IdUser = 12, IdRole = 3, Name = "Leo", LastName = "Baker", Email = "leo@gmail.com", PhoneNumber = "48552345678", EmailValidated = true, Sex = "Male", Bio = "Hey, I'm Leo. Let's crush our fitness goals!"};
            var user12 = new UserEntity { IdUser = 13, IdRole = 3, Name = "Mia", LastName = "Collins", Email = "mia@gmail.com", PhoneNumber = "48553456789", EmailValidated = true, Sex = "Female", Bio = "Hello, I'm Mia. Fitness is not just a hobby, it's a way of life!"};
            var user13 = new UserEntity { IdUser = 14, IdRole = 3, Name = "Nathan", LastName = "Ward", Email = "nathan@gmail.com", PhoneNumber = "48554567890", EmailValidated = true, Sex = "Male", Bio = "Hi, I'm Nathan. Let's embrace a fit and healthy lifestyle!"};
            var user14 = new UserEntity { IdUser = 15, IdRole = 3, Name = "Olivia", LastName = "Perry", Email = "olivia@gmail.com", PhoneNumber = "48555678901", EmailValidated = true, Sex = "Female", Bio = "Hey, I'm Olivia. Fitness enthusiast and advocate!"};
            var user15 = new UserEntity { IdUser = 16, IdRole = 3, Name = "Peter", LastName = "Cooper", Email = "peter@gmail.com", PhoneNumber = "48556789012", EmailValidated = true, Sex = "Male", Bio = "Hello, I'm Peter. Let's make fitness a fun journey!"};
            var user16 = new UserEntity { IdUser = 17, IdRole = 3, Name = "Quinn", LastName = "Barnes", Email = "quinn@gmail.com", PhoneNumber = "48557890123", EmailValidated = true, Sex = "Female", Bio = "Hi, I'm Quinn. Fitness is my daily dose of happiness!"};
            var user17 = new UserEntity { IdUser = 18, IdRole = 3, Name = "Ryan", LastName = "Fisher", Email = "ryan@gmail.com", PhoneNumber = "48558901234", EmailValidated = true, Sex = "Male", Bio = "Hey, I'm Ryan. Fitness is the key to a balanced life!"};
            var user18 = new UserEntity { IdUser = 19, IdRole = 3, Name = "Sophie", LastName = "Turner", Email = "sophie@gmail.com", PhoneNumber = "48559012345", EmailValidated = true, Sex = "Female", Bio = "Hello, I'm Sophie. Let's stay fit and fabulous!"};
            var user19 = new UserEntity { IdUser = 20, IdRole = 3, Name = "Tom", LastName = "Harris", Email = "tom@gmail.com", PhoneNumber = "48550123456", EmailValidated = true, Sex = "Male", Bio = "Hi, I'm Tom. Fitness is my lifestyle choice!"};
            var user20 = new UserEntity { IdUser = 21, IdRole = 4, Name = "Filip", LastName = "W", Email = "filipwgmail.com", PhoneNumber = "48550123456", EmailValidated = true, Sex = "Male", Bio = "Hi, I'm Filip. Fitness is my hobby!"};
            var user22 = new UserEntity { IdUser = 22, IdRole = 3, Name = "test", LastName = "test", Email = "jakubs@gmail.com", PhoneNumber = "48550123456", EmailValidated = true, Sex = "Male", Bio = "Hi, I'm Jakub. Fitness is my passion!"};
            var user23 = new UserEntity { IdUser = 23, IdRole = 3, Name = "test", LastName = "test", Email = "jakubs@gmail.com", PhoneNumber = "48550123456", EmailValidated = true, Sex = "Male", Bio = "Hi, I'm Jakub. Fitness is my passion!"};
            var user24 = new UserEntity { IdUser = 24, IdRole = 3, Name = "test", LastName = "test", Email = "jakubs@gmail.com", PhoneNumber = "48550123456", EmailValidated = true, Sex = "Male", Bio = "Hi, I'm Jakub. Fitness is my passion!"};
            var user25 = new UserEntity { IdUser = 25, IdRole = 5, Name = "Dietician-Trainer", LastName = "test", Email = "jakubs@gmail.com", PhoneNumber = "48550123456", EmailValidated = true, Sex = "Male", Bio = "Hi, I'm Jakub. Fitness is my passion!"};

            var opinion = new OpinionEntity
            {
                IdPupil = 2,
                IdMentor = 1,
                Content =
                    "Jakub jest nie tylko świetnym trenerem, ale także osobą, która zawsze wierzyła we mnie i wspierała mnie w moich celach. Jego podejście do treningów było zawsze profesjonalne i skuteczne, a jednocześnie przyjazne i motywujące. Potrafił znaleźć w każdym z naszych zawodników mocne strony i pomóc nam w ich rozwijaniu.\nDzięki trenerowi Jakubowi, zdobyłem wiele umiejętności, które pomogły mi w osiągnięciu sukcesów na boisku. Jego wiedza i doświadczenie były bezcenne, a jego pozytywna energia i entuzjazm zawsze motywowały mnie do dalszej pracy i rozwoju.",
                OpinionDate = new DateTime(2023, 10, 15),
                Rate = 5
            };

            var opinion2 = new OpinionEntity
            {
                IdPupil = 3,
                IdMentor = 1,
                Content =
                    "Jakub jest nie tylko świetnym trenerem, ale także osobą, która zawsze wierzyła we mnie i wspierała mnie w moich celach. Jego podejście do treningów było zawsze profesjonalne i skuteczne, a jednocześnie przyjazne i motywujące. Potrafił znaleźć w każdym z naszych zawodników mocne strony i pomóc nam w ich rozwijaniu.\nDzięki trenerowi Jakubowi, zdobyłem wiele umiejętności, które pomogły mi w osiągnięciu sukcesów na boisku. Jego wiedza i doświadczenie były bezcenne, a jego pozytywna energia i entuzjazm zawsze motywowały mnie do dalszej pracy i rozwoju.",
                OpinionDate = new DateTime(2023, 10, 30),
                Rate = 2
            };
            var opinion3= new OpinionEntity
            {
                IdPupil = 5,
                IdMentor = 22,
                Content =
                    "Jakub jest nie tylko świetnym trenerem, ale także osobą, która zawsze wierzyła we mnie i wspierała mnie w moich celach. Jego podejście do treningów było zawsze profesjonalne i skuteczne, a jednocześnie przyjazne i motywujące. Potrafił znaleźć w każdym z naszych zawodników mocne strony i pomóc nam w ich rozwijaniu.\nDzięki trenerowi Jakubowi, zdobyłem wiele umiejętności, które pomogły mi w osiągnięciu sukcesów na boisku. Jego wiedza i doświadczenie były bezcenne, a jego pozytywna energia i entuzjazm zawsze motywowały mnie do dalszej pracy i rozwoju.",
                OpinionDate = new DateTime(2023, 10, 30),
                Rate = 4
            };
            var opinion4 = new OpinionEntity
            {
                IdPupil = 6,
                IdMentor = 22,
                Content =
                    "Jakub jest nie tylko świetnym trenerem, ale także osobą, która zawsze wierzyła we mnie i wspierała mnie w moich celach. Jego podejście do treningów było zawsze profesjonalne i skuteczne, a jednocześnie przyjazne i motywujące. Potrafił znaleźć w każdym z naszych zawodników mocne strony i pomóc nam w ich rozwijaniu.\nDzięki trenerowi Jakubowi, zdobyłem wiele umiejętności, które pomogły mi w osiągnięciu sukcesów na boisku. Jego wiedza i doświadczenie były bezcenne, a jego pozytywna energia i entuzjazm zawsze motywowały mnie do dalszej pracy i rozwoju.",
                OpinionDate = new DateTime(2023, 10, 30),
                Rate = 5
            };
            var opinion5 = new OpinionEntity
            {
                IdPupil = 7,
                IdMentor = 23,
                Content =
                    "Jakub jest nie tylko świetnym trenerem, ale także osobą, która zawsze wierzyła we mnie i wspierała mnie w moich celach. Jego podejście do treningów było zawsze profesjonalne i skuteczne, a jednocześnie przyjazne i motywujące. Potrafił znaleźć w każdym z naszych zawodników mocne strony i pomóc nam w ich rozwijaniu.\nDzięki trenerowi Jakubowi, zdobyłem wiele umiejętności, które pomogły mi w osiągnięciu sukcesów na boisku. Jego wiedza i doświadczenie były bezcenne, a jego pozytywna energia i entuzjazm zawsze motywowały mnie do dalszej pracy i rozwoju.",
                OpinionDate = new DateTime(2023, 10, 30),
                Rate = 2
            };
            var opinion6 = new OpinionEntity
            {
                IdPupil = 8,
                IdMentor = 23,
                Content =
                    "Jakub jest nie tylko świetnym trenerem, ale także osobą, która zawsze wierzyła we mnie i wspierała mnie w moich celach. Jego podejście do treningów było zawsze profesjonalne i skuteczne, a jednocześnie przyjazne i motywujące. Potrafił znaleźć w każdym z naszych zawodników mocne strony i pomóc nam w ich rozwijaniu.\nDzięki trenerowi Jakubowi, zdobyłem wiele umiejętności, które pomogły mi w osiągnięciu sukcesów na boisku. Jego wiedza i doświadczenie były bezcenne, a jego pozytywna energia i entuzjazm zawsze motywowały mnie do dalszej pracy i rozwoju.",
                OpinionDate = new DateTime(2023, 10, 30),
                Rate = 4
            };

            var exercise = new ExerciseEntity
            {
                IdExercise = 1,
                Name = "Pompki",
                Details = "Podstawowe ćwiczenie siłowe, angażuje mięśnie klatki piersiowej, ramion i tricepsa.",
                ExerciseSteps = "[{\"Step\": 1, \"Description\": \"Połóż się na podłodze na brzuchu, ręce ustawione nieco szerzej niż szerokość ramion.\"}, {\"Step\": 2, \"Description\": \"Wypnij się na rękach i naciskaj ciało do góry, wyprostowując ręce.\"}, {\"Step\": 3, \"Description\": \"Powoli wróć do pozycji wyjściowej, zginając ręce w łokciach.\"}]",
                Image = null,
                IdTrainer = 1
            };

            var exercise1 = new ExerciseEntity
            {
                IdExercise = 2,
                Name = "Przysiady",
                Details = "Ćwiczenie wzmacniające mięśnie nóg, pośladków i dolnej części pleców.",
                ExerciseSteps = "Step1: Stań prosto, nogi ustawione na szerokość bioder Step 2:" +
                                 " Opuszczaj biodra w dół, jakbyś siadał na niewidzialne krzesło " +
                                 "Step: 3,Powoli wracaj do pozycji wyjściowej, naciskając pięty w podłogę.",
                Image = null,
                IdTrainer = 1
            };

            var exercise2 = new ExerciseEntity
            {
                IdExercise = 3,
                Name = "Plank",
                Details = "Ćwiczenie wzmacniające mięśnie brzucha, pleców i ramion.",
                ExerciseSteps = "[{\"Step\": 1, \"Description\": \"Połóż się na brzuchu, opierając się na przedramionach i palcach u stóp.\"}, {\"Step\": 2, \"Description\": \"Utrzymuj prostą linię od głowy do pięt, napinając mięśnie brzucha.\"}, {\"Step\": 3, \"Description\": \"Utrzymuj tę pozycję przez określony czas.\"}]",
                Image = null,
                IdTrainer = null
            };

            var exercise3 = new ExerciseEntity
            {
                IdExercise = 14,
                Name = "Przysiady",
                Details = "Ćwiczenie wzmacniające mięśnie nóg i pośladków",
                ExerciseSteps = "1. Stań w rozkroku i ugnij nogi w kolanach",
                Image = null,
                IdTrainer = null
            };
            var exercise4 = new ExerciseEntity
            {
                IdExercise = 15,
                Name = "Pompki",
                Details = "Ćwiczenie wzmacniające mięśnie piersiowe, pleców i rąk.",
                ExerciseSteps = "W podporze przodem ugnij ręcę w łokciach",
                Image = null,
                IdTrainer = null
            };
            var exercise5 = new ExerciseEntity
            {
                IdExercise = 16,
                Name = "Boczny plank",
                Details = "Ćwiczenie wzmacniające mięśnie boczne tułowia oraz ramiona.",
                ExerciseSteps = "Połóż się na boku i podnieś biodra, tworząc prostą linię od stóp do głowy.",
                Image = null,
                IdTrainer = null
            };

            var exercise6 = new ExerciseEntity
            {
                IdExercise = 17,
                Name = "Plank z podnoszeniem nóg",
                Details = "Ćwiczenie angażujące głębokie mięśnie brzucha oraz stabilizujące biodra.",
                ExerciseSteps = "W pozycji planku na przedramionach, unieś na przemian każdą nogę.",
                Image = null,
                IdTrainer = null
            };





            var trainingPlan = new TrainingPlanEntity
            {
                IdTrainingPlan = 1,
                Name = "Plan treningowy dla początkujących",
                Type = "Siłowy",
                StartDate = new DateTime(2023, 09, 10),
                EndDate = new DateTime(2023, 09, 30),
                IdTrainer = 1,
                IdPupil = 2
            };

            var trainingPlan1 = new TrainingPlanEntity
            {
                IdTrainingPlan = 2,
                Name = "Plan treningowy na odchudzanie",
                Type = "Cardio",
                StartDate = new DateTime(2023, 10, 1),
                EndDate = new DateTime(2023, 10, 31),
                IdTrainer = 1,
                IdPupil = 2
            };



            var traineeExercise = new TraineeExerciseEntity
            {
                IdTraineeExercise = 1,
                SeriesNumber = 3,
                RepetitionsNumber = 12,
                Date = new DateTime(2023, 09, 12),
                IdExercise = 1,
                IdTrainingPlan = 1
            };

            var traineeExercise1 = new TraineeExerciseEntity
            {
                IdTraineeExercise = 2,
                SeriesNumber = 4,
                RepetitionsNumber = 10,
                Date = new DateTime(2023, 09, 15),
                IdExercise = 2,
                IdTrainingPlan = 1
            };

            var traineeExercise2 = new TraineeExerciseEntity
            {
                IdTraineeExercise = 3,
                SeriesNumber = 2,
                RepetitionsNumber = 15,
                Date = new DateTime(2023, 09, 20),
                IdExercise = 3,
                IdTrainingPlan = 2
            };

            var pupilMentor1 = new PupilMentorEntity
            {
                IdMentor = 1,
                IdPupil = 2
            };
            var pupilMentor2 = new PupilMentorEntity
            {
                IdMentor = 1,
                IdPupil = 3
            };
            modelBuilder.Entity<MealEntity>().HasData(
                new MealEntity
                {
                    IdMeal = 1,
                    IdDietician = 1,
                    Name = "Placki ziemniaczane",
                    Ingredients = "{\"ingredient1\": \"ziemniaki\", \"ingredient2\": \"cebula\", \"ingredient3\":  \"mąka\" }"
                    ,
                    PrepareSteps = "{\"test1\": \"test\", \"test2\": \"test\", \"test3\":  \"test\" }",
                    Kcal = "{\"kcal\": \"651\", \"Białko\": \"16\", \"Węglowodany\":  \"160\" , \"Tłuszcze\": \"30\" }"
                },
                new MealEntity
                {
                    IdMeal = 2,
                    IdDietician = 1,
                    Name = "Owsianka",
                    Ingredients = "{\"ingredient1\": \"platki owsiane\", \"ingredient2\": \"mleko\", \"ingredient3\":  \"cukier\" }"
                    ,
                    PrepareSteps = "{\"test1\": \"test\", \"test2\": \"test\", \"test3\":  \"test\" }",
                    Kcal = "{\"kcal\": \"765\", \"Białko\": \"20\", \"Węglowodany\":  \"165\" , \"Tłuszcze\": \"20\" }"
                },
                new MealEntity
                {
                    IdMeal = 3,
                    IdDietician = 2,
                    Name = "Kanapki z szynką",
                    Ingredients = "{\"ingredient1\": \"szynka\", \"ingredient2\": \"chleb\", \"ingredient3\":  \"masło\" }"
                    ,
                    PrepareSteps = "{\"test1\": \"test\", \"test2\": \"test\", \"test3\":  \"test\" }",
                    Kcal = "{\"kcal\": \"700\", \"Białko\": \"30\", \"Węglowodany\":  \"200\" , \"Tłuszcze\": \"26\" }"
                }
            );

            modelBuilder.Entity<DietEntity>().HasData(
                new DietEntity { IdDiet = 1, IdDietician = 1, IdPupil = 2, StartDate = new DateTime(2023, 12, 20), EndDate = new DateTime(2023, 12, 20), DietDuration = "1", TotalKcal = 3000 },
                new DietEntity { IdDiet = 2, IdDietician = 1, IdPupil = 2, StartDate = new DateTime(2023, 10, 20), EndDate = new DateTime(2023, 11, 20), DietDuration = "30", TotalKcal = 2000 },
                new DietEntity { IdDiet = 3, IdDietician = 1, IdPupil = 2, StartDate = new DateTime(2023, 11, 30), EndDate = new DateTime(2023, 12, 30), DietDuration = "30", TotalKcal = 2500 }
            );
            modelBuilder.Entity<MealDietEntity>().HasData(
                new MealDietEntity { IdMealDiet = 1, IdMeal = 1, IdDiet = 1, Date = new DateTime(2023, 12, 07) },
                new MealDietEntity { IdMealDiet = 2, IdMeal = 2, IdDiet = 1, Date = new DateTime(2023, 6, 07) },
                new MealDietEntity
                {
                    IdMealDiet = 3,
                    IdMeal = 1,
                    IdDiet = 2,
                    Date = new DateTime(2023, 5, 07),
                });

            //generate 3 records for each model: GymEntity, Trainer_Gym, give random gym names
            for (int i = 1; i <= 3; i++)
            {
                modelBuilder.Entity<GymEntity>().HasData(
                                       new GymEntity { IdGym = i, IdAddress = i, Name = "GymEntity" + i }
                                                      );
                modelBuilder.Entity<TrainerGymEntity>().HasData(
                                       new TrainerGymEntity { IdTrainer = i, IdGym = i }
                                                      );
            }


            modelBuilder.Entity<DietEntity>()
                .HasOne(d => d.Dietician)
                .WithMany(u => u.DietsAsDietician)
                .HasForeignKey(d => d.IdDietician);

            modelBuilder.Entity<DietEntity>()
                .HasOne(d => d.Pupil)
                .WithMany(u => u.DietsAsPupil)
                .HasForeignKey(d => d.IdPupil);

            modelBuilder.Entity<AddressEntity>().HasData(address, address2, address3);
            modelBuilder.Entity<OpinionEntity>().HasData(opinion, opinion2,opinion3,opinion4,opinion5,opinion6);
            modelBuilder.Entity<UserEntity>().HasData(user, user1, user2,user3, user4,user5,user6,user7,user8,user9,user10,user11,user12,user13,user14,user15,user16,user17,user18,user19,user20,user22,user23,user24, user25);
            modelBuilder.Entity<ExerciseEntity>().HasData(exercise, exercise1, exercise2, exercise3, exercise4, exercise5, exercise6);
            modelBuilder.Entity<TrainingPlanEntity>().HasData(trainingPlan, trainingPlan1);
            modelBuilder.Entity<TraineeExerciseEntity>().HasData(traineeExercise, traineeExercise1, traineeExercise2);
            modelBuilder.Entity<PupilMentorEntity>().HasData(pupilMentor1, pupilMentor2);
            modelBuilder.Entity<PupilMentorEntity>().HasKey(pm => new {Id_Mentor = pm.IdMentor, Id_Pupil = pm.IdPupil });
            modelBuilder.Entity<MealDietEntity>().HasKey(md => new {Id_Meal = md.IdMeal, Id_Diet = md.IdDiet });
            modelBuilder.Entity<OpinionEntity>().HasKey(o => new {Id_Pupil = o.IdPupil, Id_Mentor = o.IdMentor });
            modelBuilder.Entity<TrainerGymEntity>().HasKey(o => new {Id_Gym = o.IdGym, Id_Trainer = o.IdTrainer});
            modelBuilder.Entity<RoleEntity>().HasData(roles);
            base.OnModelCreating(modelBuilder);
        }
    }
}
