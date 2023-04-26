using Core.Dtos;
using Core.Services;
using DataLayer.Dtos;
using DataLayer.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Project.Controllers
{
	[ApiController]
	[Route("api/Professors")]
	public class ProfessorsController : ControllerBase
	{
		private ProfessorService professorService { get; set; }

		public ProfessorsController(ProfessorService professorService)
		{
			this.professorService = professorService;
		}

		[HttpPost("/add")]
		public IActionResult Add(ProfessorAddDto payload)
		{
			var result = professorService.AddProfessor(payload);

			if (result == null)
			{
				return BadRequest("Professor cannot be added");
			}

			return Ok(result);
		}


		[HttpGet("/get-all")]
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

		[HttpPatch("edit-name")]
		public ActionResult<bool> GetById([FromBody] ProfessorUpdateDto professorUpdateModel)
		{
			var result = professorService.EditName(professorUpdateModel);

			if (!result)
			{
				return BadRequest("Professor could not be updated.");
			}

			return result;
		}

		[HttpPost("grades-by-course")]
		public ActionResult<GradesByProfessor> Get_CourseGrades_ByProfessorId([FromBody] ProfessorGradesRequest request)
		{
			var result = professorService.GetGradesById(request.ProfessorId, request.CourseType);
			return Ok(result);
		}

		[HttpGet("{classId}/class-professors")]
		public IActionResult GetClassProfessors([FromRoute] int classId)
		{
			var results = professorService.GetClassProfessors(classId);

			return Ok(results);
		}

		[HttpGet("grouped-professors")]
		public IActionResult GetGroupedProfessors()
		{
			var results = professorService.GetGroupedProfessors();

			return Ok(results);
		}
	}
}
