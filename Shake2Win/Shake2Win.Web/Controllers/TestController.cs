using Microsoft.AspNetCore.Mvc;

namespace Shake2Win.Web.Controllers
{
	/*
		ControllerBase -> Simple endpoints aggregation (Web API)
		Controller -> Adds support for the views
		[ApiController] -> Default behavior (validation + error handling)
	*/

	/// <summary>
	/// </summary>
	public class TestController : Controller
	{
		[HttpGet("test/env")]
		public IActionResult Env()
		{
			return View("Test");
		}
	}
}
