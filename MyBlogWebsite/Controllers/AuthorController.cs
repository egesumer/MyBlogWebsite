using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyBlogWebsite.Data_Access_Layer_Folder_.Repositories;
using MyBlogWebsite.Data_Access_Layer_Folder_.Repositories.Abstract;
using MyBlogWebsite.Data_Access_Layer_Folder_.Repositories.Concrete;
using MyBlogWebsite.Models.Concrete;
using MyBlogWebsite.Models.ViewModels;

namespace MyBlogWebsite.Controllers
{
	public class AuthorController : Controller
	{
		private readonly UserManager<IdentityUser> userManager;
		private readonly IRepository<Author> authorRepository;
		private readonly IRepository<Article> articleRepository;
		private readonly IAuthorRepository authorRepositorySecond;
		public AuthorController(UserManager<IdentityUser> _userManager, IRepository<Author> _authorRepository, IRepository<Article> articleRepository, IAuthorRepository authorRepositorySecond)
		{
		userManager= _userManager;
			authorRepository = _authorRepository;
			this.articleRepository=articleRepository;
			this.authorRepositorySecond=authorRepositorySecond;
		}
		public async Task<IActionResult> Index()
		{
			try
			{
				var user = await userManager.GetUserAsync(User);
				Author author = authorRepositorySecond.AuthorGetByStringId(user.Id);
				if (author == null)
				{
					return View();

				}
			}
			catch (Exception)
			{

				return View();
			};

			TempData["AuthorIdAlreadyActivated"] = "Yazar kimliğiniz halihazırda oluşturulmuş durumda.";
			return RedirectToAction("Index", "Article");
		}

		[HttpGet]
		public IActionResult AuthorProfile(int id)
		{
			AuthorProfileVM vm = new AuthorProfileVM();
			Article article = articleRepository.GetByID(id);
			int desiredAuthorId = article.AuthorId;
			Author desiredAuthor = authorRepository.GetByID(desiredAuthorId);
			vm.Articles = articleRepository.GetWhere(x => x.AuthorId == desiredAuthor.Id);
			vm.AuthorName = desiredAuthor.AuthorName;
			return View(vm);

		}
		public IActionResult AuthorActivation()
		{
			

			return View();
		}
		// [Authorize(Policy = "AuthorConfirmation")]

		[HttpPost]
		public async Task<IActionResult> AuthorActivation(AuthorVM model)
		{
            var user = await userManager.GetUserAsync(User);
			Author author = new Author();
			author.AuthorName= model.AuthorName;
			author.AuthorConfirmed = true;
			author.ApplicationUserId = user.Id;
			authorRepository.Add(author);

			TempData["Message"] = "Yazar kimliğiniz başarıyla oluşturuldu.";
			return View(nameof(Index));

		}


	}
}
