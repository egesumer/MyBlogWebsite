using Microsoft.AspNetCore.Mvc;
using MyBlogWebsite.Data_Access_Layer_Folder_.Repositories.Abstract;
using MyBlogWebsite.Data_Access_Layer_Folder_.Repositories.Concrete;
using MyBlogWebsite.Models;
using System.Diagnostics;

namespace MyBlogWebsite.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;
		private readonly IArticleRepository articleRepository;

		public HomeController(ILogger<HomeController> logger, IArticleRepository articleRepository)
		{
			_logger = logger;
			this.articleRepository = articleRepository;
		}
		public IActionResult Index()
		{
            var articles = articleRepository.MostPopularArticles();
            return View(articles);
		}

		public IActionResult Privacy()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}