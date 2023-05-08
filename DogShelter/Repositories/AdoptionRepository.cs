using DogShelter.Models;
using System;

namespace DogShelter.Repositories
{
    public class AdoptionRepository : RepositoryBase<Adoption>
    {
        private readonly AppDBContext dbContext;
        public AdoptionRepository(AppDBContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }
    }
}
