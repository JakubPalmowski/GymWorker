using Microsoft.EntityFrameworkCore;
using Training_and_diet_backend.Models;
using TrainingAndDietApp.Domain.Entities;

namespace TrainingAndDietApp.Infrastructure.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
        {

        }

        public DbSet<Exercise> Exercises { get; set; }
        public DbSet<TraineeExercise> Trainee_exercises { get; set; }
        public DbSet<TrainingPlan> Training_plans { get; set; }
        public DbSet<PupilMentor> Pupil_mentors { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Meal> Meals { get; set; }
        public DbSet<MealDiet> Meal_Diets { get; set; }
        public DbSet<Diet> Diets { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Opinion> Opinions { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Gym> Gyms { get; set; }
        public DbSet<TrainerGym> Trainer_Gyms { get; set; }
        public DbSet<Certificate> Certificates { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            var roles = new List<Role>()
             {
                 new Role()
                 {
                     Id = 1,
                     Name = "Admin"
                 },
                 new Role()
                 {
                     Id = 2,
                     Name = "Pupil"
                 },
                 new Role()
                 {
                     Id = 3,
                     Name = "Trainer"
                 },
                 new Role()
                 {
                     Id = 4,
                     Name = "Dietician"
                 },
                 new Role()
                 {
                     Id = 5,
                     Name = "Dietician-Trainer"
                 }
             };

            var hashedPassword = "adsas321312dasasdasdajgfasdjiasijdasujnasd";

            var address = new Address { IdAddress = 1, City = "Warszawa", PostalCode = "02-222", Street = "Zlota" };
            var address2 = new Address { IdAddress = 2, City = "Białystok", PostalCode = "02-324", Street = "Kryształowa" };
            var address3 = new Address { IdAddress = 3, City = "Kraków", PostalCode = "02-421", Street = "Mendelejewa" };

            var user = new User { IdUser = 1, IdRole = 1, Name = "Michał", LastName = "Emczyk", Email = "michal@gmail.com", PhoneNumber = "48777888777",  Sex = "Male", Bio = "Cześć jestem Kuba i dużo trenuje. Zapraszam na treningi indywidualne", HashedPassword = hashedPassword};
            var user1 = new User { IdUser = 2, IdRole = 2, Name = "Anna", LastName = "Kowalska", Email = "anna@gmail.com", PhoneNumber = "48666778888", Sex = "Female", Bio = "Cześć jestem Kuba i dużo trenuje. Zapraszam na treningi indywidualne", HashedPassword = hashedPassword };
            var user2 = new User { IdUser = 3, IdRole = 3, Name = "John", LastName = "Doe", Email = "john@gmail.com", PhoneNumber = "48555667777",  Sex = "Male", Bio = "Cześć jestem Kuba i dużo trenuje. Zapraszam na treningi indywidualne", HashedPassword = hashedPassword };
            var user3 = new User { IdUser = 4, IdRole = 3, Name = "Charlie", LastName = "Brown", Email = "charlie@gmail.com", PhoneNumber = "48554567890",  Sex = "Male", Bio = "Hi, I'm Charlie. Let's stay active and have fun!", HashedPassword = hashedPassword };
            var user4 = new User { IdUser = 5, IdRole = 3, Name = "Diana", LastName = "Miller", Email = "diana@gmail.com", PhoneNumber = "48555678901",  Sex = "Female", Bio = "Hello, I'm Diana. Fitness is my passion!", HashedPassword = hashedPassword };
            var user5 = new User { IdUser = 6, IdRole = 3, Name = "Frank", LastName = "Davis", Email = "frank@gmail.com", PhoneNumber = "48556789012",  Sex = "Male", Bio = "Hi, I'm Frank. Let's achieve our fitness goals together!", HashedPassword = hashedPassword };
            var user6 = new User { IdUser = 7, IdRole = 3, Name = "Grace", LastName = "Anderson", Email = "grace@gmail.com", PhoneNumber = "48557890123",  Sex = "Female", Bio = "Hello, I'm Grace. Fitness is my lifestyle!", HashedPassword = hashedPassword };
            var user7=new User { IdUser = 8, IdRole = 3, Name = "Harry", LastName = "Moore", Email = "harry@gmail.com", PhoneNumber = "48558901234", Sex = "Male", Bio = "Hey, I'm Harry. Let's push our limits in every workout!", HashedPassword = hashedPassword };
            var user8 = new User { IdUser = 9, IdRole = 3, Name = "Ivy", LastName = "Turner", Email = "ivy@gmail.com", PhoneNumber = "48559012345",  Sex = "Female", Bio = "Hi, I'm Ivy. Fitness is my passion and I'm here to inspire!", HashedPassword = hashedPassword };
            var user9 = new User { IdUser = 10, IdRole = 3, Name = "Jack", LastName = "White", Email = "jack@gmail.com", PhoneNumber = "48550123456",  Sex = "Male", Bio = "Hello, I'm Jack. Let's make every workout count!", HashedPassword = hashedPassword };
            var user10 = new User { IdUser = 11, IdRole = 3, Name = "Kelly", LastName = "Martin", Email = "kelly@gmail.com", PhoneNumber = "48551234567",  Sex = "Female", Bio = "Hi, I'm Kelly. Fitness is the key to a healthy life!", HashedPassword = hashedPassword };
            var user11 = new User { IdUser = 12, IdRole = 3, Name = "Leo", LastName = "Baker", Email = "leo@gmail.com", PhoneNumber = "48552345678", Sex = "Male", Bio = "Hey, I'm Leo. Let's crush our fitness goals!", HashedPassword = hashedPassword };
            var user12 = new User { IdUser = 13, IdRole = 3, Name = "Mia", LastName = "Collins", Email = "mia@gmail.com", PhoneNumber = "48553456789",  Sex = "Female", Bio = "Hello, I'm Mia. Fitness is not just a hobby, it's a way of life!", HashedPassword = hashedPassword };
            var user13 = new User { IdUser = 14, IdRole = 3, Name = "Nathan", LastName = "Ward", Email = "nathan@gmail.com", PhoneNumber = "48554567890",  Sex = "Male", Bio = "Hi, I'm Nathan. Let's embrace a fit and healthy lifestyle!", HashedPassword = hashedPassword };
            var user14 = new User { IdUser = 15, IdRole = 3, Name = "Olivia", LastName = "Perry", Email = "olivia@gmail.com", PhoneNumber = "48555678901",Sex = "Female", Bio = "Hey, I'm Olivia. Fitness enthusiast and advocate!", HashedPassword = hashedPassword };
            var user15 = new User { IdUser = 16, IdRole = 3, Name = "Peter", LastName = "Cooper", Email = "peter@gmail.com", PhoneNumber = "48556789012",  Sex = "Male", Bio = "Hello, I'm Peter. Let's make fitness a fun journey!", HashedPassword = hashedPassword };
            var user16 = new User { IdUser = 17, IdRole = 3, Name = "Quinn", LastName = "Barnes", Email = "quinn@gmail.com", PhoneNumber = "48557890123", Sex = "Female", Bio = "Hi, I'm Quinn. Fitness is my daily dose of happiness!", HashedPassword = hashedPassword };
            var user17 = new User { IdUser = 18, IdRole = 3, Name = "Ryan", LastName = "Fisher", Email = "ryan@gmail.com", PhoneNumber = "48558901234", Sex = "Male", Bio = "Hey, I'm Ryan. Fitness is the key to a balanced life!", HashedPassword = hashedPassword };
            var user18 = new User { IdUser = 19, IdRole = 3, Name = "Sophie", LastName = "Turner", Email = "sophie@gmail.com", PhoneNumber = "48559012345",  Sex = "Female", Bio = "Hello, I'm Sophie. Let's stay fit and fabulous!", HashedPassword = hashedPassword };
            var user19 = new User { IdUser = 20, IdRole = 3, Name = "Tom", LastName = "Harris", Email = "tom@gmail.com", PhoneNumber = "48550123456",  Sex = "Male", Bio = "Hi, I'm Tom. Fitness is my lifestyle choice!", HashedPassword = hashedPassword };
            var user20 = new User { IdUser = 21, IdRole = 4, Name = "Filip", LastName = "W", Email = "filipwgmail.com", PhoneNumber = "48550123456",  Sex = "Male", Bio = "Hi, I'm Filip. Fitness is my hobby!", HashedPassword = hashedPassword};
            var user22 = new User { IdUser = 22, IdRole = 3, Name = "test", LastName = "test", Email = "jakubs@gmail.com", PhoneNumber = "48550123456", Sex = "Male", Bio = "Hi, I'm Jakub. Fitness is my passion!", HashedPassword = hashedPassword };
            var user23 = new User { IdUser = 23, IdRole = 3, Name = "test", LastName = "test", Email = "jakubs@gmail.com", PhoneNumber = "48550123456", Sex = "Male", Bio = "Hi, I'm Jakub. Fitness is my passion!", HashedPassword = hashedPassword };
            var user24 = new User { IdUser = 24, IdRole = 3, Name = "test", LastName = "test", Email = "jakubs@gmail.com", PhoneNumber = "48550123456",  Sex = "Male", Bio = "Hi, I'm Jakub. Fitness is my passion!", HashedPassword = hashedPassword };
            var user25 = new User { IdUser = 25, IdRole = 5, Name = "Dietician-Trainer", LastName = "test", Email = "jakubs@gmail.com", PhoneNumber = "48550123456",  Sex = "Male", Bio = "Hi, I'm Jakub. Fitness is my passion!", HashedPassword = hashedPassword };

            var opinion = new Opinion
            {
                IdPupil = 2,
                IdMentor = 1,
                Content =
                    "Jakub jest nie tylko świetnym trenerem, ale także osobą, która zawsze wierzyła we mnie i wspierała mnie w moich celach. Jego podejście do treningów było zawsze profesjonalne i skuteczne, a jednocześnie przyjazne i motywujące. Potrafił znaleźć w każdym z naszych zawodników mocne strony i pomóc nam w ich rozwijaniu.\nDzięki trenerowi Jakubowi, zdobyłem wiele umiejętności, które pomogły mi w osiągnięciu sukcesów na boisku. Jego wiedza i doświadczenie były bezcenne, a jego pozytywna energia i entuzjazm zawsze motywowały mnie do dalszej pracy i rozwoju.",
                OpinionDate = new DateTime(2023, 10, 15),
                Rate = 5
            };

            var opinion2 = new Opinion
            {
                IdPupil = 3,
                IdMentor = 1,
                Content =
                    "Jakub jest nie tylko świetnym trenerem, ale także osobą, która zawsze wierzyła we mnie i wspierała mnie w moich celach. Jego podejście do treningów było zawsze profesjonalne i skuteczne, a jednocześnie przyjazne i motywujące. Potrafił znaleźć w każdym z naszych zawodników mocne strony i pomóc nam w ich rozwijaniu.\nDzięki trenerowi Jakubowi, zdobyłem wiele umiejętności, które pomogły mi w osiągnięciu sukcesów na boisku. Jego wiedza i doświadczenie były bezcenne, a jego pozytywna energia i entuzjazm zawsze motywowały mnie do dalszej pracy i rozwoju.",
                OpinionDate = new DateTime(2023, 10, 30),
                Rate = 2
            };
            var opinion3= new Opinion
            {
                IdPupil = 5,
                IdMentor = 22,
                Content =
                    "Jakub jest nie tylko świetnym trenerem, ale także osobą, która zawsze wierzyła we mnie i wspierała mnie w moich celach. Jego podejście do treningów było zawsze profesjonalne i skuteczne, a jednocześnie przyjazne i motywujące. Potrafił znaleźć w każdym z naszych zawodników mocne strony i pomóc nam w ich rozwijaniu.\nDzięki trenerowi Jakubowi, zdobyłem wiele umiejętności, które pomogły mi w osiągnięciu sukcesów na boisku. Jego wiedza i doświadczenie były bezcenne, a jego pozytywna energia i entuzjazm zawsze motywowały mnie do dalszej pracy i rozwoju.",
                OpinionDate = new DateTime(2023, 10, 30),
                Rate = 4
            };
            var opinion4 = new Opinion
            {
                IdPupil = 6,
                IdMentor = 22,
                Content =
                    "Jakub jest nie tylko świetnym trenerem, ale także osobą, która zawsze wierzyła we mnie i wspierała mnie w moich celach. Jego podejście do treningów było zawsze profesjonalne i skuteczne, a jednocześnie przyjazne i motywujące. Potrafił znaleźć w każdym z naszych zawodników mocne strony i pomóc nam w ich rozwijaniu.\nDzięki trenerowi Jakubowi, zdobyłem wiele umiejętności, które pomogły mi w osiągnięciu sukcesów na boisku. Jego wiedza i doświadczenie były bezcenne, a jego pozytywna energia i entuzjazm zawsze motywowały mnie do dalszej pracy i rozwoju.",
                OpinionDate = new DateTime(2023, 10, 30),
                Rate = 5
            };
            var opinion5 = new Opinion
            {
                IdPupil = 7,
                IdMentor = 23,
                Content =
                    "Jakub jest nie tylko świetnym trenerem, ale także osobą, która zawsze wierzyła we mnie i wspierała mnie w moich celach. Jego podejście do treningów było zawsze profesjonalne i skuteczne, a jednocześnie przyjazne i motywujące. Potrafił znaleźć w każdym z naszych zawodników mocne strony i pomóc nam w ich rozwijaniu.\nDzięki trenerowi Jakubowi, zdobyłem wiele umiejętności, które pomogły mi w osiągnięciu sukcesów na boisku. Jego wiedza i doświadczenie były bezcenne, a jego pozytywna energia i entuzjazm zawsze motywowały mnie do dalszej pracy i rozwoju.",
                OpinionDate = new DateTime(2023, 10, 30),
                Rate = 2
            };
            var opinion6 = new Opinion
            {
                IdPupil = 8,
                IdMentor = 23,
                Content =
                    "Jakub jest nie tylko świetnym trenerem, ale także osobą, która zawsze wierzyła we mnie i wspierała mnie w moich celach. Jego podejście do treningów było zawsze profesjonalne i skuteczne, a jednocześnie przyjazne i motywujące. Potrafił znaleźć w każdym z naszych zawodników mocne strony i pomóc nam w ich rozwijaniu.\nDzięki trenerowi Jakubowi, zdobyłem wiele umiejętności, które pomogły mi w osiągnięciu sukcesów na boisku. Jego wiedza i doświadczenie były bezcenne, a jego pozytywna energia i entuzjazm zawsze motywowały mnie do dalszej pracy i rozwoju.",
                OpinionDate = new DateTime(2023, 10, 30),
                Rate = 4
            };

            var exercise = new Exercise
            {
                IdExercise = 1,
                Name = "Pompki",
                Details = "Podstawowe ćwiczenie siłowe, angażuje mięśnie klatki piersiowej, ramion i tricepsa.",
                ExerciseSteps = "[{\"Step\": 1, \"Description\": \"Połóż się na podłodze na brzuchu, ręce ustawione nieco szerzej niż szerokość ramion.\"}, {\"Step\": 2, \"Description\": \"Wypnij się na rękach i naciskaj ciało do góry, wyprostowując ręce.\"}, {\"Step\": 3, \"Description\": \"Powoli wróć do pozycji wyjściowej, zginając ręce w łokciach.\"}]",
                IdTrainer = 1
            };

            var exercise1 = new Exercise
            {
                IdExercise = 2,
                Name = "Przysiady",
                Details = "Ćwiczenie wzmacniające mięśnie nóg, pośladków i dolnej części pleców.",
                ExerciseSteps = "Step1: Stań prosto, nogi ustawione na szerokość bioder Step 2:" +
                                 " Opuszczaj biodra w dół, jakbyś siadał na niewidzialne krzesło " +
                                 "Step: 3,Powoli wracaj do pozycji wyjściowej, naciskając pięty w podłogę.",
                IdTrainer = 1
            };

            var exercise2 = new Exercise
            {
                IdExercise = 3,
                Name = "Plank",
                Details = "Ćwiczenie wzmacniające mięśnie brzucha, pleców i ramion.",
                ExerciseSteps = "[{\"Step\": 1, \"Description\": \"Połóż się na brzuchu, opierając się na przedramionach i palcach u stóp.\"}, {\"Step\": 2, \"Description\": \"Utrzymuj prostą linię od głowy do pięt, napinając mięśnie brzucha.\"}, {\"Step\": 3, \"Description\": \"Utrzymuj tę pozycję przez określony czas.\"}]",
                IdTrainer = null
            };

            var exercise3 = new Exercise
            {
                IdExercise = 14,
                Name = "Przysiady",
                Details = "Ćwiczenie wzmacniające mięśnie nóg i pośladków",
                ExerciseSteps = "1. Stań w rozkroku i ugnij nogi w kolanach",
                IdTrainer = null
            };
            var exercise4 = new Exercise
            {
                IdExercise = 15,
                Name = "Pompki",
                Details = "Ćwiczenie wzmacniające mięśnie piersiowe, pleców i rąk.",
                ExerciseSteps = "W podporze przodem ugnij ręcę w łokciach",
                IdTrainer = null
            };
            var exercise5 = new Exercise
            {
                IdExercise = 16,
                Name = "Boczny plank",
                Details = "Ćwiczenie wzmacniające mięśnie boczne tułowia oraz ramiona.",
                ExerciseSteps = "Połóż się na boku i podnieś biodra, tworząc prostą linię od stóp do głowy.",
                IdTrainer = null
            };

            var exercise6 = new Exercise
            {
                IdExercise = 17,
                Name = "Plank z podnoszeniem nóg",
                Details = "Ćwiczenie angażujące głębokie mięśnie brzucha oraz stabilizujące biodra.",
                ExerciseSteps = "W pozycji planku na przedramionach, unieś na przemian każdą nogę.",
                IdTrainer = null
            };





            var trainingPlan = new TrainingPlan
            {
                IdTrainingPlan = 1,
                Name = "Plan treningowy dla początkujących",
                CustomName = "Plan treningowy dla mirka",
                Type = "Siłowy",
                StartDate = new DateTime(2023, 09, 10),
                IdTrainer = 1,
                IdPupil = 2
            };

            var trainingPlan1 = new TrainingPlan
            {
                IdTrainingPlan = 2,
                Name = "Plan treningowy na odchudzanie",
                CustomName = "Plan treningowy dla jacka",
                Type = "Cardio",
                StartDate = new DateTime(2023, 10, 1),
                IdTrainer = 1,
                IdPupil = 2
            };



            var traineeExercise = new TraineeExercise
            {
                IdTraineeExercise = 1,
                SeriesNumber = 3,
                RepetitionsNumber = "12",
                DayOfWeek = DayOfWeek.Friday,
                IdExercise = 1,
                IdTrainingPlan = 1
            };

            var traineeExercise1 = new TraineeExercise
            {
                IdTraineeExercise = 2,
                SeriesNumber = 4,
                RepetitionsNumber = "10",
                DayOfWeek = DayOfWeek.Monday,
                IdExercise = 2,
                IdTrainingPlan = 1
            };

            var traineeExercise2 = new TraineeExercise
            {
                IdTraineeExercise = 3,
                SeriesNumber = 2,
                RepetitionsNumber = "15",
                DayOfWeek = DayOfWeek.Tuesday,
                IdExercise = 3,
                IdTrainingPlan = 2
            };

            var pupilMentor1 = new PupilMentor
            {
                IdMentor = 1,
                IdPupil = 2
            };
            var pupilMentor2 = new PupilMentor
            {
                IdMentor = 1,
                IdPupil = 3
            };
            modelBuilder.Entity<Meal>().HasData(
                new Meal
                {
                    IdMeal = 1,
                    IdDietician = 1,
                    Name = "Placki ziemniaczane",
                    Ingredients = "{\"ingredient1\": \"ziemniaki\", \"ingredient2\": \"cebula\", \"ingredient3\":  \"mąka\" }"
                    ,
                    PrepareSteps = "{\"test1\": \"test\", \"test2\": \"test\", \"test3\":  \"test\" }",
                    Kcal = "{\"kcal\": \"651\", \"Białko\": \"16\", \"Węglowodany\":  \"160\" , \"Tłuszcze\": \"30\" }"
                },
                new Meal
                {
                    IdMeal = 2,
                    IdDietician = 1,
                    Name = "Owsianka",
                    Ingredients = "{\"ingredient1\": \"platki owsiane\", \"ingredient2\": \"mleko\", \"ingredient3\":  \"cukier\" }"
                    ,
                    PrepareSteps = "{\"test1\": \"test\", \"test2\": \"test\", \"test3\":  \"test\" }",
                    Kcal = "{\"kcal\": \"765\", \"Białko\": \"20\", \"Węglowodany\":  \"165\" , \"Tłuszcze\": \"20\" }"
                },
                new Meal
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

            modelBuilder.Entity<Diet>().HasData(
                new Diet { IdDiet = 1, IdDietician = 1, IdPupil = 2, StartDate = new DateTime(2023, 12, 20), NumberOfWeeks=4, TotalKcal = 3000, Type="Siłowy", Name="Plan treningowy dla początkujących", CustomName="Plan treningowy dla mirka"},
                new Diet { IdDiet = 2, IdDietician = 1, IdPupil = 2, StartDate = new DateTime(2023, 10, 20), NumberOfWeeks=4, TotalKcal = 2000, Type="Cardio", Name="Plan treningowy na odchudzanie", CustomName="Plan treningowy dla jacka"},
                new Diet { IdDiet = 3, IdDietician = 1, IdPupil = 2, StartDate = new DateTime(2023, 11, 30), NumberOfWeeks=4, TotalKcal = 2500, Type="Siłowy", Name="Plan treningowy dla początkujących", CustomName="Plan treningowy dla Wlodara"}
            );
            modelBuilder.Entity<MealDiet>().HasData(
                new MealDiet { IdMealDiet = 1, IdMeal = 1, IdDiet = 1, DayOfWeek = 1, HourOfMeal = "12:00", Comments = "Jedz sobie"},
                new MealDiet { IdMealDiet = 2, IdMeal = 2, IdDiet = 1, DayOfWeek = 2, HourOfMeal = "12:00"},
                new MealDiet
                {
                    IdMealDiet = 3,
                    IdMeal = 1,
                    IdDiet = 2,
                    DayOfWeek = 1,
                    HourOfMeal = "12:00"

                });

            //generate 3 records for each model: Gym, Trainer_Gym, give random gym names
            for (int i = 1; i <= 3; i++)
            {
                modelBuilder.Entity<Gym>().HasData(
                                       new Gym { IdGym = i, IdAddress = i, Name = "Gym" + i }
                                                      );
                modelBuilder.Entity<TrainerGym>().HasData(
                                       new TrainerGym { IdTrainer = i, IdGym = i }
                                                      );
            }


            modelBuilder.Entity<Diet>()
                .HasOne(d => d.Dietician)
                .WithMany(u => u.DietsAsDietician)
                .HasForeignKey(d => d.IdDietician);

            modelBuilder.Entity<Diet>()
                .HasOne(d => d.Pupil)
                .WithMany(u => u.DietsAsPupil) 
                .HasForeignKey(d => d.IdPupil) 
                .IsRequired(false);





            modelBuilder.Entity<Address>().HasData(address, address2, address3);
            modelBuilder.Entity<Opinion>().HasData(opinion, opinion2,opinion3,opinion4,opinion5,opinion6);
            modelBuilder.Entity<User>().HasData(user, user1, user2,user3, user4,user5,user6,user7,user8,user9,user10,user11,user12,user13,user14,user15,user16,user17,user18,user19,user20,user22,user23,user24, user25);
            modelBuilder.Entity<Exercise>().HasData(exercise, exercise1, exercise2, exercise3, exercise4, exercise5, exercise6);
            modelBuilder.Entity<TrainingPlan>().HasData(trainingPlan, trainingPlan1);
            modelBuilder.Entity<TraineeExercise>().HasData(traineeExercise, traineeExercise1, traineeExercise2);
            modelBuilder.Entity<PupilMentor>().HasData(pupilMentor1, pupilMentor2);
            modelBuilder.Entity<PupilMentor>().HasKey(pm => new {Id_Mentor = pm.IdMentor, Id_Pupil = pm.IdPupil });
            modelBuilder.Entity<MealDiet>().HasKey(md => new {Id_Meal = md.IdMeal, Id_Diet = md.IdDiet });
            modelBuilder.Entity<Opinion>().HasKey(o => new {Id_Pupil = o.IdPupil, Id_Mentor = o.IdMentor });
            modelBuilder.Entity<TrainerGym>().HasKey(tg => new { tg.IdGym, tg.IdTrainer });
            modelBuilder.Entity<Role>().HasData(roles);
            base.OnModelCreating(modelBuilder);
        }
    }
}
