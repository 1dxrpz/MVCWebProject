using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCWebProject.Models
{
	public class webproject
	{
		public webproject()
		{
			Id = new Guid();
		}
		public Guid Id { get; set; }
		
	}
}
