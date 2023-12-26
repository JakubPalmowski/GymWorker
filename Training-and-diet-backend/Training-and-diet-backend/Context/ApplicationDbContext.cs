using Microsoft.EntityFrameworkCore;
using Training_and_diet_backend.Models;

namespace Training_and_diet_backend.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
        {

        }

        public DbSet<Exercise> Exercises { get; set; }
        public DbSet<Trainee_exercise> Trainee_exercises { get; set; }
        public DbSet<Training_plan> Training_plans { get; set; }
        public DbSet<Pupil_mentor> Pupil_mentors { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Meal> Meals { get; set; }
        public DbSet<Meal_Diet> Meal_Diets { get; set; }
        public DbSet<Diet> Diets { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Opinion> Opinions { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Gym> Gyms { get; set; }
        public DbSet<Trainer_Gym> Trainer_Gyms { get; set; }

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

            var address = new Address { Id_Address = 1, City = "Warszawa", Postal_code = "02-222", Street = "Zlota" };
            var address2 = new Address { Id_Address = 2, City = "Białystok", Postal_code = "02-324", Street = "Kryształowa" };
            var address3 = new Address { Id_Address = 3, City = "Kraków", Postal_code = "02-421", Street = "Mendelejewa" };

            var user = new User { Id_User = 1, Id_Role = 1, Name = "Michał", Last_name = "Emczyk", Email = "michal@gmail.com", Phone_number = "48777888777", Email_validated = true, Sex = "Male", Bio = "Cześć jestem Kuba i dużo trenuje. Zapraszam na treningi indywidualne"};
            var user1 = new User { Id_User = 2, Id_Role = 2, Name = "Anna", Last_name = "Kowalska", Email = "anna@gmail.com", Phone_number = "48666778888", Email_validated = true, Sex = "Female", Bio = "Cześć jestem Kuba i dużo trenuje. Zapraszam na treningi indywidualne"};
            var user2 = new User { Id_User = 3, Id_Role = 3, Name = "John", Last_name = "Doe", Email = "john@gmail.com", Phone_number = "48555667777", Email_validated = true, Sex = "Male", Bio = "Cześć jestem Kuba i dużo trenuje. Zapraszam na treningi indywidualne"};
            var user3 = new User { Id_User = 4, Id_Role = 3, Name = "Charlie", Last_name = "Brown", Email = "charlie@gmail.com", Phone_number = "48554567890", Email_validated = true, Sex = "Male", Bio = "Hi, I'm Charlie. Let's stay active and have fun!"};
            var user4 = new User { Id_User = 5, Id_Role = 3, Name = "Diana", Last_name = "Miller", Email = "diana@gmail.com", Phone_number = "48555678901", Email_validated = true, Sex = "Female", Bio = "Hello, I'm Diana. Fitness is my passion!"};
            var user5 = new User { Id_User = 6, Id_Role = 3, Name = "Frank", Last_name = "Davis", Email = "frank@gmail.com", Phone_number = "48556789012", Email_validated = true, Sex = "Male", Bio = "Hi, I'm Frank. Let's achieve our fitness goals together!"};
            var user6 = new User { Id_User = 7, Id_Role = 3, Name = "Grace", Last_name = "Anderson", Email = "grace@gmail.com", Phone_number = "48557890123", Email_validated = true, Sex = "Female", Bio = "Hello, I'm Grace. Fitness is my lifestyle!"};
            var user7=new User { Id_User = 8, Id_Role = 3, Name = "Harry", Last_name = "Moore", Email = "harry@gmail.com", Phone_number = "48558901234", Email_validated = true, Sex = "Male", Bio = "Hey, I'm Harry. Let's push our limits in every workout!"};
            var user8 = new User { Id_User = 9, Id_Role = 3, Name = "Ivy", Last_name = "Turner", Email = "ivy@gmail.com", Phone_number = "48559012345", Email_validated = true, Sex = "Female", Bio = "Hi, I'm Ivy. Fitness is my passion and I'm here to inspire!"};
            var user9 = new User { Id_User = 10, Id_Role = 3, Name = "Jack", Last_name = "White", Email = "jack@gmail.com", Phone_number = "48550123456", Email_validated = true, Sex = "Male", Bio = "Hello, I'm Jack. Let's make every workout count!"};
            var user10 = new User { Id_User = 11, Id_Role = 3, Name = "Kelly", Last_name = "Martin", Email = "kelly@gmail.com", Phone_number = "48551234567", Email_validated = true, Sex = "Female", Bio = "Hi, I'm Kelly. Fitness is the key to a healthy life!"};
            var user11 = new User { Id_User = 12, Id_Role = 3, Name = "Leo", Last_name = "Baker", Email = "leo@gmail.com", Phone_number = "48552345678", Email_validated = true, Sex = "Male", Bio = "Hey, I'm Leo. Let's crush our fitness goals!"};
            var user12 = new User { Id_User = 13, Id_Role = 3, Name = "Mia", Last_name = "Collins", Email = "mia@gmail.com", Phone_number = "48553456789", Email_validated = true, Sex = "Female", Bio = "Hello, I'm Mia. Fitness is not just a hobby, it's a way of life!"};
            var user13 = new User { Id_User = 14, Id_Role = 3, Name = "Nathan", Last_name = "Ward", Email = "nathan@gmail.com", Phone_number = "48554567890", Email_validated = true, Sex = "Male", Bio = "Hi, I'm Nathan. Let's embrace a fit and healthy lifestyle!"};
            var user14 = new User { Id_User = 15, Id_Role = 3, Name = "Olivia", Last_name = "Perry", Email = "olivia@gmail.com", Phone_number = "48555678901", Email_validated = true, Sex = "Female", Bio = "Hey, I'm Olivia. Fitness enthusiast and advocate!"};
            var user15 = new User { Id_User = 16, Id_Role = 3, Name = "Peter", Last_name = "Cooper", Email = "peter@gmail.com", Phone_number = "48556789012", Email_validated = true, Sex = "Male", Bio = "Hello, I'm Peter. Let's make fitness a fun journey!"};
            var user16 = new User { Id_User = 17, Id_Role = 3, Name = "Quinn", Last_name = "Barnes", Email = "quinn@gmail.com", Phone_number = "48557890123", Email_validated = true, Sex = "Female", Bio = "Hi, I'm Quinn. Fitness is my daily dose of happiness!"};
            var user17 = new User { Id_User = 18, Id_Role = 3, Name = "Ryan", Last_name = "Fisher", Email = "ryan@gmail.com", Phone_number = "48558901234", Email_validated = true, Sex = "Male", Bio = "Hey, I'm Ryan. Fitness is the key to a balanced life!"};
            var user18 = new User { Id_User = 19, Id_Role = 3, Name = "Sophie", Last_name = "Turner", Email = "sophie@gmail.com", Phone_number = "48559012345", Email_validated = true, Sex = "Female", Bio = "Hello, I'm Sophie. Let's stay fit and fabulous!"};
            var user19 = new User { Id_User = 20, Id_Role = 3, Name = "Tom", Last_name = "Harris", Email = "tom@gmail.com", Phone_number = "48550123456", Email_validated = true, Sex = "Male", Bio = "Hi, I'm Tom. Fitness is my lifestyle choice!"};
            var user20 = new User { Id_User = 21, Id_Role = 4, Name = "Filip", Last_name = "W", Email = "filipwgmail.com", Phone_number = "48550123456", Email_validated = true, Sex = "Male", Bio = "Hi, I'm Filip. Fitness is my hobby!"};
            var user22 = new User { Id_User = 22, Id_Role = 3, Name = "test", Last_name = "test", Email = "jakubs@gmail.com", Phone_number = "48550123456", Email_validated = true, Sex = "Male", Bio = "Hi, I'm Jakub. Fitness is my passion!"};
            var user23 = new User { Id_User = 23, Id_Role = 3, Name = "test", Last_name = "test", Email = "jakubs@gmail.com", Phone_number = "48550123456", Email_validated = true, Sex = "Male", Bio = "Hi, I'm Jakub. Fitness is my passion!"};
            var user24 = new User { Id_User = 24, Id_Role = 3, Name = "test", Last_name = "test", Email = "jakubs@gmail.com", Phone_number = "48550123456", Email_validated = true, Sex = "Male", Bio = "Hi, I'm Jakub. Fitness is my passion!"};
            var user25 = new User { Id_User = 25, Id_Role = 5, Name = "Dietician-Trainer", Last_name = "test", Email = "jakubs@gmail.com", Phone_number = "48550123456", Email_validated = true, Sex = "Male", Bio = "Hi, I'm Jakub. Fitness is my passion!"};

            var opinion = new Opinion
            {
                Id_Pupil = 2,
                Id_Mentor = 1,
                Content =
                    "Jakub jest nie tylko świetnym trenerem, ale także osobą, która zawsze wierzyła we mnie i wspierała mnie w moich celach. Jego podejście do treningów było zawsze profesjonalne i skuteczne, a jednocześnie przyjazne i motywujące. Potrafił znaleźć w każdym z naszych zawodników mocne strony i pomóc nam w ich rozwijaniu.\nDzięki trenerowi Jakubowi, zdobyłem wiele umiejętności, które pomogły mi w osiągnięciu sukcesów na boisku. Jego wiedza i doświadczenie były bezcenne, a jego pozytywna energia i entuzjazm zawsze motywowały mnie do dalszej pracy i rozwoju.",
                Opinion_date = new DateTime(2023, 10, 15),
                Rate = 5
            };

            var opinion2 = new Opinion
            {
                Id_Pupil = 3,
                Id_Mentor = 1,
                Content =
                    "Jakub jest nie tylko świetnym trenerem, ale także osobą, która zawsze wierzyła we mnie i wspierała mnie w moich celach. Jego podejście do treningów było zawsze profesjonalne i skuteczne, a jednocześnie przyjazne i motywujące. Potrafił znaleźć w każdym z naszych zawodników mocne strony i pomóc nam w ich rozwijaniu.\nDzięki trenerowi Jakubowi, zdobyłem wiele umiejętności, które pomogły mi w osiągnięciu sukcesów na boisku. Jego wiedza i doświadczenie były bezcenne, a jego pozytywna energia i entuzjazm zawsze motywowały mnie do dalszej pracy i rozwoju.",
                Opinion_date = new DateTime(2023, 10, 30),
                Rate = 2
            };
            var opinion3= new Opinion
            {
                Id_Pupil = 5,
                Id_Mentor = 22,
                Content =
                    "Jakub jest nie tylko świetnym trenerem, ale także osobą, która zawsze wierzyła we mnie i wspierała mnie w moich celach. Jego podejście do treningów było zawsze profesjonalne i skuteczne, a jednocześnie przyjazne i motywujące. Potrafił znaleźć w każdym z naszych zawodników mocne strony i pomóc nam w ich rozwijaniu.\nDzięki trenerowi Jakubowi, zdobyłem wiele umiejętności, które pomogły mi w osiągnięciu sukcesów na boisku. Jego wiedza i doświadczenie były bezcenne, a jego pozytywna energia i entuzjazm zawsze motywowały mnie do dalszej pracy i rozwoju.",
                Opinion_date = new DateTime(2023, 10, 30),
                Rate = 4
            };
            var opinion4 = new Opinion
            {
                Id_Pupil = 6,
                Id_Mentor = 22,
                Content =
                    "Jakub jest nie tylko świetnym trenerem, ale także osobą, która zawsze wierzyła we mnie i wspierała mnie w moich celach. Jego podejście do treningów było zawsze profesjonalne i skuteczne, a jednocześnie przyjazne i motywujące. Potrafił znaleźć w każdym z naszych zawodników mocne strony i pomóc nam w ich rozwijaniu.\nDzięki trenerowi Jakubowi, zdobyłem wiele umiejętności, które pomogły mi w osiągnięciu sukcesów na boisku. Jego wiedza i doświadczenie były bezcenne, a jego pozytywna energia i entuzjazm zawsze motywowały mnie do dalszej pracy i rozwoju.",
                Opinion_date = new DateTime(2023, 10, 30),
                Rate = 5
            };
            var opinion5 = new Opinion
            {
                Id_Pupil = 7,
                Id_Mentor = 23,
                Content =
                    "Jakub jest nie tylko świetnym trenerem, ale także osobą, która zawsze wierzyła we mnie i wspierała mnie w moich celach. Jego podejście do treningów było zawsze profesjonalne i skuteczne, a jednocześnie przyjazne i motywujące. Potrafił znaleźć w każdym z naszych zawodników mocne strony i pomóc nam w ich rozwijaniu.\nDzięki trenerowi Jakubowi, zdobyłem wiele umiejętności, które pomogły mi w osiągnięciu sukcesów na boisku. Jego wiedza i doświadczenie były bezcenne, a jego pozytywna energia i entuzjazm zawsze motywowały mnie do dalszej pracy i rozwoju.",
                Opinion_date = new DateTime(2023, 10, 30),
                Rate = 2
            };
            var opinion6 = new Opinion
            {
                Id_Pupil = 8,
                Id_Mentor = 23,
                Content =
                    "Jakub jest nie tylko świetnym trenerem, ale także osobą, która zawsze wierzyła we mnie i wspierała mnie w moich celach. Jego podejście do treningów było zawsze profesjonalne i skuteczne, a jednocześnie przyjazne i motywujące. Potrafił znaleźć w każdym z naszych zawodników mocne strony i pomóc nam w ich rozwijaniu.\nDzięki trenerowi Jakubowi, zdobyłem wiele umiejętności, które pomogły mi w osiągnięciu sukcesów na boisku. Jego wiedza i doświadczenie były bezcenne, a jego pozytywna energia i entuzjazm zawsze motywowały mnie do dalszej pracy i rozwoju.",
                Opinion_date = new DateTime(2023, 10, 30),
                Rate = 4
            };

            var exercise = new Exercise
            {
                Id_Exercise = 1,
                Name = "Pompki",
                Details = "Podstawowe ćwiczenie siłowe, angażuje mięśnie klatki piersiowej, ramion i tricepsa.",
                Exercise_steps = "[{\"Step\": 1, \"Description\": \"Połóż się na podłodze na brzuchu, ręce ustawione nieco szerzej niż szerokość ramion.\"}, {\"Step\": 2, \"Description\": \"Wypnij się na rękach i naciskaj ciało do góry, wyprostowując ręce.\"}, {\"Step\": 3, \"Description\": \"Powoli wróć do pozycji wyjściowej, zginając ręce w łokciach.\"}]",
                Image = null,
                Id_Trainer = 1
            };

            var exercise1 = new Exercise
            {
                Id_Exercise = 2,
                Name = "Przysiady",
                Details = "Ćwiczenie wzmacniające mięśnie nóg, pośladków i dolnej części pleców.",
                Exercise_steps = "Step1: Stań prosto, nogi ustawione na szerokość bioder Step 2:" +
                                 " Opuszczaj biodra w dół, jakbyś siadał na niewidzialne krzesło " +
                                 "Step: 3,Powoli wracaj do pozycji wyjściowej, naciskając pięty w podłogę.",
                Image = null,
                Id_Trainer = 1
            };

            var exercise2 = new Exercise
            {
                Id_Exercise = 3,
                Name = "Plank",
                Details = "Ćwiczenie wzmacniające mięśnie brzucha, pleców i ramion.",
                Exercise_steps = "[{\"Step\": 1, \"Description\": \"Połóż się na brzuchu, opierając się na przedramionach i palcach u stóp.\"}, {\"Step\": 2, \"Description\": \"Utrzymuj prostą linię od głowy do pięt, napinając mięśnie brzucha.\"}, {\"Step\": 3, \"Description\": \"Utrzymuj tę pozycję przez określony czas.\"}]",
                Image = null,
                Id_Trainer = null
            };

            var exercise3 = new Exercise
            {
                Id_Exercise = 14,
                Name = "Przysiady",
                Details = "Ćwiczenie wzmacniające mięśnie nóg i pośladków",
                Exercise_steps = "1. Stań w rozkroku i ugnij nogi w kolanach",
                Image = null,
                Id_Trainer = null
            };
            var exercise4 = new Exercise
            {
                Id_Exercise = 15,
                Name = "Pompki",
                Details = "Ćwiczenie wzmacniające mięśnie piersiowe, pleców i rąk.",
                Exercise_steps = "W podporze przodem ugnij ręcę w łokciach",
                Image = null,
                Id_Trainer = null
            };
            var exercise5 = new Exercise
            {
                Id_Exercise = 16,
                Name = "Boczny plank",
                Details = "Ćwiczenie wzmacniające mięśnie boczne tułowia oraz ramiona.",
                Exercise_steps = "Połóż się na boku i podnieś biodra, tworząc prostą linię od stóp do głowy.",
                Image = null,
                Id_Trainer = null
            };

            var exercise6 = new Exercise
            {
                Id_Exercise = 17,
                Name = "Plank z podnoszeniem nóg",
                Details = "Ćwiczenie angażujące głębokie mięśnie brzucha oraz stabilizujące biodra.",
                Exercise_steps = "W pozycji planku na przedramionach, unieś na przemian każdą nogę.",
                Image = null,
                Id_Trainer = null
            };





            var trainingPlan = new Training_plan
            {
                Id_Training_plan = 1,
                Name = "Plan treningowy dla początkujących",
                Type = "Siłowy",
                Start_date = new DateTime(2023, 09, 10),
                End_date = new DateTime(2023, 09, 30),
                Id_Trainer = 1,
                Id_Pupil = 2
            };

            var trainingPlan1 = new Training_plan
            {
                Id_Training_plan = 2,
                Name = "Plan treningowy na odchudzanie",
                Type = "Cardio",
                Start_date = new DateTime(2023, 10, 1),
                End_date = new DateTime(2023, 10, 31),
                Id_Trainer = 1,
                Id_Pupil = 2
            };



            var traineeExercise = new Trainee_exercise
            {
                Id_Trainee_exercise = 1,
                Series_number = 3,
                Repetitions_number = 12,
                Date = new DateTime(2023, 09, 12),
                Id_Exercise = 1,
                Id_Training_plan = 1
            };

            var traineeExercise1 = new Trainee_exercise
            {
                Id_Trainee_exercise = 2,
                Series_number = 4,
                Repetitions_number = 10,
                Date = new DateTime(2023, 09, 15),
                Id_Exercise = 2,
                Id_Training_plan = 1
            };

            var traineeExercise2 = new Trainee_exercise
            {
                Id_Trainee_exercise = 3,
                Series_number = 2,
                Repetitions_number = 15,
                Date = new DateTime(2023, 09, 20),
                Id_Exercise = 3,
                Id_Training_plan = 2
            };

            var pupilMentor1 = new Pupil_mentor
            {
                Id_Mentor = 1,
                Id_Pupil = 2
            };
            var pupilMentor2 = new Pupil_mentor
            {
                Id_Mentor = 1,
                Id_Pupil = 3
            };
            modelBuilder.Entity<Meal>().HasData(
                new Meal
                {
                    Id_Meal = 1,
                    Id_Dietetician = 1,
                    Name = "Placki ziemniaczane",
                    Ingredients = "{\"ingredient1\": \"ziemniaki\", \"ingredient2\": \"cebula\", \"ingredient3\":  \"mąka\" }"
                    ,
                    Prepare_Steps = "{\"test1\": \"test\", \"test2\": \"test\", \"test3\":  \"test\" }",
                    Kcal = "{\"kcal\": \"651\", \"Białko\": \"16\", \"Węglowodany\":  \"160\" , \"Tłuszcze\": \"30\" }"
                },
                new Meal
                {
                    Id_Meal = 2,
                    Id_Dietetician = 1,
                    Name = "Owsianka",
                    Ingredients = "{\"ingredient1\": \"platki owsiane\", \"ingredient2\": \"mleko\", \"ingredient3\":  \"cukier\" }"
                    ,
                    Prepare_Steps = "{\"test1\": \"test\", \"test2\": \"test\", \"test3\":  \"test\" }",
                    Kcal = "{\"kcal\": \"765\", \"Białko\": \"20\", \"Węglowodany\":  \"165\" , \"Tłuszcze\": \"20\" }"
                },
                new Meal
                {
                    Id_Meal = 3,
                    Id_Dietetician = 2,
                    Name = "Kanapki z szynką",
                    Ingredients = "{\"ingredient1\": \"szynka\", \"ingredient2\": \"chleb\", \"ingredient3\":  \"masło\" }"
                    ,
                    Prepare_Steps = "{\"test1\": \"test\", \"test2\": \"test\", \"test3\":  \"test\" }",
                    Kcal = "{\"kcal\": \"700\", \"Białko\": \"30\", \"Węglowodany\":  \"200\" , \"Tłuszcze\": \"26\" }"
                }
            );

            modelBuilder.Entity<Diet>().HasData(
                new Diet { Id_Diet = 1, Id_Dietician = 1, Id_Pupil = 2, Start_Date = new DateTime(2023, 12, 20), End_Date = new DateTime(2023, 12, 20), DietDuration = "1", Total_kcal = 3000 },
                new Diet { Id_Diet = 2, Id_Dietician = 1, Id_Pupil = 2, Start_Date = new DateTime(2023, 10, 20), End_Date = new DateTime(2023, 11, 20), DietDuration = "30", Total_kcal = 2000 },
                new Diet { Id_Diet = 3, Id_Dietician = 1, Id_Pupil = 2, Start_Date = new DateTime(2023, 11, 30), End_Date = new DateTime(2023, 12, 30), DietDuration = "30", Total_kcal = 2500 }
            );
            modelBuilder.Entity<Meal_Diet>().HasData(
                new Meal_Diet { Id_Meal_Diet = 1, Id_Meal = 1, Id_Diet = 1, Date = new DateTime(2023, 12, 07) },
                new Meal_Diet { Id_Meal_Diet = 2, Id_Meal = 2, Id_Diet = 1, Date = new DateTime(2023, 6, 07) },
                new Meal_Diet
                {
                    Id_Meal_Diet = 3,
                    Id_Meal = 1,
                    Id_Diet = 2,
                    Date = new DateTime(2023, 5, 07),
                });

            //generate 3 records for each model: Gym, Trainer_Gym, give random gym names
            for (int i = 1; i <= 3; i++)
            {
                modelBuilder.Entity<Gym>().HasData(
                                       new Gym { Id_Gym = i, Id_Address = i, Name = "Gym" + i }
                                                      );
                modelBuilder.Entity<Trainer_Gym>().HasData(
                                       new Trainer_Gym { Id_Trainer = i, Id_Gym = i }
                                                      );
            }


            modelBuilder.Entity<Diet>()
                .HasOne(d => d.Dietician)
                .WithMany(u => u.DietsAsDietician)
                .HasForeignKey(d => d.Id_Dietician);

            modelBuilder.Entity<Diet>()
                .HasOne(d => d.Pupil)
                .WithMany(u => u.DietsAsPupil)
                .HasForeignKey(d => d.Id_Pupil);

            modelBuilder.Entity<Address>().HasData(address, address2, address3);
            modelBuilder.Entity<Opinion>().HasData(opinion, opinion2,opinion3,opinion4,opinion5,opinion6);
            modelBuilder.Entity<User>().HasData(user, user1, user2,user3, user4,user5,user6,user7,user8,user9,user10,user11,user12,user13,user14,user15,user16,user17,user18,user19,user20,user22,user23,user24, user25);
            modelBuilder.Entity<Exercise>().HasData(exercise, exercise1, exercise2, exercise3, exercise4, exercise5, exercise6);
            modelBuilder.Entity<Training_plan>().HasData(trainingPlan, trainingPlan1);
            modelBuilder.Entity<Trainee_exercise>().HasData(traineeExercise, traineeExercise1, traineeExercise2);
            modelBuilder.Entity<Pupil_mentor>().HasData(pupilMentor1, pupilMentor2);
            modelBuilder.Entity<Pupil_mentor>().HasKey(pm => new { pm.Id_Mentor, pm.Id_Pupil });
            modelBuilder.Entity<Meal_Diet>().HasKey(md => new { md.Id_Meal, md.Id_Diet });
            modelBuilder.Entity<Opinion>().HasKey(o => new { o.Id_Pupil, o.Id_Mentor });
            modelBuilder.Entity<Trainer_Gym>().HasKey(o => new { o.Id_Gym, o.Id_Trainer});
            modelBuilder.Entity<Role>().HasData(roles);
            base.OnModelCreating(modelBuilder);
        }
    }
}
