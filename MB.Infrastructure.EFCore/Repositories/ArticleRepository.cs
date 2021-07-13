using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Text;
using MB.Domain.ArticleAgg;
using MB.Domain.ArticleCategoryAgg;

namespace MB.Infrastructure.EFCore.Repositories
{
    public class ArticleRepository : IArticleRepository
    {
        private readonly MasterBloggerContext _context;

        public ArticleRepository(MasterBloggerContext context)
        {
            _context = context;
        }
    }
}
