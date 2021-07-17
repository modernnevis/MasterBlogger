using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using MB.Domain.CommentAgg;
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
            return _context.Articles
                .Include(x=>x.Comments)
                .Include(x => x.ArticleCategory)
                .Select(x => new ArticleQueryView
            {
                Id=x.Id,
                Title = x.Title,
                ShortDescription = x.ShortDescription,
                Image = x.Image,
                ArticleCategory =x.ArticleCategory.Name,
                CreationDate = x.CreationDate.ToString(CultureInfo.InvariantCulture),
                CommentCount = x.Comments.Count(z=>z.Status==Statuses.Confirmed)
            }).ToList();
        }

        public ArticleQueryView Get(long id)
        {
            return _context.Articles
                .Include(x => x.ArticleCategory)
                .Select(x => new ArticleQueryView
            {
                Id = x.Id,
                Title = x.Title,
                ShortDescription = x.ShortDescription,
                Image = x.Image,
                ArticleCategory = x.ArticleCategory.Name,
                CreationDate = x.CreationDate.ToString(CultureInfo.InvariantCulture),
                Content = x.Content,
                CommentCount = x.Comments.Count(z => z.Status == Statuses.Confirmed),
                Comments = MapComments(x.Comments.Where(z=>z.Status == Statuses.Confirmed))
                }).FirstOrDefault(x=>x.Id==id);
        }

        private static List<CommentQueryView> MapComments(IEnumerable<Comment> comments)
        {
            var result = new List<CommentQueryView>();
            foreach (var comment in comments)
            {
                result.Add(new CommentQueryView
                {
                    Name = comment.Name,
                    CreationDate = comment.CreationDate.ToString(CultureInfo.InvariantCulture),
                    Message = comment.Message
                });
            }

            return result;
        }
    }
}
