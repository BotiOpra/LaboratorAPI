using Core.Dtos;
using Core.Services;
using DataLayer.Dtos;
using DataLayer.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Project.Controllers
{
	[ApiController]
	[Route("api/professors")]
	[Authorize]
	public class ProfessorsController : ControllerBase
	{
		private ProfessorService professorService { get; set; }


		public ProfessorsController(ProfessorService professorService)
		{
			this.professorService = professorService;
		}

		[HttpPost("/register-professor")]
		[AllowAnonymous]
		public IActionResult Register(ProfessorRegisterDto payload)
		{
			professorService.Register(payload);
			return Ok();
		}

		[HttpPost("/login-professor")]
		[AllowAnonymous]
		public IActionResult Login(LoginDto payload)
		{
			var jwtToken = professorService.Validate(payload);

			return Ok(new { token = jwtToken });
		}

		[HttpGet("/get-all-professors")]
		public ActionResult<List<Professor>> GetAll()
		{
			var results = professorService.GetAll();

			return Ok(results);
		}

		[HttpGet("/get/{professorId}")]
		public ActionResult<Professor> GetById(int professorId)
		{
			var result = professorService.GetById(professorId);

			if (result == null)
			{
				return BadRequest("Professor not fount");
			}

			return Ok(result);
		}

		[HttpGet("/get-all-grades")]
		public ActionResult<List<GradesByStudent>> GetAllStudentsGrades()
		{
			var result = professorService.GetAllStudentsGrades();
			return Ok(result);
		}
	}
}