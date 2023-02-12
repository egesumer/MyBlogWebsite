using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyBlogWebsite.Data_Access_Layer_Folder_.Repositories;
using MyBlogWebsite.Data_Access_Layer_Folder_.Repositories.Abstract;
using MyBlogWebsite.Models.Concrete;
using MyBlogWebsite.Models.Entities;

namespace MyBlogWebsite.Controllers
{
	public class CategoryController : Controller
	{
		private readonly IRepository<Category> categoryRepository;
		private readonly IArticleRepository articleRepository;
		public CategoryController(IRepository<Category> categoryRepository,IArticleRepository articleRepository)
		{
			this.categoryRepository = categoryRepository;
			this.articleRepository = articleRepository;
		}


		[Authorize]
		public IActionResult Index(int id)
		{
			
			var desiredArticles = articleRepository.GetArticlesWithDesiredCategory(id);

            return View(desiredArticles);

		}
	}
}
