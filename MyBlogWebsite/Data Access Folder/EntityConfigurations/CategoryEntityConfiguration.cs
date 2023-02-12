using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyBlogWebsite.Models.Entities;

namespace MyBlogWebsite.Data_Access_Folder.EntityConfigurations
{
    public class CategoryEntityConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.Property(x=>x.CategoryName).IsRequired().HasMaxLength(50);
            builder.HasMany(x => x.Articles).WithOne(x => x.Category).HasForeignKey(x => x.CategoryId);
        }
    }
}
