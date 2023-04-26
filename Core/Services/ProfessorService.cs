using Core.Dtos;
using DataLayer.Dtos;
using DataLayer.Entities;
using DataLayer.Enums;
using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Mapping;

namespace Core.Services
{
	public class ProfessorService
	{
		private readonly UnitOfWork unitOfWork;
		private AuthorizationService authService;

		public ProfessorService(UnitOfWork unitOfWork, AuthorizationService authorizationService)
		{
			this.unitOfWork = unitOfWork;
			this.authService = authorizationService;
		}

		public void Register(ProfessorRegisterDto registerData)
		{
			if (registerData == null)
			{
				return;
			}

			var hashedPassword = authService.HashPassword(registerData.Password);

			var professor = new Professor
			{
				FirstName = registerData.FirstName,
				LastName = registerData.LastName,
				Email = registerData.Email,
				PasswordHash = hashedPassword,
				UserRole = new Role("Professor")
			};

			unitOfWork.Professors.Insert(professor);
			unitOfWork.SaveChanges();
		}

		public string Validate(LoginDto payload)
		{
			var professor = unitOfWork.Professors.GetByEmail(payload.Email);

			var passwordFine = authService.VerifyHashedPassword(professor.PasswordHash, payload.Password);

			if (passwordFine)
			{
				return authService.GetToken(professor);
			}
			else
			{
				return null;
			}

		}

		public void AddProfessor(Professor professor)
		{
			if (professor == null)
				return;

			unitOfWork.Professors.Insert(professor);
		}

		public Role GetRole(User user)
		{
			return user.UserRole;
		}

		public List<Professor> GetAll()
		{
			var results = unitOfWork.Professors.GetAll();

			return results;
		}

		public ProfessorDto GetById(int professorId)
		{
			var professor = unitOfWork.Professors.GetById(professorId);

			var result = professor.ToProfessorDto();

			return result;
		}
	}
}
