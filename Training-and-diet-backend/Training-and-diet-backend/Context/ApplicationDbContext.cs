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
        public DbSet<User> Users { get; set; }
    }
}
