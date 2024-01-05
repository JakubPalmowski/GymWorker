using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Training_and_diet_backend.Models;

namespace TrainingAndDietApp.Domain.Abstractions
{
   
    public interface IGymRepository
    {
        Task<List<Gym>> GetGymsAsync();
    }
}
