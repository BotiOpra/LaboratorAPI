using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Entities
{
	public class Role
	{
		public string Description { get; set; }
		public Role(string description)
		{
			Description = description;
		}
	}
}
