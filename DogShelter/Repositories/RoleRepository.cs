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

        public static implicit operator RoleRepository(DogRepository v)
        {
            throw new NotImplementedException();
        }
    }
}
