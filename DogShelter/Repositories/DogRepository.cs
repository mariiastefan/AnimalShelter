using DogShelter.Models;

namespace DogShelter.Repositories
{
    public class DogRepository : RepositoryBase<Dog>
    {
        private readonly AppDBContext dbContext;
        public DogRepository(AppDBContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }
    }
}
