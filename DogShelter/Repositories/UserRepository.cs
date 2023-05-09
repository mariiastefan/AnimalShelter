using DogShelter.Models;

namespace DogShelter.Repositories
{
    public class UserRepository : RepositoryBase<User>
    {
        private readonly AppDBContext dbContext;
        public UserRepository(AppDBContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }

        public User GetByUsername(string username)
        {
            return dbContext.User.FirstOrDefault(e => e.Username == username);
        }
    }
}
