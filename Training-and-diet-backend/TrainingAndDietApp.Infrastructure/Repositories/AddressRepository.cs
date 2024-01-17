using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Training_and_diet_backend.Models;
using TrainingAndDietApp.Domain.Abstractions;
using TrainingAndDietApp.Infrastructure.Context;

namespace TrainingAndDietApp.Infrastructure.Repositories
{
    public class AddressRepository : IAddressRepository
    {
        private readonly ApplicationDbContext _context;

        public AddressRepository(ApplicationDbContext context)
        {
            _context = context;
        }


        public async Task<Address?> CheckIfAddressExistsAsync(string city, string street, string postalCode, CancellationToken cancellation)
        => await _context.Addresses
            .Where(a => a.City == city && a.Street == street && a.PostalCode == postalCode)
            .FirstOrDefaultAsync(cancellation);
    }
}
