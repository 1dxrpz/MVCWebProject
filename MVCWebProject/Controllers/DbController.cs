using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVCWebProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCWebProject.Controllers
{
	public class DbController : Controller
	{
		readonly ApplicationContext Context;
		public DbController(ApplicationContext context)
		{
			Context = context;
		}
		[HttpGet]
		public IActionResult GetElement()
		{
			
			return Ok("sosi");
		}
		[HttpPost]
		public IActionResult CreateElement()
		{
			//Context.Add(test);
			Context.SaveChanges();
			return Ok("succ");
		}
	}
}
