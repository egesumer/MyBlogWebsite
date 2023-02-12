using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyBlogWebsite.Models.Concrete;

namespace MyBlogWebsite.Data_Access_Layer_Folder_.EntityConfigurations
{
	internal class AuthorEntityConfiguration : IEntityTypeConfiguration<Author>
	{
		public void Configure(EntityTypeBuilder<Author> builder)
		{
            //builder.HasIndex(x => x.ApplicationUserId).HasName("AlternateKey_ApplicationUserId").IsUnique(false); // UniqueKey zorunluluğunu kaldırma.

            builder.Property(x => x.AuthorName).IsRequired().HasMaxLength(50);
			builder.Property(x => x.AboutMe).HasDefaultValue("");

			builder.HasMany(x => x.FavoryCategories).WithMany(x => x.Authors);
		}
	}
}
