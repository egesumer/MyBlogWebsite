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

        [Authorize]
        public async Task<IActionResult> Index()
        {

         
            try
            {
                var onlineUser = await userManager.GetUserAsync(User);
                Author onlineAuthor = authorRepository.AuthorGetByStringId(onlineUser.Id);
                if (onlineAuthor!=null)
                {

                    var user = await userManager.GetUserAsync(User);
                    var author = authorRepository.AuthorGetByStringId(user.Id);
                    var articles = articleRepository.GetAll().Where(x => x.AuthorId == author.Id);
                    return View(articles);
                  
                }
                else
                {
                    TempData["Error"] = "Lütfen önce yazar kimliğinizi oluşturun.";

                    return RedirectToAction("Index", "Home");
                }
            }
            catch (Exception)
            {
                return RedirectToAction("Index", "Home");
            }

        }

        [Authorize]
        [HttpGet]
        public IActionResult Create()
        {
            var categories = categoryRepository.GetCategories();

            ArticleCreateVM vm = new ArticleCreateVM();
            vm.Categories = categories;

            return View(vm);
        }

        [Authorize]
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
            article.CategoryId = model.SelectedCategoryId;              
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

            int authorIdOfArticle = article.AuthorId;
            Author author = authorRepository.GetByID(authorIdOfArticle);

            vm.ArticleId = id;
            vm.ArticleTitle = article.ArticleTitle;
            vm.Content = article.Content;
            vm.PublishDate = (DateTime)article.PublishDate;
            vm.AuthorName = author.AuthorName;
            vm.TotalReadCount = (int)article.TotalReadCount;
            vm.RequiredMinsToRead = (int)article.RequiredMinuteToReadEntireArticle;

            article.TotalReadCount++;
            articleRepository.Update(article);
            return View(vm);
        }


        //[Route("/Author/AuthorProfile/{id}")]

        [Authorize]
        [HttpGet]
        public IActionResult Update(int id)
        {

            // TRY CATCH
            ArticleUpdateVM vm = new ArticleUpdateVM();
            var article = articleRepository.GetByID(id);
            vm.ArticleTitle = article.ArticleTitle;
            vm.Content = article.Content;
            vm.Id = id;
            //var categories = categoryRepository.GetCategories();

            return View(vm);
        }
        [HttpPost]
        public IActionResult Update(ArticleUpdateVM vm)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            Article article = articleRepository.GetByID(vm.Id);
            article.ArticleTitle = vm.ArticleTitle;
            article.Content = vm.Content;
            article.RequiredMinuteToReadEntireArticle = CalculateRequiredMinsToReadArticle(article.Content);
            articleRepository.Update(article);
            TempData["UpdateMessage"] = "Makaleniz güncellendi.";
            return RedirectToAction("Index", "Article");
        }
        [Authorize]
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
            if (content.Length <= 1500)
            {
                return calculatedMinute = 1;
            }
            if (content.Length > 1500 && content.Length <= 3000)
            {
                return calculatedMinute = 2;
            }
            if (content.Length > 3000 && content.Length <= 4500)
            {
                return calculatedMinute = 3;
            }
            if (content.Length > 4500 && content.Length <= 6000)
            {
                return calculatedMinute = 4;
            }
            if (content.Length > 6000 && content.Length <= 7500)
            {
                return calculatedMinute = 5;
            }
            if (content.Length > 7500 && content.Length <= 9000)
            {
                return calculatedMinute = 6;
            }
            else
            {
                return calculatedMinute = 10;
            }
        }


    }
}
