using System;

namespace DogShelter
{
    public class UnitOfWork
    {
        //public StudentsRepository Students { get; }
        //public UserRepository Users { get; }
        //public ClassRepository Classes { get; }

        private readonly AppDBContext _dbContext;

        public UnitOfWork
        (
            AppDBContext dbContext
            //StudentsRepository studentsRepository,
            //UserRepository userRepository,
            //ClassRepository classes
        )
        {
            _dbContext = dbContext;
            //Students = studentsRepository;
            //Users = userRepository;
            //Classes = classes;
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
