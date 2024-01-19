using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Training_and_diet_backend.Models;
using TrainingAndDietApp.Domain.Entities;

namespace TrainingAndDietApp.Domain.Abstractions
{
   
    public interface IGymRepository
    {
        Task<IEnumerable<Gym>> GetActiveGymsWithAddressAsync(CancellationToken cancellationToken);
        Task<List<Gym>> GetMentorActiveGymsAsync(int idUser, CancellationToken cancellationToken);
        Task<Gym?> GetByIdAsync(int id, CancellationToken cancellationToken);
        Task AddAsync(Gym gym, CancellationToken cancellationToken);//do wywalenia
        Task<List<Gym>> GetAllGymsAddedByUserAsync(int idUser,CancellationToken cancellationToken);
        Task<List<Gym>> GetAllPendingGymsAsync(CancellationToken cancellationToken);
    }
}
