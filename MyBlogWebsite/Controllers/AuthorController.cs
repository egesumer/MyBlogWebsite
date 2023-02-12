using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyBlogWebsite.Data_Access_Folder.Repositories.Abstract;
using MyBlogWebsite.Data_Access_Folder.Repositories.Concrete;
using MyBlogWebsite.Data_Access_Layer_Folder_.Repositories;
using MyBlogWebsite.Data_Access_Layer_Folder_.Repositories.Abstract;
using MyBlogWebsite.Data_Access_Layer_Folder_.Repositories.Concrete;
using MyBlogWebsite.Models.Concrete;
using MyBlogWebsite.Models.Entities;
using MyBlogWebsite.Models.ViewModels;

namespace MyBlogWebsite.Controllers
{
	public class AuthorController : Controller
	{
		private readonly UserManager<IdentityUser> userManager;
		private readonly IRepository<Author> authorRepository;
		private readonly IRepository<Article> articleRepository;
		private readonly IAuthorRepository authorRepositorySecond;
		private readonly ICategoryRepository categoryRepository;
		private readonly IFavCategoryRepository favCategoryRepository;
		public AuthorController(UserManager<IdentityUser> _userManager, IRepository<Author> _authorRepository, IRepository<Article> articleRepository, IAuthorRepository authorRepositorySecond, ICategoryRepository categoryRepository, IFavCategoryRepository favCategoryRepository)
        {
            userManager = _userManager;
            authorRepository = _authorRepository;
            this.articleRepository = articleRepository;
            this.authorRepositorySecond = authorRepositorySecond;
            this.categoryRepository = categoryRepository;
            this.favCategoryRepository = favCategoryRepository;
        }

        [Authorize]
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

                return RedirectToAction("Index", "Home");
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

		[Authorize]
		[HttpGet]
		public async Task<IActionResult> AuthorActivation()
		{
			return View();
		}



		[Authorize]
		[HttpPost]
		public async Task<IActionResult> AuthorActivation(AuthorVM model)
		{

			try
			{
				var user = await userManager.GetUserAsync(User);
				Author authors = authorRepositorySecond.AuthorGetByStringId(user.Id);
				if (authors != null)
				{
                    TempData["AuthorIdAlreadyActivated"] = "Yazar kimliğiniz halihazırda oluşturulmuş durumda.";
                    return RedirectToAction("Index", "Article");
                }
				else
				{
                    Author author = new Author();
                    author.AuthorName = model.AuthorName;
                    author.AuthorConfirmed = true;
                    author.ApplicationUserId = user.Id;
                    authorRepository.Add(author);

                    TempData["Message"] = "Yazar kimliğiniz başarıyla oluşturuldu.";
                    return RedirectToAction("Index", "Article");
                }

            }
			catch (Exception)
			{

				throw;
			}
		}


		//[Authorize]
		//[HttpGet]
		//public async Task<IActionResult> EditProfile()
		//{
		//	AuthorEditVM vm = new AuthorEditVM();
		//	//var categories = categoryRepository.GetAll();
		//	var user = userManager.GetUserAsync(User);
		//	Author editAuthor = authorRepository.GetByID(user.Id);
		//	vm.Id = editAuthor.Id;
		//	//vm.FavouriteCategory= categories;
		//	return View(vm);
		//}

		//[HttpPost]
		//public IActionResult EditProfile(AuthorEditVM vm)
		//{
		//	//var favCat = categoryRepository.GetByID(vm.FavouriteCategoriesId);
		//	//favCategoryRepository.Add(favCat.CategoryName);


		//	Author author = authorRepository.GetByID(vm.Id);
		//	//FavCategory favCategory = new FavCategory();
		//	//favCategory.Id= vm.Id;
		//	author.AuthorName = vm.AuthorName;
		//	author.AboutMe = vm.AboutMe;
		//	//author.FavCategoryId = 

		//	TempData["UpdateAuthor"] = "Bilgileriniz güncellendi.";
		//	return RedirectToAction("Index", "Article");
		//}

	}
}
