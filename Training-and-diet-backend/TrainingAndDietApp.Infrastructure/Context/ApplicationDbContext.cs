using Microsoft.EntityFrameworkCore;
using Training_and_diet_backend.Models;
using TrainingAndDietApp.Domain.Entities;
using TrainingAndDietApp.Infrastructure.DataSeeds;

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

            modelBuilder.ApplyConfiguration(new RoleDataSeed());
            modelBuilder.ApplyConfiguration(new AddressDataSeed());
            modelBuilder.ApplyConfiguration(new UserDataSeed());
            modelBuilder.ApplyConfiguration(new GymDataSeed());
            modelBuilder.ApplyConfiguration(new TrainerGymDataSeed());
            modelBuilder.ApplyConfiguration(new ExerciseDataSeed());
            //modelBuilder.ApplyConfiguration(new CertificateDataSeed());
            //modelBuilder.ApplyConfiguration(new OpinionDataSeed());
           


            modelBuilder.Entity<Diet>()
                .HasOne(d => d.Dietician)
                .WithMany(u => u.DietsAsDietician)
                .HasForeignKey(d => d.IdDietician);

            modelBuilder.Entity<Diet>()
                .HasOne(d => d.Pupil)
                .WithMany(u => u.DietsAsPupil) 
                .HasForeignKey(d => d.IdPupil) 
                .IsRequired(false);

            modelBuilder.Entity<PupilMentor>().HasKey(pm => new {Id_Mentor = pm.IdMentor, Id_Pupil = pm.IdPupil });
            modelBuilder.Entity<Opinion>().HasKey(o => new {Id_Pupil = o.IdPupil, Id_Mentor = o.IdMentor });
            modelBuilder.Entity<TrainerGym>().HasKey(tg => new { tg.IdGym, tg.IdTrainer });

            base.OnModelCreating(modelBuilder);
        }
    }
}
