using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyBlogWebsite.Models.Concrete
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        //[NotMapped]
       // public IFormFile? Image { get; set; }

        // Navigations
        //public string? AuthorId { get; set; }
        public Author Author { get; set; }
    }
}
