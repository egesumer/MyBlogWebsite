using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyBlogWebsite.Data_Access_Layer_Folder_.Repositories;
using MyBlogWebsite.Data_Access_Layer_Folder_.Repositories.Concrete;
using MyBlogWebsite.Models.Concrete;
using MyBlogWebsite.Models.ViewModels;

namespace MyBlogWebsite.Controllers
{
    public class ArticleController : Controller
    {
        private readonly IRepository<Article> articleRepository;
        private readonly UserManager<IdentityUser> userManager;

        public ArticleController(IRepository<Article> _articleRepository, UserManager<IdentityUser> userManager)
        {
            articleRepository = _articleRepository;
            this.userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var user = await userManager.GetUserAsync(User);
            var articles = articleRepository.GetWhere(x => x.AuthorId == x.Id);
            return View(articles);
        }

        public IActionResult Create()
        {
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
            Article article = new Article();
            article.ArticleTitle = model.ArticleTitle;
            article.ArticleLength = model.Content;
            article.Author.ApplicationUserId = user.Id;
            article.PublishDate= DateTime.Now;
            articleRepository.Update(article);
            return View(nameof(Index));
        }

    }
}
