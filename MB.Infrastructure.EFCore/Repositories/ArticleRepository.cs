using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using _01_FrameWork.Infrastructure;
using MB.Application.Contracts.Article;
using MB.Domain.ArticleAgg;
using Microsoft.EntityFrameworkCore;

namespace MB.Infrastructure.EFCore.Repositories
{
    public class ArticleRepository : BaseRepository<long , Article> , IArticleRepository
    {
        private readonly MasterBloggerContext _context;

        public ArticleRepository(MasterBloggerContext context) : base(context)
        {
            _context = context;
        }

        public List<ArticleViewModel> GetList()
        {
            return _context.Articles.Include(x => x.ArticleCategory)
                .Select(x => new ArticleViewModel
                {
                    Id = x.Id,
                    Title = x.Title,
                    IsDeleted = x.IsDeleted,
                    ArticleCategory = x.ArticleCategory.Name,
                    CreationDate = x.CreationDate.ToString(CultureInfo.InvariantCulture)
                }).ToList();
        }


    }
}

