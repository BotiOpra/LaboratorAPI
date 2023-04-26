using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Entities
{
	public class User : BaseEntity
	{
		public User(string username, string password)
		{
			Username = username;
			Password = password;
		}

		public string Username { get; set; }
		public string Password { get; set; }
	}
}
