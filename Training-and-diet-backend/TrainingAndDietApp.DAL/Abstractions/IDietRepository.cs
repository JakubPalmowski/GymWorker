using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingAndDietApp.DAL.EntityModels;

namespace TrainingAndDietApp.Domain.Abstractions
{
        public interface IDietRepository
        {
            Task<List<Diet>> GetDietsAsync(CancellationToken cancellationToken);
        }
    
}
