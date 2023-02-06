using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyBlogWebsite.Models.Concrete;

namespace MyBlogWebsite.Data_Access_Layer_Folder_.EntityConfigurations
{
	public class ArticleEntityConfiguration : IEntityTypeConfiguration<Article>
	{
		public void Configure(EntityTypeBuilder<Article> builder)
		{
			builder.HasOne(x => x.Author).WithMany(x => x.Articles).HasForeignKey(x => x.AuthorId);
		}
	}
}
