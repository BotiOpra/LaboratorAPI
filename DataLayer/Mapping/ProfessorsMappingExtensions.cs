using DataLayer.Dtos;
using DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Mapping
{
	public static class ProfessorsMappingExtensions
	{
		public static List<ProfessorDto> ToProfessorDtos(this List<Professor> professors)
		{
			var results = professors.Select(p => p.ToProfessorDto()).ToList();

			return results;
		}

		public static ProfessorDto ToProfessorDto(this Professor professor)
		{
			if (professor == null) return null;

			var result = new ProfessorDto();
			result.Id = professor.Id;
			result.FullName = professor.FirstName + " " + professor.LastName;

			return result;
		}
	}
}
