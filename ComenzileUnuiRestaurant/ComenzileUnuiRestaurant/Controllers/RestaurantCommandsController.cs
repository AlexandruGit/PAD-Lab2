using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ComenzileUnuiRestaurant.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class RestaurantCommandsController : ControllerBase
	{
		private static readonly string[] Summaries = new[]
		{
			"Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
		};

		private readonly ILogger<RestaurantCommandsController> _logger;

		public RestaurantCommandsController(ILogger<RestaurantCommandsController> logger)
		{
			_logger = logger;
		}

		[HttpGet]
		public IEnumerable<RestaurantCommand> Get()
		{
			var rng = new Random();
			return Enumerable.Range(1, 5).Select(index => new RestaurantCommand
			{
			
			})
			.ToArray();
		}
	}
}
