using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyBlogWebsite.Data_Access_Layer_Folder_.Repositories;
using MyBlogWebsite.Data_Access_Layer_Folder_.Repositories.Abstract;
using MyBlogWebsite.Data_Access_Layer_Folder_.Repositories.Concrete;
using MyBlogWebsite.Models.Concrete;
using MyBlogWebsite.Models.ViewModels;

namespace MyBlogWebsite.Controllers
{
    public class ArticleController : Controller
    {
        private readonly IAuthorRepository authorRepository;

        private readonly IRepository<Article> articleRepository;
        private readonly UserManager<IdentityUser> userManager;

        public ArticleController(IRepository<Article> articleRepository, UserManager<IdentityUser> userManager, IAuthorRepository authorRepository)
        {
            this.articleRepository = articleRepository;
            this.userManager = userManager;
            this.authorRepository= authorRepository;
        }

        //public async Task<IActionResult> Index()
        //{
        //    var user = await userManager.GetUserAsync(User);
        //    var articles = articleRepository.GetAll(); //düzenle ve sadece ilgili kullanıcının makalelerini getir.
        //    return View(articles);

        //    // Selectlist ile başka bir sayfaya veri göndermek ve makaleleri göstermek?
        //}

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
            ArticleVM vm = new ArticleVM();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ArticleVM model) 
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
            article.PublishDate= DateTime.Now;
            article.RequiredMinuteToReadEntireArticle = 1;
            article.TotalReadCount = 1;
            articleRepository.Add(article);
            return View(nameof(Index));
        }

    }
}
