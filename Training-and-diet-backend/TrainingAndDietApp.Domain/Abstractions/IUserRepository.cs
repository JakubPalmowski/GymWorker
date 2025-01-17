﻿using System;
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
        Task<User?> GetUserWithGymsAndOpinionsAsync(int id, CancellationToken cancellationToken);
        Task<User?> GetByEmailWithRoleAsync(string email, CancellationToken cancellationToken);
        Task<User?> GetByIdWithRoleAsync(int id, CancellationToken cancellationToken);
        Task<bool> AnyAsync(Expression<Func<User, bool>> predicate);
        IQueryable<User> GetUsersWithDetails(string roleName, string? searchPhrase,  CancellationToken cancellationToken);
        Task<User?> GetUserWithDetailsAsync(int id, CancellationToken cancellationToken);
        Task UpdateAsync(User user, CancellationToken cancellationToken);
        Task<User?> GetUserByImageUri(string imageUri, CancellationToken cancellationToken);
        Task<IEnumerable<User>> GetPupilsByMentorIdAsync (int idMentor, CancellationToken cancellationToken);
        Task<IEnumerable<User>> GetAllUsersWithCertificatesAsync(bool isAccepted,CancellationToken cancellationToken);

    }
}
