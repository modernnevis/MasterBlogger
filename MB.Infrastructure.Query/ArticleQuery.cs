using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using MB.Infrastructure.EFCore;
using Microsoft.EntityFrameworkCore;

namespace MB.Infrastructure.Query
{
    public class ArticleQuery : IArticleQuery
    {
        private readonly MasterBloggerContext _context;

        public ArticleQuery(MasterBloggerContext context)
        {
            _context = context;
        }

        public List<ArticleQueryView> GetArticles()
        {
            return _context.Articles.Include(x => x.ArticleCategory).Select(x => new ArticleQueryView
            {
                Id=x.Id,
                Title = x.Title,
                ShortDescription = x.ShortDescription,
                Image = x.Image,
                ArticleCategory =x.ArticleCategory.Name,
                CreationDate = x.CreationDate.ToString(CultureInfo.InvariantCulture)
            }).ToList();
        }

        public ArticleQueryView Get(long id)
        {
            return _context.Articles.Include(x => x.ArticleCategory).Select(x => new ArticleQueryView
            {
                Id = x.Id,
                Title = x.Title,
                ShortDescription = x.ShortDescription,
                Image = x.Image,
                ArticleCategory = x.ArticleCategory.Name,
                CreationDate = x.CreationDate.ToString(CultureInfo.InvariantCulture),
                Content = x.Content
            }).FirstOrDefault(x=>x.Id==id);
        }
    }
}
