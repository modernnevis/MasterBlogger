using MB.Domain.ArticleAgg;
using MB.Domain.ArticleCategoryAgg;
using MB.Infrastructure.EFCore.Mappings;
using Microsoft.EntityFrameworkCore;

namespace MB.Infrastructure.EFCore
{
    public class MasterBloggerContext : DbContext
    {
        public DbSet<Article> Articles { get; set; }
        public DbSet<ArticleCategory> ArticleCategories { get; set; }
        public MasterBloggerContext(DbContextOptions<MasterBloggerContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new ArticleCategoryMapping());
            builder.ApplyConfiguration(new ArticleMapping());
            base.OnModelCreating(builder);
        }
    }
}
