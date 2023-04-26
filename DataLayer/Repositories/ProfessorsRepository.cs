using DataLayer.Entities;
using DataLayer.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repositories
{
	public class ProfessorsRepository : RepositoryBase<Professor>
	{
		private readonly AppDbContext dbContext;

		public ProfessorsRepository(AppDbContext dbContext) : base(dbContext)
		{
			this.dbContext = dbContext;
		}

		public Professor GetById(int professorId)
		{
			var result = dbContext.Students
			   .Select(e => new Professor
			   {
				   FirstName = e.FirstName,
				   LastName = e.LastName,
				   Id = e.Id,
			   })
			   .FirstOrDefault(e => e.Id == professorId);

			return result;
		}

		public List<Student> GetAllStudents()
		{
			return dbContext.Students.ToList();
		}

		public Professor GetByEmail(string email)
		{
			return dbContext.Professors.FirstOrDefault(s => s.Email == email);
		}
	}
}
