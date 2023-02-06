using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyBlogWebsite.Data_Access_Layer_Folder_.Repositories;
using MyBlogWebsite.Data_Access_Layer_Folder_.Repositories.Concrete;
using MyBlogWebsite.Models.Concrete;

namespace MyBlogWebsite.Controllers
{
    public class ArticleController : Controller
    {
        private readonly IRepository<Article> articleRepository;

        public ArticleController(IRepository<Article> _articleRepository)
        {
            articleRepository = _articleRepository;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
