using DogShelter.Models;

namespace DogShelter.Repositories
{
    public class RoleRepository : RepositoryBase<Role>
    {
        private readonly AppDBContext dbContext;
        public RoleRepository(AppDBContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }
    }
}
