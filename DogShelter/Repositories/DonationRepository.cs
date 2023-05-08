using DogShelter.Models;
using System;
using System.Security.Claims;

namespace DogShelter.Repositories
{
    public class DonationRepository : RepositoryBase<Donation>
    {
        private readonly AppDBContext dbContext;
        public DonationRepository(AppDBContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }
    }
}
