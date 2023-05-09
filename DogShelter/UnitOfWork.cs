using DogShelter.Repositories;
using System;

namespace DogShelter
{
    public class UnitOfWork
    {
        public UserRepository Users { get; }
        public RoleRepository Roles { get; }

        private readonly AppDBContext _dbContext;

        public UnitOfWork
        (
            AppDBContext dbContext,
            RoleRepository rolesRepository,
            UserRepository userRepository
    
        )
        {
            _dbContext = dbContext;
            Roles = rolesRepository;
            Users = userRepository;
          
        }

        public void SaveChanges()
        {
            try
            {
                _dbContext.SaveChanges();
            }
            catch (Exception exception)
            {
                var errorMessage = "Error when saving to the database: "
                    + $"{exception.Message}\n\n"
                    + $"{exception.InnerException}\n\n"
                    + $"{exception.StackTrace}\n\n";

                Console.WriteLine(errorMessage);
            }
        }
    }
}
