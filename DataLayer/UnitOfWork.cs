using DataLayer.Repositories;

namespace DataLayer
{
    public class UnitOfWork
    {
        public StudentsRepository Students { get; }
        public ProfessorsRepository Professors { get; }
        public ClassRepository Classes { get; }
		public UsersRepository Users { get; }

		private readonly AppDbContext _dbContext;

        public UnitOfWork
        (
            AppDbContext dbContext,
            StudentsRepository studentsRepository,
            ProfessorsRepository professorsRepository,
            ClassRepository classes,
            UsersRepository users
        )
        {
            _dbContext = dbContext;
            Students = studentsRepository;
            Professors = professorsRepository;
            Classes = classes;
            Users = users;
        }

        public void SaveChanges()
        {
            try
            {
                _dbContext.SaveChanges();
            }
            catch(Exception exception)
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
