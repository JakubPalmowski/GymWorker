using Microsoft.EntityFrameworkCore;
using Training_and_diet_backend.Models;

namespace Training_and_diet_backend.Context
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        :base(options)
        {

        }

        public DbSet<Exercise> Exercises { get; set; }
        public DbSet<Trainee_exercise> Trainee_exercises { get; set; }
        public DbSet<Training_plan> Training_plans { get; set; }
        public DbSet<Pupil_mentor> Pupil_mentors { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var user = new User { Id_User = 1, Role = UserRole.Trainer, Name = "Michał", Last_name = "Emczyk", Email = "michal@gmail.com", Phone_number = "48777888777", Email_validated = true, Sex = "Male" };
            var user1 = new User { Id_User = 2, Role = UserRole.Pupil, Name = "Anna", Last_name = "Kowalska", Email = "anna@gmail.com", Phone_number = "48666778888", Email_validated = true, Sex = "Female" };
            var user2 = new User { Id_User = 3, Role = UserRole.Pupil, Name = "John", Last_name = "Doe", Email = "john@gmail.com", Phone_number = "48555667777", Email_validated = true, Sex = "Male" };

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
                Exercise_steps = "[{\"Step\": 1, \"Description\": \"Stań prosto, nogi ustawione na szerokość bioder.\"}, {\"Step\": 2, \"Description\": \"Opuszczaj biodra w dół, jakbyś siadał na niewidzialne krzesło.\"}, {\"Step\": 3, \"Description\": \"Powoli wracaj do pozycji wyjściowej, naciskając pięty w podłogę.\"}]",
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
                Id_Trainer = 1
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


            modelBuilder.Entity<User>().HasData(user, user1, user2);
            modelBuilder.Entity<Exercise>().HasData(exercise, exercise1, exercise2);
            modelBuilder.Entity<Training_plan>().HasData(trainingPlan, trainingPlan1);
            modelBuilder.Entity<Trainee_exercise>().HasData(traineeExercise, traineeExercise1, traineeExercise2);
            modelBuilder.Entity<Pupil_mentor>().HasData(pupilMentor1,pupilMentor2);
            modelBuilder.Entity<Pupil_mentor>().HasKey(pm => new { pm.Id_Mentor, pm.Id_Pupil });
            base.OnModelCreating(modelBuilder);
        }
    }
}
