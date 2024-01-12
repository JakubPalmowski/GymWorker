using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Training_and_diet_backend.Models;
using TrainingAndDietApp.Domain.Entities;

namespace TrainingAndDietApp.Domain.Abstractions
{
    public interface IUserRepository
    {
        Task<List<User>> GetPupilsByTrainerIdAsync(int idTrainer, CancellationToken cancellationToken);
        Task<User?> GetUserByIdAsync(int id, CancellationToken cancellationToken);
        Task<User?> GetUserWithGymsAndOpinionsAsync(int id, CancellationToken cancellationToken);
        Task<bool> AnyAsync(Expression<Func<User, bool>> predicate);

        IQueryable<User> GetUsers(string roleName, string? searchPhrase,  CancellationToken cancellationToken);
        Task<int> UpdateUserAsync(User user, CancellationToken cancellationToken);


    }
}
