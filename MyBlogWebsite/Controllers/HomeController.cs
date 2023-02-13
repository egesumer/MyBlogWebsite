using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyBlogWebsite.Data_Access_Folder.Repositories.Abstract;
using MyBlogWebsite.Data_Access_Layer_Folder_.Repositories.Abstract;
using MyBlogWebsite.Data_Access_Layer_Folder_.Repositories.Concrete;
using MyBlogWebsite.Models;
using MyBlogWebsite.Models.Concrete;
using MyBlogWebsite.Models.Entities;
using MyBlogWebsite.Models.ViewModels;
using System.Diagnostics;

namespace MyBlogWebsite.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;
		private readonly IArticleRepository articleRepository;
		private readonly ICategoryRepository categoryRepository;
		private readonly UserManager<IdentityUser> userManager;
		private readonly IAuthorRepository authorRepository;


		public HomeController(ILogger<HomeController> logger, IArticleRepository articleRepository, ICategoryRepository categoryRepository, UserManager<IdentityUser> userManager, IAuthorRepository authorRepository)
		{
			_logger = logger;
			this.articleRepository = articleRepository;
			this.categoryRepository = categoryRepository;
			this.userManager = userManager;
			this.authorRepository = authorRepository;
		}

		[HttpGet]
		public IActionResult Index()
		{
			ArticleIndexVM vm = new ArticleIndexVM();

			var articles = articleRepository.MostPopularArticles();

			vm.Articles = articles;

			List<Category> categories = categoryRepository.GetCategories();
			Random rnd = new Random();

			int first = rnd.Next(0, categories.Count());
			int second = rnd.Next(0, categories.Count());
			int third = rnd.Next(0, categories.Count());


			do
			{
				first = rnd.Next(0, categories.Count());
				second = rnd.Next(0, categories.Count());
				third = rnd.Next(0, categories.Count());

			} while ((first == second || second == third || first == third));
			List<Category> selectedCategories = new List<Category> { categories[first], categories[second], categories[third] };
			vm.Categories = selectedCategories;


			return View(vm);
		}


		//[HttpPost]
		//public async Task<IActionResult> Index()
		//{
		//	ArticleIndexVM vm = new ArticleIndexVM();

		//	try
		//	{
				
		//			var onlineUser = await userManager.GetUserAsync(User);
		//			Author author = authorRepository.AuthorGetByStringId(onlineUser.Id);
		//			if (author != null && onlineUser!=null)
		//			{
		//				var favouriteArticles = articleRepository.GetUsersFavouriteArticles(author.Id);
		//				vm.FavouriteArticles = favouriteArticles;

		//			}

		//	}
		//	catch (Exception)
		//	{

		//		throw;
		//	}



		//	var articles = articleRepository.MostPopularArticles();

		//	vm.Articles = articles;

		//	List<Category> categories = categoryRepository.GetCategories();
		//	Random rnd = new Random();

		//	int first = rnd.Next(0, categories.Count());
		//	int second = rnd.Next(0, categories.Count());
		//	int third = rnd.Next(0, categories.Count());


		//	do
		//	{
		//		first = rnd.Next(0, categories.Count());
		//		second = rnd.Next(0, categories.Count());
		//		third = rnd.Next(0, categories.Count());

		//	} while ((first == second || second == third || first == third));
		//	List<Category> selectedCategories = new List<Category> { categories[first], categories[second], categories[third] };
		//	vm.Categories = selectedCategories;



	

		//	return View(vm);

		//}

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