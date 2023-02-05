using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyBlogWebsite.Models.Concrete;
using System.Drawing;

namespace MyBlogWebsite.Areas.Identity.Data
{
    internal class ApplicationUserEntityConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder.Property(x=>x.FirstName).HasMaxLength(50).IsRequired();
            builder.Property(x=>x.LastName).HasMaxLength(50).IsRequired();
            //builder.Property(x => x.Image);

            builder.HasOne(x => x.Author).WithOne(x => x.ApplicationUser).HasForeignKey<Author>(k => k.ApplicationUserId); //AuthorID?

        }
    }
}
