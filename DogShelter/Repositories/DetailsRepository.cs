using DogShelter.Models;
using System;

namespace DogShelter.Repositories
{
    public class DetailsRepository : RepositoryBase<Details>
    {
        private readonly AppDBContext dbContext;
        public DetailsRepository(AppDBContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }
    }
}
