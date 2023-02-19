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
		private readonly IArticleRepository articleRepositorySecond;
		public AuthorController(UserManager<IdentityUser> _userManager, IRepository<Author> _authorRepository, IRepository<Article> articleRepository, IAuthorRepository authorRepositorySecond, ICategoryRepository categoryRepository, IArticleRepository articleRepositorySecond)
		{
			userManager = _userManager;
			authorRepository = _authorRepository;
			this.articleRepository = articleRepository;
			this.authorRepositorySecond = authorRepositorySecond;
			this.categoryRepository = categoryRepository;
			this.articleRepositorySecond = articleRepositorySecond;
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
			vm.FavoryCategoryArticles = articleRepository.GetWhere(x => x.AuthorId == desiredAuthor.Id);
			vm.AuthorName = desiredAuthor.AuthorName;
			vm.AboutMe = desiredAuthor.AboutMe;

			if (desiredAuthor.Photo!=null)
			{
                string imageData = Convert.ToBase64String(desiredAuthor.Photo);
                string imageBase64Data = string.Format("data:image/png;base64,{0}", imageData);
                vm.Path = imageBase64Data;
            }

            return View(vm);

		}



		[Authorize]
		public async Task<IActionResult> YourProfile()
		{
			var user = await userManager.GetUserAsync(User);
            try
			{
				Author author = authorRepositorySecond.AuthorGetByStringId(user.Id);
				if (author != null)
				{
                    AuthorProfileVM vm = new AuthorProfileVM();

                    if (author.Photo!=null)
					{
                        string imageData = Convert.ToBase64String(author.Photo);
                        string imageBase64Data = string.Format("data:image/png;base64,{0}", imageData);
                        vm.Path = imageBase64Data;

                    }

					author.FavoryCategories = categoryRepository.GetFavouriteCategories(author.Id);
                    vm.AuthorName = author.AuthorName;
					vm.AboutMe = author.AboutMe;
					vm.FavouriteCategories = categoryRepository.GetFavouriteCategories(author.Id);
					vm.FavoryCategoryArticles = articleRepositorySecond.GetUsersFavouriteArticles(author.Id);
					return View(vm);

				}
				else
				{
					TempData["AuthorNotActivated"] = "Yazar hesabınıza erişmek için kendinize yazar kimliği oluşturmalısınız.";
					return RedirectToAction("Index", "Home");

				}

			}
			catch (Exception)
			{
				TempData["AuthorNotActivated"] = "Yazar hesabınıza erişmek için kendinize yazar kimliği oluşturmalısınız.";
				return RedirectToAction("Index", "Home");

			}



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
					if (ModelState.IsValid)
					{
                        Author author = new Author();
                        author.AuthorName = model.AuthorName;
                        author.AuthorConfirmed = true;
                        author.ApplicationUserId = user.Id;
                        authorRepository.Add(author);

                        TempData["Message"] = "Yazar kimliğiniz başarıyla oluşturuldu.";
                        return RedirectToAction("Index", "Article");
                    }
					else
					{
                        TempData["WarningMessage"] = "Lütfen ilgili alanı doldurunuz.";
                        return RedirectToAction("AuthorActivation", "Author");
                    }

				
				}

			}
			catch (Exception)
			{

				throw;
			}
		}


		[Authorize]
		[HttpGet]
		public async Task<IActionResult> EditProfile()
		{
			var user = await userManager.GetUserAsync(User);
			try
			{
				Author author = authorRepositorySecond.AuthorGetByStringId(user.Id);
				if (author != null)
				{
					var categories = categoryRepository.GetAll();
					AuthorEditVM vm = new AuthorEditVM();

					vm.FavCategories = categories;
					return View(vm);
				}
				else
				{
					TempData["AuthorNotActivated"] = "Yazar kimliğiniz aktif değil.";
					return RedirectToAction("Index", "Home");
				}
			}
			catch (Exception)
			{

				throw;
			}



		}

		[Authorize]
		[HttpPost]
		public async Task<IActionResult> EditProfile(AuthorEditVM vm)
		{

			var user = await userManager.GetUserAsync(User);



			Author author = authorRepositorySecond.AuthorGetByStringId(user.Id);


			if (string.IsNullOrEmpty(vm.AuthorName) && (!string.IsNullOrEmpty(vm.AboutMe)))
			{
				vm.AuthorName = author.AuthorName;
				author.AboutMe = vm.AboutMe;
				author.AuthorName = vm.AuthorName;
			}
			else if (string.IsNullOrEmpty(vm.AboutMe) && (!string.IsNullOrEmpty(vm.AuthorName)))
			{
				vm.AboutMe = author.AboutMe;
				author.AuthorName = vm.AuthorName;
				author.AboutMe = vm.AboutMe;
			}
			else if (string.IsNullOrEmpty(vm.AuthorName) && string.IsNullOrEmpty(vm.AboutMe))
			{

				TempData["UpdateAuthorWarning"] = "Lütfen ilgili alanları doldurun.";
				return RedirectToAction("EditProfile", "Author");
			}
			else
			{
				author.AboutMe = vm.AboutMe;
				author.AuthorName = vm.AuthorName;
			}

			authorRepository.Update(author);
			TempData["UpdateAuthor"] = "Bilgileriniz güncellendi.";
			return RedirectToAction("EditProfile", "Author");


		}
		[HttpGet]
		public IActionResult UploadPhoto()
		{
			//PhotoVM vm = new PhotoVM();
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> UploadPhoto(PhotoVM model)
		{
            var user = await userManager.GetUserAsync(User);
            Author author = authorRepositorySecond.AuthorGetByStringId(user.Id);

			byte[] imageData;



            if (model.Photo != null && model.Photo.Length > 0)
            {
                var fileName = Guid.NewGuid().ToString() + Path.GetExtension(model.Photo.FileName);
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", fileName);
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    model.Photo.CopyTo(stream);
                }
                using (var binaryReader = new BinaryReader(model.Photo.OpenReadStream()))
                {
                    author.Photo = binaryReader.ReadBytes((int)model.Photo.Length);
                    authorRepository.Update(author);
                }
                model.Path = fileName;
            }


            return RedirectToAction("YourProfile", "Author");
        }


		[Authorize]
		[HttpPost]
		public async Task<IActionResult> EditCategory(AuthorEditVM vm, IFormCollection form)
		{

			try
			{
				var user = await userManager.GetUserAsync(User);
				Category category = categoryRepository.GetByID(vm.FavCategoryId);
				Author author = authorRepositorySecond.AuthorGetByStringId(user.Id);

				if (form["submitButton"].Equals("Favorilere Ekle"))
				{

					author.FavoryCategories.Add(category);
					bool check = authorRepository.Update(author);
					if (check)
					{
						TempData["UpdateAuthor"] = "Favorilerinize başarıyla eklendi.";
						return RedirectToAction("EditProfile", "Author");
					}
					else
					{
						TempData["UpdateFavouriteWarning"] = "Bu kategoriyi daha önce eklediniz.";
						return RedirectToAction("EditProfile", "Author");
					}


				}
				else
				{
					bool check = authorRepositorySecond.RemoveCategory(author.Id, category.Id);
					if (check)
					{
						TempData["UpdateAuthor"] = "Seçtiğiniz kategori silindi.";
						return RedirectToAction("EditProfile", "Author");
					}
					else
					{
						TempData["UpdateFavouriteWarning"] = "Böyle bir kategori favorilerinizde bulunmuyor.";
						return RedirectToAction("EditProfile", "Author");
					}


				}


			}
			catch (Exception)
			{
				TempData["UpdateAuthorWarning"] = "Lütfen ilgili alanları doldurun.";
				return RedirectToAction("EditProfile", "Author");

			}





		}


	}
}
