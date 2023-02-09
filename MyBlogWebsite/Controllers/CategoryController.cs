using Microsoft.AspNetCore.Mvc;

namespace MyBlogWebsite.Controllers
{
	public class CategoryController : Controller
	{
		public IActionResult Index(int id)
		{
			return View();
		}
	}
}
