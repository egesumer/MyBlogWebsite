using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyBlogWebsite.Data_Access_Folder.Repositories.Abstract;
using MyBlogWebsite.Data_Access_Layer_Folder_.Repositories;
using MyBlogWebsite.Data_Access_Layer_Folder_.Repositories.Abstract;
using MyBlogWebsite.Data_Access_Layer_Folder_.Repositories.Concrete;
using MyBlogWebsite.Models.Concrete;
using MyBlogWebsite.Models.Entities;
using MyBlogWebsite.Models.ViewModels;

namespace MyBlogWebsite.Controllers
{
	public class ArticleController : Controller
	{
		private readonly IAuthorRepository authorRepository;
		private readonly ICategoryRepository categoryRepository;
		private readonly IRepository<Article> articleRepository;
		private readonly UserManager<IdentityUser> userManager;

		public ArticleController(IRepository<Article> articleRepository, UserManager<IdentityUser> userManager, IAuthorRepository authorRepository, ICategoryRepository categoryRepository)
		{
			this.articleRepository = articleRepository;
			this.userManager = userManager;
			this.authorRepository = authorRepository;
			this.categoryRepository = categoryRepository;
		}

		//public async Task<IActionResult> Index()
		//{
		//    var user = await userManager.GetUserAsync(User);
		//    var articles = articleRepository.GetAll(); //düzenle ve sadece ilgili kullanıcının makalelerini getir.
		//    return View(articles);

		//    // Selectlist ile başka bir sayfaya veri göndermek ve makaleleri göstermek?
		//}

		[Authorize]
		public async Task<IActionResult> Index()
		{

			var user = await userManager.GetUserAsync(User);
			var author = authorRepository.AuthorGetByStringId(user.Id);
			var articles = articleRepository.GetAll().Where(x => x.AuthorId == author.Id);
			return View(articles);


		}


		[HttpGet]
		public IActionResult Create()
		{
			//ArticleCreateVM vm = new ArticleCreateVM();
			var categories = categoryRepository.GetCategories();

			ArticleCreateVM vm = new ArticleCreateVM();
			vm.Categories = categories;
			
			//ViewBag.Categories = new SelectList(categories, "Id", "CategoryName");

			//vm.Categories= categories;

			//vm.Categories = categoryRepository.GetAll();
			//ViewBag["Category"] = new SelectList(categoryRepository.GetAll(), "Id", "CategoryName");
			
			return View(vm);
		}

		[HttpPost]
		public async Task<IActionResult> Create(ArticleCreateVM model)
		{

			if (!ModelState.IsValid)
			{
				return View();
			}
			var user = await userManager.GetUserAsync(User);
			Author author = authorRepository.AuthorGetByStringId(user.Id);
			Article article = new Article();
			article.AuthorId = author.Id;
			article.ArticleTitle = model.ArticleTitle;
			article.Content = model.Content;
			article.CategoryId = model.SelectedCategoryId;              //		Yazar tarafından belirlenecek.
			article.PublishDate = DateTime.Now;
			article.RequiredMinuteToReadEntireArticle = CalculateRequiredMinsToReadArticle(model.Content);
			article.TotalReadCount = 0;
			articleRepository.Add(article);
			TempData["Message"] = "Makaleniz başarıyla paylaşıldı.";
			return RedirectToAction("Index", "Article");
		}

		public IActionResult Inspect(int id)
		{
			Article article = articleRepository.GetByID(id);
			ArticleVM vm = new ArticleVM();


			vm.ArticleTitle = article.ArticleTitle;
			vm.Content = article.Content;
			vm.PublishDate = (DateTime)article.PublishDate;
			vm.AuthorName = "DenemeYazar";
			vm.TotalReadCount = (int)article.TotalReadCount;
			vm.RequiredMinsToRead = (int)article.RequiredMinuteToReadEntireArticle;

			article.TotalReadCount++;
			articleRepository.Update(article);
			return View(vm);
		}

		public IActionResult Delete(int id)
		{
			Article article = articleRepository.GetByID(id);
			articleRepository.Delete(article);
			TempData["DeleteMessage"] = "Makaleniz silindi.";
			return RedirectToAction("Index", "Article");
		}


		/// <summary>
		/// Makalenin uzunluğuna göre ortalama tahmini bir okunma süresi belirler.
		/// </summary>
		/// <param name="content"></param>
		/// <returns></returns>
		public int CalculateRequiredMinsToReadArticle(string content)
		{
			int calculatedMinute;
			if (content.Length <= 100)
			{
				return calculatedMinute = 1;
			}
			if (content.Length > 100 && content.Length <= 500)
			{
				return calculatedMinute = 2;
			}
			if (content.Length > 500 && content.Length >= 900)
			{
				return calculatedMinute = 3;
			}
			if (content.Length > 900 && content.Length >= 1300)
			{
				return calculatedMinute = 4;
			}
			if (content.Length > 1300 && content.Length >= 1700)
			{
				return calculatedMinute = 5;
			}
			if (content.Length > 1700 && content.Length >= 2100)
			{
				return calculatedMinute = 6;
			}
			if (content.Length > 2100 && content.Length >= 2500)
			{
				return calculatedMinute = 7;
			}
			else
			{
				return calculatedMinute = 10;
			}
		}


	}
}
