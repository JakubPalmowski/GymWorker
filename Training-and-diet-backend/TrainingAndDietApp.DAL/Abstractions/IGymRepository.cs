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
        Task<IEnumerable<Gym>> GetGymsWithAddressAsync(CancellationToken cancellationToken);
        Task<List<Gym>> GetMentorGymsAsync(int idUser, CancellationToken cancellationToken);
    }
}
