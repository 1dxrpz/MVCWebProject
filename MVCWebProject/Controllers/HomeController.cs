using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MVCWebProject.Models;
using MVCWebProject.Views;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCWebProject.Controllers
{
	public class HomeController : Controller
	{
		NpgsqlCommand Command = new NpgsqlCommand();
		NpgsqlConnection Connection = new NpgsqlConnection();
		NpgsqlDataReader DataReader;

		List<User> Users = new List<User>();

		private readonly ILogger<HomeController> _logger;
		public HomeController(ILogger<HomeController> logger)
		{
			Connection.ConnectionString = "User ID=postgres; Server=localhost; port=5432; Database=webproject.dev; Password=123456; Pooling=true;";
			Command.Connection = Connection;
			_logger = logger;
		}
		private void FetchData()
		{
			if (Users.Count > 0)
			{
				Users.Clear();
			}
			Connection.Open();
			Command.CommandText = "SELECT * FROM \"Users\"";
			DataReader = Command.ExecuteReader();
			while (DataReader.Read())
			{
				Users.Add(new User()
				{
					Id = (Guid)DataReader["ID"],
					Data = DataReader["Data"].ToString()
				}
				);
			}
			Connection.Close();
			try
			{
				
			}
			catch (Exception ex)
			{

				throw ex;
			}
		}
		public IActionResult Index()
		{
			FetchData();
			var model = new UsersViewModel()
			{
				user = new User()
				{
					Id = Guid.NewGuid(),
					Data = "test"
				}
			};
			return View(model);
		}
	}
}
